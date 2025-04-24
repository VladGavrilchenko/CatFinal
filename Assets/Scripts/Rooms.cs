using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    private SleepChecker sleepChecker;
    public GameObject Kitchen;
    public GameObject Bedroom;
    public GameObject BAthroom;
    public GameObject Playroom;
    private GameObject currentRoom;

    void Start()
    {
        sleepChecker = FindAnyObjectByType<SleepChecker>();
        currentRoom = Playroom;
        Kitchen.SetActive(false);
        Bedroom.SetActive(false);
        BAthroom.SetActive(false);
        Playroom.SetActive(true);  
    }

    public void GoToKitchen()
    {
        if(currentRoom.Equals(Kitchen))
        {
            return;
        }

        currentRoom.SetActive(false);
        currentRoom = Kitchen;
        currentRoom.SetActive(true);
        sleepChecker.ResetSleep();
    }
    public void GoToBedroom()
    {
        if (currentRoom.Equals(Bedroom))
        {
            return;
        }

        currentRoom.SetActive(false);
        currentRoom = Bedroom;
        currentRoom.SetActive(true);
        sleepChecker.ResetSleep();
    }
    public void GoToBAthroom()
    {
        if (currentRoom.Equals(BAthroom))
        {
            return;
        }

        currentRoom.SetActive(false);
        currentRoom = BAthroom;
        currentRoom.SetActive(true);
        sleepChecker.ResetSleep();
    }
    public void GoToPlayroom()
    {
        if (currentRoom.Equals(Playroom))
        {
            return;
        }

        currentRoom.SetActive(false);
        currentRoom = Playroom;
        currentRoom.SetActive(true);
        sleepChecker.ResetSleep();
    }
}
