using Naninovel;

[CommandAlias("playMiniGame")]
public class PlayMiniGameCommand : Command
{
    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var miniGameService = Engine.GetService<MiniGameService>();
        bool result = await miniGameService.PlayMiniGameAsync();

        var variableManager = Engine.GetService<ICustomVariableManager>();
        variableManager.TrySetVariableValue("MiniGameResult", result);
    }
}