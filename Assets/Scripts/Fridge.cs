using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fridge : MonoBehaviour
{
    public GameObject PanelFridge;
    private bool isActivePanel;

    void Start()
    {
        PanelFridge.SetActive(isActivePanel);
    }

    public void OpenFridge()
    {
        isActivePanel = !isActivePanel;
        PanelFridge.SetActive(isActivePanel);
    }
}
