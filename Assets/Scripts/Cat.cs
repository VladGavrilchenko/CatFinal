using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public float sleep;
    public float happines;
    public float hungry;
    public float hygiene;

    public float subtractValue = 0.01f;
    public Slider sleepSlider;
    public Slider happinesSlider;
    public Slider hungrySlider;
    public Slider hygieneSlider;

    private SleepChecker sleepChecker;

    void Awake()
    {
        sleepSlider.maxValue = 100;
        happinesSlider.maxValue = 100;
        hungrySlider.maxValue = 100;
        hygieneSlider.maxValue = 100;
        sleepChecker = FindAnyObjectByType<SleepChecker>();

        if (PlayerPrefs.HasKey("happines") == false)
        {
            happines =100;
        }
        else
        {
            happines = PlayerPrefs.GetFloat("happines");
        }

        if (PlayerPrefs.HasKey("sleep") == false)
        {
            sleep = 100;
        }
        else
        {
            sleep = PlayerPrefs.GetFloat("sleep");
        }


        if (PlayerPrefs.HasKey("hungry") == false)
        {
            hungry =100;
        }
        else
        {
            hungry = PlayerPrefs.GetFloat("hungry");
        }
        if (PlayerPrefs.HasKey("hygiene") == false)
        {
            hygiene = 100;
        }
        else
        {
            hygiene = PlayerPrefs.GetFloat("hygiene");

        }

    }

    void Update()
    {
        if (sleepChecker.GetIsSleep() == false)
        {
            sleep -= subtractValue * Time.deltaTime;
        }
        else
        {
            sleep += subtractValue * Time.deltaTime;
        }        


        hungry -= subtractValue * Time.deltaTime;
        happines -= subtractValue * Time.deltaTime;
        hygiene -= subtractValue * Time.deltaTime;

        sleep = Mathf.Clamp(sleep, 0, 100);
        hungry = Mathf.Clamp(hungry, 0, 100);
        happines = Mathf.Clamp(happines, 0, 100);
        hygiene = Mathf.Clamp(hygiene, 0, 100);

        happinesSlider.value = happines;
        sleepSlider.value = sleep;
        hungrySlider.value = hungry;
        hygieneSlider.value = hygiene;
    }

    public void AddHungry(float addToHungry)
    {
        hungry += addToHungry;

        if(hungry > 100)
        {
            hungry = 100;
        }
    }
    public void DecreaseNeeds(float hungryLoss, float happinessLoss, float hygieneLoss , float sleepLoss)
    {
        hungry = Mathf.Clamp(hungry - hungryLoss, 0, 100);
        happines = Mathf.Clamp(happines - happinessLoss, 0, 100);
        hygiene = Mathf.Clamp(hygiene - hygieneLoss, 0, 100);

        if(sleepLoss > 0)
        {
            sleep = Mathf.Clamp(sleep - sleepLoss, 0, 100);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("happines", happines);
        PlayerPrefs.SetFloat("sleep", sleep);
        PlayerPrefs.SetFloat("hungry", hungry);
        PlayerPrefs.SetFloat("hygiene", hygiene);
    }


    private void OnApplicationQuit()
    {
        Save();
    }

    public void RecoverSleep(float amount)
    {
        sleep = Mathf.Clamp(sleep + amount, 0, 100);
    }
}
