using System;
using UnityEngine;
using UnityEngine.UI;

public class SleepChecker : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Image sleepBackgroundImage;
    [SerializeField] private Image sleepImage;
    [SerializeField] private Sprite sleepSprite;
    [SerializeField] private Sprite noSleepSprite;

    [SerializeField] private float maxSleepTime = 18000;
    private bool isSleep;
    private Cat cat;

    private void Start()
    {
        isSleep = PlayerPrefs.GetInt("isSleep") == 1;
        cat = FindObjectOfType<Cat>();
    }

    public void GoSleep()
    {
        isSleep = true;
        PlayerPrefs.SetInt("isSleep", 1);
        PlayerPrefs.SetString("SleepTime", DateTime.UtcNow.ToString());
    }

    private void Update()
    {
        if(animator != null) 
        {
            animator.SetBool("isSleep", isSleep);
        }
    }

    public void SleepButton()
    {
        isSleep = !isSleep;

        if(isSleep)
        {
            sleepImage.sprite = noSleepSprite;
            sleepBackgroundImage.color = Color.gray;
            GoSleep();
        }
        else
        {
            sleepImage.sprite = sleepSprite;
            sleepBackgroundImage.color = Color.yellow;
            ResetSleep();
        }
    }

    public void ResetSleep()
    {
        isSleep = false;
        PlayerPrefs.SetInt("isSleep", 0);
        PlayerPrefs.DeleteKey("SleepTime"); 

        if(sleepImage != null)
        {
            sleepImage.sprite = sleepSprite;
        }
    }

    public void CheckSleep()
    {
        isSleep = PlayerPrefs.GetInt("isSleep") == 1;

        if (isSleep == false) return;
        if (!PlayerPrefs.HasKey("SleepTime")) return;

        string sleepTimeStr = PlayerPrefs.GetString("SleepTime");
        DateTime lastSleepTime = DateTime.Parse(sleepTimeStr);
        TimeSpan timePassed = DateTime.UtcNow - lastSleepTime;

        float timeElapsed = Mathf.Min((float)timePassed.TotalSeconds, maxSleepTime);

        float sleepGained = (timeElapsed / maxSleepTime) * 100;
        sleepGained = Mathf.Clamp(sleepGained, 0, 100); 

        cat.RecoverSleep(sleepGained);
        ResetSleep();
    }

    public bool GetIsSleep()
    {
        return isSleep;
    }
}