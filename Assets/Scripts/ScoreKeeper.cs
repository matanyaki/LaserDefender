using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;
    public static ScoreKeeper instance;

    void Awake()
    {
        MakeSingleton();
    }
    void MakeSingleton()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Another instance of ScoreKeeper found, destroying this one.");
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Setting this as the Singleton instance.");
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
    public void ResetScore()
    {
        score = 0;
    }
}
