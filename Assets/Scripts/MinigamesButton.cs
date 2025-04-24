using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigamesButton : MonoBehaviour
{
    public GameObject PanelMinigames;
    private bool isActivePanel;

    void Start()
    {
        PanelMinigames.SetActive(isActivePanel);
    }

    public void OpenMinigames()
    {
        isActivePanel = !isActivePanel;
        PanelMinigames.SetActive(isActivePanel);
    }
}
