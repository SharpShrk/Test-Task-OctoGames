using UnityEngine;
using UnityEngine.UI;

public class Location : MonoBehaviour
{
    [SerializeField] private string _locationName;
    
    private Button _locationButton;

    public string LocationName => _locationName;

    private void Start()
    {
        _locationButton = GetComponent<Button>();
    }

    public void SwitchActiveStayButton(bool active)
    {
        if (_locationButton != null)
            _locationButton.interactable = active;
        else
            Debug.LogError("Кнопка не назначена в инспекторе");
    }
}
