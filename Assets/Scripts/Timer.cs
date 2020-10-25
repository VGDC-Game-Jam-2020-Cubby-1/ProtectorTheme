using UnityEngine;

public class Timer
{
    private readonly float COUNTDOWN;
    public float countdown { get; private set; }

    public Timer(float COUNTDOWN)
    {
        this.COUNTDOWN = COUNTDOWN;
        complete = false;
    }

    public bool complete
    {
        get
        {
            return countdown <= 0f;
        }
        set
        {
            if (value)
            {
                countdown = -1f;
            }
            else
            {
                countdown = COUNTDOWN;
            }
        }
    }

    public bool tick(bool isValid)
    {
        if (isValid)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            complete = false;
        }

        return complete;
    }
}
