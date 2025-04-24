using System;
using UnityEngine;

public class NeedsChecker : MonoBehaviour
{
    private float hunger;
    private float hygiene;
    private float happiness;

    [SerializeField] private float maxHunger = 100f;
    [SerializeField] private float maxHygiene = 100f;
    [SerializeField] private float maxHappiness = 100f;

    [SerializeField] private float hungerDecayRate = 0.1f; 
    [SerializeField] private float hygieneDecayRate = 0.05f; 
    [SerializeField] private float happinessDecayRate = 0.05f; 

    private DateTime lastSaveTime;

    private void Start()
    {
        
        hunger = PlayerPrefs.GetFloat("Hunger", maxHunger);
        hygiene = PlayerPrefs.GetFloat("Hygiene", maxHygiene);
        happiness = PlayerPrefs.GetFloat("Happiness", maxHappiness);

       
        string lastSaveTimeString = PlayerPrefs.GetString("LastSaveTime", DateTime.UtcNow.ToString());
        lastSaveTime = DateTime.Parse(lastSaveTimeString);

       
        TimeSpan timePassed = DateTime.UtcNow - lastSaveTime;

        
        UpdateNeeds(timePassed);

        
        PlayerPrefs.SetString("LastSaveTime", DateTime.UtcNow.ToString());
    }

    private void Update()
    {
        
        hunger = Mathf.Max(0, hunger - hungerDecayRate * Time.deltaTime);
        hygiene = Mathf.Max(0, hygiene - hygieneDecayRate * Time.deltaTime);
        happiness = Mathf.Max(0, happiness - happinessDecayRate * Time.deltaTime);

        
        PlayerPrefs.SetFloat("Hunger", hunger);
        PlayerPrefs.SetFloat("Hygiene", hygiene);
        PlayerPrefs.SetFloat("Happiness", happiness);

        
        Debug.Log($"Hunger: {hunger}, Hygiene: {hygiene}, Happiness: {happiness}");
    }

    
    private void UpdateNeeds(TimeSpan timePassed)
    {
       
        hunger = Mathf.Max(0, hunger - (float)(hungerDecayRate * timePassed.TotalSeconds));
        hygiene = Mathf.Max(0, hygiene - (float)(hygieneDecayRate * timePassed.TotalSeconds));
        happiness = Mathf.Max(0, happiness - (float)(happinessDecayRate * timePassed.TotalSeconds));

       
        PlayerPrefs.SetFloat("Hunger", hunger);
        PlayerPrefs.SetFloat("Hygiene", hygiene);
        PlayerPrefs.SetFloat("Happiness", happiness);
    }

   
    public void FeedCat(float amount)
    {
        hunger = Mathf.Min(hunger + amount, maxHunger);
        PlayerPrefs.SetFloat("Hunger", hunger);
        Debug.Log("Cat has been fed. Hunger: " + hunger);
    }

    public void CleanCat(float amount)
    {
        hygiene = Mathf.Min(hygiene + amount, maxHygiene);
        PlayerPrefs.SetFloat("Hygiene", hygiene);
        Debug.Log("Cat has been cleaned. Hygiene: " + hygiene);
    }

    public void PlayWithCat(float amount)
    {
        happiness = Mathf.Min(happiness + amount, maxHappiness);
        PlayerPrefs.SetFloat("Happiness", happiness);
        Debug.Log("Cat is playing. Happiness: " + happiness);
    }

    
    public void ResetNeeds()
    {
        hunger = maxHunger;
        hygiene = maxHygiene;
        happiness = maxHappiness;

        PlayerPrefs.SetFloat("Hunger", hunger);
        PlayerPrefs.SetFloat("Hygiene", hygiene);
        PlayerPrefs.SetFloat("Happiness", happiness);

        Debug.Log("Needs have been reset.");
    }
}
