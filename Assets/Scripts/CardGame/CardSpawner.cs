using UnityEngine;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private Transform _cardContainer;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private List<CardData> _allCardData;

    private List<Card> _cards = new List<Card>();

    public List<Card> SpawnCards()
    {
        List<CardData> cardPool = new List<CardData>();

        foreach (var data in _allCardData)
        {
            cardPool.Add(data);
            cardPool.Add(data);
        }
       
        Shuffle(cardPool);

        foreach (var data in cardPool)
        {
            GameObject cardObj = Instantiate(_cardPrefab, _cardContainer);
            Card card = cardObj.GetComponent<Card>();
            card.Initialize(data);
            _cards.Add(card);
        }

        return _cards;
    }

    private void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CardData temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}