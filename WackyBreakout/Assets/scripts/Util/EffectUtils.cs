using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EffectUtils
{
    static SpeedUpEffectMonitor speedUpEffectMonitor;
    public static bool SpeedUpEffectActive
    {
        get { return speedUpEffectMonitor.SpeedUpEffectActive; }
    }
    public static float SpeedUpEffectSecondsLeft
    {
        get { return speedUpEffectMonitor.SpeedUpEffectSecondsLeft; }
    }
}
