using UnityEngine;
public class StopCommandExecutor : CommandExecutorBase<IStopCommand>
{
    public override void SpecificExecuteCommand(IStopCommand command)
    {
        Debug.Log("Stop");
    }
}

