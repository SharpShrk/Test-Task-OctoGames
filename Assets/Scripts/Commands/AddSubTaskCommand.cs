using Naninovel;
using UnityEngine;

[CommandAlias("addSubtask")]
public class AddSubtaskCommand : Command
{
    [ParameterAlias("questId")]
    public IntegerParameter QuestID;

    [ParameterAlias("subId")]
    public IntegerParameter SubTaskID;

    [ParameterAlias("subText")]
    public StringParameter SubTaskText;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var questManager = Object.FindObjectOfType<QuestManager>();
        questManager.CreateSubtask(QuestID, SubTaskID, SubTaskText);

        return UniTask.CompletedTask;
    }
}