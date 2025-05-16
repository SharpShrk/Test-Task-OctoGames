using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private Transform _subTaskContainer;
    [SerializeField] private GameObject _subtaskPrefab;

    private int _questID;
    private List<SubTask> _subtaskList = new List<SubTask>();

    public int QuestID => _questID;


    public void Initialize(int id, string title)
    {
        _titleText.text = title;
        _questID = id;
    }

    public void Complete()
    {
        _titleText.fontStyle |= FontStyles.Strikethrough;

        foreach (var sub in _subtaskList)
            sub.Complåte();
    }

    public void AddSubTask(int subTaskID, string subTaskText)
    {
        GameObject subTaskGO = Instantiate(_subtaskPrefab, _subTaskContainer);
        SubTask subTaskUI = subTaskGO.GetComponent<SubTask>();
        subTaskUI.Initialize(subTaskID, subTaskText);
        _subtaskList.Add(subTaskUI);
    }

    public SubTask GetSubtask(int subTaskID)
    {
        return _subtaskList.FirstOrDefault(subTask => subTask.ID == subTaskID);
    }
}
