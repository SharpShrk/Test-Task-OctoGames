using Naninovel;
using UnityEngine;

[CommandAlias("addQuest")]
public class AddQuestCommand : Command
{
    [ParameterAlias("questId")]
    public IntegerParameter QuestID;

    [ParameterAlias("title")]
    public StringParameter Title;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var questManager = Object.FindObjectOfType<QuestManager>();
        questManager.CreateQuest(QuestID, Title);

        return UniTask.CompletedTask;
    }
}