using System;
using UnityEngine;

public class OnStartParameterChecker: MonoBehaviour
{
    [SerializeField] private float maxLossTime;
    [SerializeField] private float hungryLossRate;
    [SerializeField] private float happinessLossRate;
    [SerializeField] private float hygieneLossRate;
    [SerializeField] private float sleepLossRate;

    private Cat cat;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LastPlayedTime") == false)
        {
            PlayerPrefs.SetString("LastPlayedTime", DateTime.UtcNow.ToString());
        }

        cat = FindObjectOfType<Cat>();
        CheckNeeds();
        PlayerPrefs.SetInt("InGame", 1);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastPlayedTime", DateTime.UtcNow.ToString());
        PlayerPrefs.SetInt("InGame", 0);
    }

    private void CheckNeeds()
    {
        int inGame = PlayerPrefs.GetInt("InGame");

        if (inGame == 1)
        {
            return;
        }

        if (!PlayerPrefs.HasKey("LastPlayedTime")) return;

        string lastPlayedTimeStr = PlayerPrefs.GetString("LastPlayedTime");
        DateTime lastPlayedTime = DateTime.Parse(lastPlayedTimeStr);
        TimeSpan timePassed = DateTime.UtcNow - lastPlayedTime;

        float timeElapsed = Mathf.Min((float)timePassed.TotalSeconds, maxLossTime);

        float hungryLoss = timeElapsed * hungryLossRate;
        float happinessLoss = timeElapsed * happinessLossRate;
        float hygieneLoss = timeElapsed * hygieneLossRate;


       bool isSleep = PlayerPrefs.GetInt("isSleep") == 1;
       float sleepLoss = 0;

       if (isSleep == false)
       {
           sleepLoss = timeElapsed * hygieneLossRate;
       }
       else
       {
            SleepChecker sleepChecker = FindAnyObjectByType<SleepChecker>();
            sleepChecker.CheckSleep();
            sleepChecker.ResetSleep();
       }

        cat.DecreaseNeeds(hungryLoss, happinessLoss, hygieneLoss , sleepLoss);
    }
}