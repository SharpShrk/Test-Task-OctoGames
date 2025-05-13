using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private Transform _questContainer;
    [SerializeField] private GameObject _taskItemPrefab;

    private List<Quest> _questUIList = new List<Quest>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void CreateQuest(int id, string title)
    {
        var questObject = Instantiate(_taskItemPrefab, _questContainer);
        var questScript = questObject.GetComponent<Quest>();
        questScript.Initialize(id, title);
        
        _questUIList.Add(questScript);
    }

    public void CreateSubtask(int questID, int subTaskID, string subTaskText)
    {
        foreach (var quest in _questUIList)
        {
            if (quest.QuestID == questID)
            {
                quest.AddSubTask(subTaskID, subTaskText);
            }
        }
    }

    public void CompleteQuest(int questID)
    {
        foreach (var quest in _questUIList)
        {
            if (quest.QuestID == questID)
            {
                quest.Complete();
                break;
            }
        }
    }

    public void CompleteSubtask(int questID, int subTaskID)
    {
        SubTask subTask = null;

        foreach (var quest in _questUIList)
        {
            if (quest.QuestID == questID)
                subTask = quest.GetSubtask(subTaskID);              
        }

        if (subTask != null)
            subTask.Complеte();
        else
            Debug.LogWarning("Подзадача не найдена");
    }
}
