using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalLightState
{
    private readonly static object lockobject = new object();
    private static bool light = false;

    public static bool getLightState()
    {
        return GlobalLightState.light;
    }

    public static void onLight()
    {
        lock (lockobject)
        {
            GlobalLightState.light = true;
        }
    }

    public static void offLight()
    {
        lock (lockobject)
        {
            GlobalLightState.light = false;
        }
    }
}
