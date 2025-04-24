using UnityEngine;
using UnityEngine.UI;
public class HappinessSlider : MonoBehaviour
{
    private Cat cat; 
    public Button happinessButton;

    private void Start()
    {
        cat = FindAnyObjectByType<Cat>();
        if (happinessButton != null)
        {
            happinessButton.onClick.AddListener(IncreaseHappiness); 
        }

       

    }



    
    private void IncreaseHappiness()
    {
        cat.happines += 10;
        PlayerPrefs.SetFloat("happines", cat.happines);
    }
}
