using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private float maxInactiveTime = 259200f; 

    private void Start()
    {
        if (PlayerPrefs.HasKey("LastLoginTime") ==false)
        {
            PlayerPrefs.SetString("LastLoginTime", DateTime.UtcNow.ToString());
            return;
        }

        string lastLoginTimeString = PlayerPrefs.GetString("LastLoginTime", DateTime.UtcNow.ToString());
        DateTime lastLoginTime = DateTime.Parse(lastLoginTimeString);

       
        TimeSpan timeSinceLastLogin = DateTime.UtcNow - lastLoginTime;

      
        if (timeSinceLastLogin.TotalSeconds > maxInactiveTime)
        {
            TriggerGameOver();
        }
        else
        {
            
            PlayerPrefs.SetString("LastLoginTime", DateTime.UtcNow.ToString());
        }
    }

    private void TriggerGameOver()
    {
        PlayerPrefs.SetString("LastLoginTime", DateTime.UtcNow.ToString());

        PlayerPrefs.DeleteKey("hungry");
        PlayerPrefs.DeleteKey("hygiene");
        PlayerPrefs.DeleteKey("happines");
        PlayerPrefs.DeleteKey("sleep");
        PlayerPrefs.DeleteKey("Money");

        SceneManager.LoadScene("GameOver");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastLoginTime", DateTime.UtcNow.ToString());
    }
}
