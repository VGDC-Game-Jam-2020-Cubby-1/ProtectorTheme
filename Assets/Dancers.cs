using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancers : MonoBehaviour
{
    public bool Dance1 = true;
    private DancingChef[] dancers;

    string GetDance(bool dance)
    {
        if (dance)
        {
            return Chef.ANIMATOR_DANCE;
        }
        return "Robot";
    }

    void Start()
    {
        dancers = GetComponentsInChildren<DancingChef>();
    }

    void Update()
    {

        foreach (DancingChef dancer in dancers)
        {
            dancer.animator.SetTrigger(GetDance(Dance1));
            dancer.animator.ResetTrigger(GetDance(!Dance1));
        }
    }
}
