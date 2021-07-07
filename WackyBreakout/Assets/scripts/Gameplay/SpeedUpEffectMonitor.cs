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
        
    }
    void HandleSpeedUpEffectActivatedEvent(float duration, float speedUpFactor)
    {

    }
}
