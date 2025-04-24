using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Money : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    private int money;

    void Start()
    {
        if (PlayerPrefs.HasKey("Money") == false)
        {
            PlayerPrefs.SetInt("Money", 100);
        }
        
        money = PlayerPrefs.GetInt("Money");
        moneyText.text = "" + money;
    }

    public void SubtractMoney(int subMoney)
    {
        money -= subMoney;
        PlayerPrefs.SetInt("Money", money);
        moneyText.text = "" + money;
    }

    public void AddMoney(int addMoney)
    {
        money += addMoney;
        PlayerPrefs.SetInt("Money", money);
        moneyText.text = "" + money;
    }


    public int GetMoney()
    {
        return money;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Money", money);
    }

    public void RandomMoney(int RandomMoney)
    {
        int value = Random.Range(-100, 100);
        money += value;
        PlayerPrefs.SetInt("Money", money);
        moneyText.text = "" + money;
    }
}
