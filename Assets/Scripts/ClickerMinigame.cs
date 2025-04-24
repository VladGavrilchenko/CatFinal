using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerMinigame : MonoBehaviour
{
    [SerializeField] private Button clickerButton;
    private Money money;
    // Start is called before the first frame update
    void Start()
    {
        money = FindAnyObjectByType<Money>();
    }


    public void AddMoneyClicker(int AddMoney)
    {
        money.AddMoney(AddMoney);
    }
}
