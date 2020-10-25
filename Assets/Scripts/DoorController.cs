using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float DoorClosedTime = 2.0f;
    public float CooldownTime = 2.0f;

    private Door[] Doors;
    private DoorGroup[] DoorGroups;

    void Awake()
    {
        Doors = this.GetComponentsInDirectChildren<Door>();
        DoorGroups = this.GetComponentsInDirectChildren<DoorGroup>();
    }
}
