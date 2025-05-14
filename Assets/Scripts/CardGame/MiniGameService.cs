using Naninovel;
using UnityEngine;

[InitializeAtRuntime]
public class MiniGameService : IEngineService
{
    public UniTask InitializeServiceAsync()
    {
        return UniTask.CompletedTask;
    }

    public void ResetService() { }

    public void DestroyService() { }

    public async UniTask<bool> PlayMiniGameAsync()
    {
        Engine.GetService<IUIManager>().GetUI<CardGameUI>().Show();
        bool success = await RunCardMatchingGameAsync();
        Engine.GetService<IUIManager>().GetUI<CardGameUI>().Hide();
        return success;
    }

    private async UniTask<bool> RunCardMatchingGameAsync()
    {
        CardGame cardGame = Object.FindObjectOfType<CardGame>();

        if (cardGame == null)
        {
            Debug.LogError("CardGame отсутствует");
            return false;
        }

        bool result = await cardGame.PlayGameAsync();
        return result;
    }
}