using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private AssetsContext _assetsContext;
    [SerializeField] private SelectableValue _selectableValue;
    [SerializeField] private CommandButtonsView _commandButtonsView;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectableValue.OnSelected += OnSelected;
        OnSelected(_selectableValue.CurrentValue);
        _commandButtonsView.OnClick += OnButtonClick;
    }

    private void OnSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable) return;

        _currentSelectable = selectable;
        _commandButtonsView.Clear();
        Debug.Log(_currentSelectable);
        if (selectable != null)
        {
            var commandExecutor = new List<ICommandExecutor>();
            commandExecutor.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
            Debug.Log(commandExecutor.Count);
            _commandButtonsView.MakeLayout(commandExecutor);
        }
    }

    private void OnButtonClick(ICommandExecutor commandExecutor)
    {
        var unitProducer = commandExecutor as CommandExecutorBase<IProduceUnitCommand>;
        var attack = commandExecutor as CommandExecutorBase<IAttackCommand>;
        var patrol = commandExecutor as CommandExecutorBase<IPatrolCommand>;
        var move = commandExecutor as CommandExecutorBase<IMoveCommand>;
        var stop = commandExecutor as CommandExecutorBase<IStopCommand>;
        
        if(unitProducer != null)
        {
            unitProducer.SpecificExecuteCommand(_assetsContext.Inject(new ProduceUnitCommandHeir()));
            return;
        }

        if(attack != null)
        {
            attack.SpecificExecuteCommand(new AttackCommand());
            return;
        }

        if(patrol != null)
        {
            patrol.SpecificExecuteCommand(new PatrolCommand());
            return;
        }

        if(move != null)
        {
            move.SpecificExecuteCommand(new MoveCommand());
            return;
        }

        if(stop != null)
        {
            stop.SpecificExecuteCommand(new StopCommand());
            return;
        }

        throw new ApplicationException(($"{nameof(CommandButtonsPresenter)}.{nameof(OnButtonClick)}:Unknown type of commands executor: { commandExecutor.GetType().FullName}!"));
    }
}
