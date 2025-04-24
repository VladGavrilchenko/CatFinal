using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Button yourButton; // ������ �� ������


    void Start()
    {
        // ���������, ��� ������ �� ����� � ��������� ��������
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);
        }
    }


    void OnButtonClick()
    {
        // ��������, ������� ���������� ��� ������� ������
        Debug.Log("������ ���� ������!");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
