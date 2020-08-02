using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public delegate void GameActionDelegate();
    public static GameActionDelegate OnGameStart;
    public static GameActionDelegate OnGameOver;

    public delegate void UpdateGameUIDelegate(int amount);
    public static UpdateGameUIDelegate OnDecrementHealth;
    public static UpdateGameUIDelegate OnIncreaseScore;

    public static void GameStart()
    {
        if (OnGameStart != null) // Check for subscribers
        {
            OnGameStart();
        }
    }

    public static void GameOver()
    {
        if (OnGameOver != null) // Check for subscribers
        {
            OnGameOver();
        }
    }

    public static void DecrementHealth(int decrementAmount)
    {
        if (OnDecrementHealth != null) // Check for subscribers
        {
            OnDecrementHealth(decrementAmount);
        }
    }

    public static void IncreaseScore(int increaseAmount)
    {
        if (OnIncreaseScore != null) // Check for subscribers
        {
            OnIncreaseScore(increaseAmount);
        }
    }

}
