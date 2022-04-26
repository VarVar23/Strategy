using UnityEngine;

public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
{
    public override void SpecificExecuteCommand(IAttackCommand command)
    {
        Debug.Log("Attack");
    }
}
