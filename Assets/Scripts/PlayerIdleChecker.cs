using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Globalization;

public class PlayerIdleChecker : MonoBehaviour
{
    public string loseSceneName = "GameOver";
    public int idleThresholdInDays = 3;
    private const string dateFormat = "yyyy-MM-dd HH:mm:ss";

    private void Start()
    {
        if (PlayerPrefs.HasKey("LastLoginTime"))
        {
            UpdateLastLoginTime();
        }

        CheckPlayerIdleTime();
        UpdateLastLoginTime();
    }

    private void CheckPlayerIdleTime()
    {
        string lastLoginStr = PlayerPrefs.GetString("LastLoginTime");
        DateTime lastLoginTime;

        if (DateTime.TryParseExact(lastLoginStr, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out lastLoginTime))
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan idleTime = currentTime - lastLoginTime;

            Debug.Log($"Current Time: {currentTime}, Last Login Time: {lastLoginTime}, Idle Time: {idleTime.TotalDays} days");

            if (idleTime.TotalDays >= idleThresholdInDays)
            {
                LoadLoseScene();
            }
        }
        
    }

    private void UpdateLastLoginTime()
    {
        string currentTimeStr = DateTime.Now.ToString(dateFormat, CultureInfo.InvariantCulture);
        PlayerPrefs.SetString("LastLoginTime", currentTimeStr);
        PlayerPrefs.Save();
    }

    private void LoadLoseScene()
    {
        SceneManager.LoadScene(loseSceneName);
    }

    private void OnApplicationQuit()
    {
        UpdateLastLoginTime();
    }
}
