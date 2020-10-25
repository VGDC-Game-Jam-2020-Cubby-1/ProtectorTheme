using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup : MonoBehaviour
{
    public bool IsOpen = true;
    private Door[] Doors;

    void Start()
    {
        Doors = GetComponentsInChildren<Door>();
    }

    void SetOpen(bool isOpen)
    {
        foreach (Door door in Doors)
        {
            door.IsOpen = isOpen;
        }
    }

    void Update()
    {
        SetOpen(IsOpen);
    }
}
