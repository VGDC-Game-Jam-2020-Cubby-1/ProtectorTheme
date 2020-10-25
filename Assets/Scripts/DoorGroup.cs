using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup : Doorable
{
    private Door[] Doors;

    void Awake()
    {
        Doors = this.GetComponentsInDirectChildren<Door>();
    }

    public override void SetOpen(bool isOpen)
    {
        if (Doors == null)
        {
            Debug.Log("Null Doors");
            return;
        }

        foreach (Door door in Doors)
        {
            door.SetOpen(isOpen);
        }
    }
}
