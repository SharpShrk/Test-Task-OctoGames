using Naninovel;
using UnityEngine;

[CommandAlias("switchButtonLocation")]
public class ToggleLocationButtonCommand : Command
{
    [ParameterAlias("locationName")]
    public StringParameter LocationName;

    [ParameterAlias("isActive")]
    public BooleanParameter IsActive;

    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var uiManager = Engine.GetService<IUIManager>();
        var locationUI = uiManager.GetUI<LocationUI>();

        if (locationUI != null)
        {
            locationUI.SwitchButton(LocationName, IsActive);
        }
        else
        {
            Debug.LogWarning("LocationUI не найден");
        }

        return UniTask.CompletedTask;
    }
}