using Naninovel.UI;
using UnityEngine;

public class LocationUI : CustomUI
{
    [SerializeField] private Location[] _locations;

    public void SwitchButton(string locationName, bool isActive)
    {
        Location findLocation = null;

        foreach(var location in _locations)
        {
            if (location.LocationName == locationName)
            {
                findLocation = location;
                findLocation.SwitchActiveStayButton(isActive);
                break;
            }
        }

        if (findLocation == null)
            Debug.LogError("Совпадений по имени локации не найдено");
    }
}
