using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Doorable
{
    public DoorSide LeftDoor;
    public DoorSide RightDoor;
    public GameObject NavMeshObstacle;

    public override void SetOpen(bool isOpen)
    {
        LeftDoor.SetOpen(isOpen);
        RightDoor.SetOpen(isOpen);

        NavMeshObstacle.SetActive(!isOpen);
    }
}
