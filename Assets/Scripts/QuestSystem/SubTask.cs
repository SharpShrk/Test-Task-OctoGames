using UnityEngine;
using TMPro;

public class SubTask : MonoBehaviour
{
    private int _id;
    private TMP_Text _text;

    public int ID => _id;

    public void Initialize(int id, string text)
    {
        _text = GetComponent<TMP_Text>();

        _id = id;
        _text.text = text;
    }

    public void Complеte()
    {
        if (_text != null)
        {
            _text.fontStyle |= FontStyles.Strikethrough;
        }
        else
        {
            Debug.LogWarning("компонент TMP_Text недоступен");
        }
    }
}