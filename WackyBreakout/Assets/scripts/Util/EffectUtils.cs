using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EffectUtils
{
    static SpeedUpEffectMonitor GetSpeedUpEffectMonitor
    {
        get { return Camera.main.GetComponent<SpeedUpEffectMonitor>(); }
    }
    public static bool SpeedUpEffectActive
    {
        get { return GetSpeedUpEffectMonitor.SpeedUpEffectActive; }
    }
    public static float SpeedUpEffectSecondsLeft
    {
        get { return GetSpeedUpEffectMonitor.SpeedUpEffectSecondsLeft; }
    }
    public static float SpeedUpFactor
    {
        get { return GetSpeedUpEffectMonitor.SpeedUpFactor; }
    }
}
