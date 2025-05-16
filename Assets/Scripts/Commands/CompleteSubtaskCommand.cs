using Naninovel;
using UnityEngine;

[CommandAlias("completeSubtask")]
public class CompleteSubtaskCommand : Command
{
    [ParameterAlias("questId")]
    public IntegerParameter QuestID;

    [ParameterAlias("subId")]
    public IntegerParameter SubTaskID;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var questManager = Object.FindObjectOfType<QuestManager>();
        questManager.CompleteSubtask(QuestID, SubTaskID);

        return UniTask.CompletedTask;
    }
}