using Naninovel;
using UnityEngine;

[CommandAlias("clearQuest")]
public class ClearQuestCommand : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var questManager = Object.FindObjectOfType<QuestManager>();
        questManager.ResetQuests();

        return UniTask.CompletedTask;
    }
}