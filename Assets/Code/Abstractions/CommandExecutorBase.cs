using UnityEngine;

public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T : ICommand
{
    public void ExecuteCommand(object command)
    {
        SpecificExecuteCommand((T)command);
    }

    public abstract void SpecificExecuteCommand(T command);
}
