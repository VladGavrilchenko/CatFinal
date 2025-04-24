using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HygieneButton : MonoBehaviour
{
    Cat cat;
    public Slider hygieneSlider;
    public Button hygieneButton;  

    public float incrementAmount = 10f;  

    void Start()
    {
        cat = FindAnyObjectByType<Cat>();
        hygieneButton.onClick.AddListener(ButtonClick);


        hygieneSlider.value = 100f;
    }

    

    public void ButtonClick()
    {
        cat.hygiene += incrementAmount;
   }
}
