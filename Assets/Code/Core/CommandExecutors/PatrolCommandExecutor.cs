using UnityEngine;
public class PatrolCommandExecutor : CommandExecutorBase<IPatrolCommand>
{
    public override void SpecificExecuteCommand(IPatrolCommand command)
    {
        Debug.Log("Patrol");
    }
}

