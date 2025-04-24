using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CryptoClickerMinigame : MonoBehaviour
{
    [SerializeField] private TMP_Text cryptoText;
    [SerializeField] private Button cryptoClickerButton;
    [SerializeField] private int minAdd;
    [SerializeField] private int maxAdd;
    [SerializeField] private float updateInterval = 5f;
    private int randomAdd;

    private Money money;
    private float timer;

    void Start()
    {
        money = FindAnyObjectByType<Money>();
        timer = updateInterval;
        UpdateCryptoRate();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            UpdateCryptoRate();
            timer = updateInterval;
        }
    }

    private void UpdateCryptoRate()
    {
        randomAdd = Random.Range(minAdd, maxAdd);

        if (randomAdd < 0)
        {
            cryptoText.text = "-$" + Mathf.Abs(randomAdd);
            cryptoText.color = Color.red;
        }
        else
        {
            cryptoText.text = "+$" + randomAdd;
            cryptoText.color = Color.green;
        }
    }

    public void CryptoMoneyClicker()
    {
        money.AddMoney(randomAdd);
    }
}
