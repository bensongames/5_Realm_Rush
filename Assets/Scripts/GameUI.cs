using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    [SerializeField] private GameObject _menuUI;
    [SerializeField] private GameObject _gameUI;
    [SerializeField] private Text _playerHealthText;
    [SerializeField] private Text _gameScoreText;
    [SerializeField] private Text _gameOverText;
    [Range(1, 100)] [SerializeField] private int _maxPlayerHealth = 10;
    private int _playerHealth = 0;
    private int _gameScore = 0;


    private void OnEnable()
    {
        GameEventManager.OnGameStart += ShowGameUI;
        GameEventManager.OnGameStart += ResetGameScore;
        GameEventManager.OnGameStart += ResetPlayerHealth;               
        GameEventManager.OnIncreaseScore += IncreaseScore;
        GameEventManager.OnDecrementHealth += DecrementPlayerHealth;
        GameEventManager.OnGameOver += ShowMenuUI;
        GameEventManager.OnGameOver += ShowGameOverText;
    }

    private void OnDisable()
    {
        GameEventManager.OnGameStart -= ShowGameUI;
        GameEventManager.OnGameStart -= ResetGameScore;
        GameEventManager.OnGameStart -= ResetPlayerHealth;
        GameEventManager.OnIncreaseScore -= IncreaseScore;
        GameEventManager.OnDecrementHealth -= DecrementPlayerHealth;
        GameEventManager.OnGameOver -= ShowMenuUI;
        GameEventManager.OnGameOver -= ShowGameOverText;
    }

    private void Start()
    {
        _gameOverText.enabled = false;
        ShowMenuUI();
    }

    private void IncreaseScore(int increaseAmount)
    {
        _gameScore += increaseAmount;
        DisplayGameScore();
    }

    private void ResetGameScore()
    {
        _gameScore = 0;
        DisplayGameScore();
    }

    private void DisplayGameScore()
    {
        _gameScoreText.text = $"SCORE {_gameScore}"; 
    }

    private void DecrementPlayerHealth(int decrementAmount)
    {
        _playerHealth -= decrementAmount;
        if (_playerHealth <= 0)
        {
            _playerHealth = 0; // ensure a negative value isn't shown
            GameEventManager.GameOver();
        }
        DisplayPlayerHealth();       
    }

    private void ResetPlayerHealth()
    {
        _playerHealth = _maxPlayerHealth;
        DisplayPlayerHealth();
    }

    private void DisplayPlayerHealth()
    {
        _playerHealthText.text = $"HEALTH {_playerHealth}"; 
    }

    private void ShowMenuUI()
    {
        _menuUI.SetActive(true);
        _gameUI.SetActive(false);
    }

    private void ShowGameUI()
    {
        _menuUI.SetActive(false);
        _gameUI.SetActive(true);
    }

    private void ShowGameOverText()
    {
        _gameOverText.enabled = true;
        _gameOverText.text = $"Game Over Score: {_gameScore}";
    }


}
