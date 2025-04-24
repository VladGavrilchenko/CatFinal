using System;
using UnityEngine;
using UnityEngine.SceneManagement;  
public class SceneChanger : MonoBehaviour
{
    public void LoadFlatScene()
    {
        PlayerPrefs.SetString("LastLoginTime", DateTime.UtcNow.ToString());

        PlayerPrefs.DeleteKey("happines");
        PlayerPrefs.DeleteKey("sleep");
        PlayerPrefs.DeleteKey("hungry");
        PlayerPrefs.DeleteKey("hygiene");
        PlayerPrefs.DeleteKey("Money");

        PlayerPrefs.DeleteKey("Water");
        PlayerPrefs.DeleteKey("Coffee");
        PlayerPrefs.DeleteKey("GasWater");
        PlayerPrefs.DeleteKey("Chicken");
        PlayerPrefs.DeleteKey("Beef");
        PlayerPrefs.DeleteKey("PorkChop");
        PlayerPrefs.DeleteKey("DryKorm");
        PlayerPrefs.DeleteKey("WetKorm");
        PlayerPrefs.DeleteKey("RedFish");
        PlayerPrefs.DeleteKey("MeatStick");
        PlayerPrefs.DeleteKey("DryFish");
        PlayerPrefs.DeleteKey("Shprotiki");

        SceneManager.LoadScene("Flat");
    }
}
