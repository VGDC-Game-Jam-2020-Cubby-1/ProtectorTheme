using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Door[] Doors;
    private DoorGroup[] DoorGroups;

    void Start()
    {
        Doors = GetComponentsInChildren<Door>();
        DoorGroups = GetComponentsInChildren<DoorGroup>();
    }
}
