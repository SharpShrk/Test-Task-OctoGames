using UnityEngine;

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card Game/Card Data")]
public class CardData : ScriptableObject
{
    public CardType Type;
    public Sprite FrontSprite;
    public Sprite BackSprite;
}