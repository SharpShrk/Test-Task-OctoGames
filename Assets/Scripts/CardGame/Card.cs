using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using System;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _frontImage;
    [SerializeField] private Image _backImage;
    [SerializeField] private Button _flipButton;
    
    private CardType _type;
    private bool _isFlipped = false;

    public event Action<Card> OnCardSelected;

    public CardType Type => _type;
    public bool IsFlipped => _isFlipped;

    private void OnEnable()
    {
        _flipButton.onClick.AddListener(OnButtonFlipClick);
    }

    private void OnDisable()
    {
        _flipButton.onClick.RemoveListener(OnButtonFlipClick);
    }

    public void Initialize(CardData data)
    {
        _type = data.Type;
        _frontImage.sprite = data.FrontSprite;
        _backImage.sprite = data.BackSprite;

        _frontImage.gameObject.SetActive(false);
        _backImage.gameObject.SetActive(true);
    }

    public void Flip()
    {
        _isFlipped = true;

        transform.DOScaleX(0f, 0.2f).OnComplete(() =>
        {
            _isFlipped = true;
            _frontImage.gameObject.SetActive(true);
            _backImage.gameObject.SetActive(false);
            transform.DOScaleX(1f, 0.2f);
        });
    }

    public void ShowBack()
    {
        _isFlipped = false;

        transform.DOScaleX(0f, 0.2f).OnComplete(() =>
        {
            _frontImage.gameObject.SetActive(false);
            _backImage.gameObject.SetActive(true);
            transform.DOScaleX(1f, 0.2f);
        });
    }

    public void DisableInteraction()
    {
        _flipButton.interactable = false;
    }

    private void OnButtonFlipClick()
    {
        OnCardSelected?.Invoke(this);
    }
}