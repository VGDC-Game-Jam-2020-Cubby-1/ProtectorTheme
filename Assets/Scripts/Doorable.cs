using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Doorable : MonoBehaviour
{
    public AudioClip doorSFX;
    public AudioClip cantOpenSFX;
    private AudioSource audioSrc;

    public bool ROIsOpen = true;
    private bool _IsOpen;
    protected bool IsOpen
    {
        get
        {
            return _IsOpen;
        }
        set
        {
            if (value == IsOpen)
            {
                return;
            }

            ROIsOpen = value;
            SetOpen(value);
            _IsOpen = value;

            // trigger sound
        }
    }

    private Timer closedTimer;
    private Timer cooldownTimer;

    protected virtual void Start()
    {
        closedTimer = new Timer(GetComponentInParent<DoorController>().DoorClosedTime);
        cooldownTimer = new Timer(GetComponentInParent<DoorController>().CooldownTime);

        closedTimer.complete = true;
        cooldownTimer.complete = true;

        IsOpen = true;

        audioSrc = gameObject.GetComponent<AudioSource>();

        // var is_group = GetComponent<DoorGroup>() != null;
        // var has_group = GetComponentInParent<DoorGroup>() != null;
        // var button_active = is_group || !has_group;

        // GetComponentInChildren<DoorCloseButton>().Canvas.SetActive(button_active);
    }

    public abstract void SetOpen(bool isOpen);

    public void TriggerClosed()
    {
        Debug.Log("Triggering the Close!");
        Debug.Log("Attempt close");

        if (!cooldownTimer.complete)
        {
            Debug.LogFormat("Cannot close door, cooldown has {0} remaining", cooldownTimer.countdown);
            audioSrc.PlayOneShot(cantOpenSFX);
            return;
        }
        audioSrc.PlayOneShot(doorSFX);
        IsOpen = false;
        closedTimer.complete = false;
        cooldownTimer.complete = false;
    }

    public void Update()
    {
        if (closedTimer.tick(true))
        {
            IsOpen = true;
        }

        cooldownTimer.tick(IsOpen);
    }
}
