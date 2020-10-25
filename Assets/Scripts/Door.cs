using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public DoorSide LeftDoor;
    public DoorSide RightDoor;
    public GameObject NavMeshObstacle;
    public bool IsOpen = true;

    void Start()
    {
    }

    void SetOpen(bool isOpen)
    {
        LeftDoor.SetOpen(isOpen);
        RightDoor.SetOpen(isOpen);

        // play sound

        NavMeshObstacle.SetActive(isOpen);
    }

    void Update()
    {
        SetOpen(IsOpen);
    }
}
