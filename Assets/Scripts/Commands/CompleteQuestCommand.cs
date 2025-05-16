using Naninovel;
using UnityEngine;

[CommandAlias("completeQuest")]
public class CompleteQuestCommand : Command
{
    [ParameterAlias("questId")]
    public IntegerParameter QuestID;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var questManager = Object.FindObjectOfType<QuestManager>();
        questManager.CompleteQuest(QuestID);

        return UniTask.CompletedTask;
    }
}