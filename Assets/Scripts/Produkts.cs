using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Produkts : MonoBehaviour
{
    [SerializeField] int countFood;
    [SerializeField] float addToHungry;
    [SerializeField] private string foodName;
    [SerializeField] private Cat cat;
    [SerializeField] private TextMeshProUGUI FoodCount;
    // Start is called before the first frame update
    void Start()
    {
        countFood = PlayerPrefs.GetInt(foodName);
    }

    // Update is called once per frame
    void Update()
    {
        FoodCount.text = "" + countFood;
    }
    public void AddToHungry()
    {
        if (countFood > 0)
        {
            cat.AddHungry(addToHungry);
            countFood--;
            PlayerPrefs.SetInt(foodName, countFood);
            PlayerPrefs.Save();
        }
    }
}
