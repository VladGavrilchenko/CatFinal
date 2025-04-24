using System;
using UnityEngine;

public class HungryChecker : MonoBehaviour
{
    [SerializeField] private float maxHungryLossTime = 100;
    [SerializeField] private float hungryLossRate = 1;
    private Cat cat;

    private void Start()
    {
        cat = FindObjectOfType<Cat>();
        CheckHungry();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("LastPlayedTime", DateTime.UtcNow.ToString());
    }

    private void CheckHungry()
    {
        if (!PlayerPrefs.HasKey("LastPlayedTime")) return;

        string lastPlayedTimeStr = PlayerPrefs.GetString("LastPlayedTime");
        DateTime lastPlayedTime = DateTime.Parse(lastPlayedTimeStr);
        TimeSpan timePassed = DateTime.UtcNow - lastPlayedTime;

        float hungryLoss = Mathf.Min((float)timePassed.TotalSeconds, maxHungryLossTime) * hungryLossRate;
        cat.AddHungry(-hungryLoss);
    }
}
