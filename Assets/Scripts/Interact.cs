using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public Button yourButton; // —сылка на кнопку


    void Start()
    {
        // ”бедитесь, что кнопка не пуста и назначьте действие
        if (yourButton != null)
        {
            yourButton.onClick.AddListener(OnButtonClick);
        }
    }


    void OnButtonClick()
    {
        // ƒействие, которое выполнитс€ при нажатии кнопки
        Debug.Log(" нопка была нажата!");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
