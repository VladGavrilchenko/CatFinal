using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public Button Quit;
    public GameObject PanelMiniGame;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        PanelMiniGame.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonQuit()
    {
        isActive =! isActive;
        PanelMiniGame.SetActive(isActive);
    }
}
