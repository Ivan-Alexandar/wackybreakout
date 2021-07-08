using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedUpEffectMonitor : MonoBehaviour
{


    Timer speedUpEffectTimer;
    float speedUpFactor;


    public bool SpeedUpEffectActive
    {
        get { return speedUpEffectTimer.Running; }
    }
    public float SpeedUpEffectSecondsLeft
    {
        get { return speedUpEffectTimer.SecondsLeft; }
    }
    public float SpeedUpFactor
    {
        get { return speedUpFactor; }
    }
    // Start is called before the first frame update
    void Start()
    {
        speedUpEffectTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpEffectListener(HandleSpeedUpEffectActivatedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        if (speedUpEffectTimer.Finished)
        {
            speedUpEffectTimer.Stop();
            speedUpFactor = 1;
        }
    }
    /// <summary>
    /// Handles the SpeedUpEffectActivatedEvent
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="speedUpFactor"></param>
    void HandleSpeedUpEffectActivatedEvent(float duration, float speedUpFactor)
    {
        if (!speedUpEffectTimer.Running)
        {
            this.speedUpFactor = speedUpFactor;
            speedUpEffectTimer.Duration = duration;
            speedUpEffectTimer.Run();
        }
        else
        {
            speedUpEffectTimer.AddTime(duration);
        }
    }
}
