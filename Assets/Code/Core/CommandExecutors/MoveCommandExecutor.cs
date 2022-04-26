using UnityEngine;
public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
{
    public override void SpecificExecuteCommand(IMoveCommand command)
    {
        Debug.Log("Move");
    }
}