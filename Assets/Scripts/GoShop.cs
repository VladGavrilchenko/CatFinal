using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoShop : MonoBehaviour
{
    [SerializeField] Cat cat;
    public void GoToShop()
    {
        cat.Save();
        SceneManager.LoadScene("Shop");
    }
}
