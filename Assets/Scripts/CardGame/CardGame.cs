using Naninovel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardGame : MonoBehaviour
{
    [SerializeField] private CardSpawner _spawner;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private float _gameDuration = 120f;
    [SerializeField] private float _timeFlip = 1.5f;

    private List<Card> _cards = new List<Card>();
    private Card _firstSelectedCard;
    private Card _secondSelectedCard;
    private int _matchedPairs = 0;
    private int _totalPairs;
    private bool _isInputLocked = false;
    private float _remainingTime;
    private bool _gameEnded = false;
    private WaitForSeconds _waitTimeFlip;

    private UniTaskCompletionSource<bool> _gameCompletionSource;

    public UniTask<bool> PlayGameAsync()
    {
        _gameCompletionSource = new UniTaskCompletionSource<bool>();
        StartGame();
        return _gameCompletionSource.Task;
    }

    private void StartGame()
    {
        _cards = _spawner.SpawnCards();
        _totalPairs = _cards.Count / 2;
        _matchedPairs = 0;
        _waitTimeFlip = new WaitForSeconds(_timeFlip);
        _remainingTime = _gameDuration;
        _gameEnded = false;

        foreach (var card in _cards)
        {
            card.OnCardSelected += OnCardSelected;
        }

        _exitButton.onClick.AddListener(OnExitButtonClicked);
        StartCoroutine(GameTimer());
    }

    private void OnCardSelected(Card selectedCard)
    {
        if (_isInputLocked || selectedCard.IsFlipped)
            return;

        selectedCard.Flip();

        if (_firstSelectedCard == null)
        {
            _firstSelectedCard = selectedCard;
        }
        else
        {
            _secondSelectedCard = selectedCard;
            _isInputLocked = true;
            StartCoroutine(CheckForMatch());
        }
    }

    private IEnumerator CheckForMatch()
    {
        yield return _waitTimeFlip;

        if (_firstSelectedCard.Type == _secondSelectedCard.Type)
        {
            _matchedPairs++;
            _firstSelectedCard.DisableInteraction();
            _secondSelectedCard.DisableInteraction();

            if (_matchedPairs >= _totalPairs)
            {
                EndGame(true);
            }
        }
        else
        {
            _firstSelectedCard.ShowBack();
            _secondSelectedCard.ShowBack();
        }

        _firstSelectedCard = null;
        _secondSelectedCard = null;
        _isInputLocked = false;
    }

    private IEnumerator GameTimer()
    {
        while (_remainingTime > 0f && !_gameEnded)
        {
            _remainingTime -= Time.deltaTime;
            UpdateTimerUI();
            yield return null;
        }

        if (!_gameEnded)
        {
            EndGame(false);
        }
    }

    private void UpdateTimerUI()
    {
        TimeSpan time = TimeSpan.FromSeconds(_remainingTime);
        _timerText.text = time.ToString(@"mm\:ss");
    }

    private void OnExitButtonClicked()
    {
        if (!_gameEnded)
        {
            EndGame(false);
        }
    }

    private void EndGame(bool isSuccess)
    {
        _gameEnded = true;
        StopAllCoroutines();

        foreach (var card in _cards)
        {
            card.OnCardSelected -= OnCardSelected;
        }

        _exitButton.onClick.RemoveListener(OnExitButtonClicked);

        _gameCompletionSource?.TrySetResult(isSuccess);
    }
}