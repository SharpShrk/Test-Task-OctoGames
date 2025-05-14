using Naninovel;
using Naninovel.Commands;

[CommandAlias("playMiniGame")]
public class PlayMiniGameCommand : Command
{
    public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var miniGameService = Engine.GetService<MiniGameService>();
        bool result = await miniGameService.PlayMiniGameAsync();

        if (result)
        {
            // Логика при успешном завершении мини-игры
        }
        else
        {
            // Логика при неудачном завершении мини-игры
        }
    }
}
