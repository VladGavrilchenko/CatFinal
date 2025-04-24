using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ProduktText;
    [SerializeField] int minPrice;
    [SerializeField] int maxPrice;
    int Price;
    [SerializeField] string name;
    [SerializeField] int count;
    [SerializeField] TMP_Text countText;
    [SerializeField] TMP_Text priceText;
    private Money money;
    // Start is called before the first frame update
    void Start()
    {
        ProduktText.text = name;
       Price =  Random.Range(minPrice, maxPrice);
        priceText.text = "" + Price;
        countText.text = "" + count;
        money = FindAnyObjectByType<Money>();
    }

    public void Interactable()
    {
        
        if (money.GetMoney() >= Price && count > 0)
        {
            money.SubtractMoney(Price);
            count = count - 1;
            countText.text = "" + count;
            int countProd = PlayerPrefs.GetInt(name);
            countProd++;
            PlayerPrefs.SetInt(name, countProd);
        }

    }

    


    
}
