using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Naninovel;
using System.Collections;

public class GlobalLocation : MonoBehaviour
{
    [SerializeField] private GameObject _discriptionPanel;
    [SerializeField] private GameObject _errorPanel;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private string _description;
    [SerializeField] private bool _isLocationOpen;
    [SerializeField] private Button _button;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(2f);
    private Coroutine _hideCoroutine;


    private void OnEnable()
    {
        _discriptionPanel.SetActive(false);
        _errorPanel.SetActive(false);
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void ShowDescription()
    {
        _text.text = _description;
        _discriptionPanel.SetActive(true);
    }

    public void HideDescription()
    {
        _discriptionPanel.SetActive(false);
    }

    private void OnButtonClick()
    {
        if (_isLocationOpen)
        {
            var uiManager = Engine.GetService<IUIManager>();
            var ui = uiManager.GetUI("GlobalMapUI");
            ui?.Hide();
        }
        else
        {
            _errorPanel.SetActive(true);

            if (_hideCoroutine != null)
            {
                StopCoroutine(_hideCoroutine);
            }

            _hideCoroutine = StartCoroutine(HideAfterDelay());
        }
    }

    private IEnumerator HideAfterDelay()
    {
        yield return _waitForSeconds;
        _errorPanel.SetActive(false);
    }
}