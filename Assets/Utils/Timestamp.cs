using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timestamp : MonoBehaviour
{

    public static string lastTimestamAtFrameStartString;
    public static long lastTimestamAtFrameStartMilliseconds;


    public static string GetTimestamp()
    {
        return DateTime.UtcNow.ToString(format: "yyyy-MM-dd' 'HH:mm:ss.fff");
    }

    public static long GetTimestampMilliseconds()
    {
        return DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    }


    public void FixedUpdate()
    {
        lastTimestamAtFrameStartString = GetTimestamp();
        lastTimestamAtFrameStartMilliseconds = GetTimestampMilliseconds();
    }
}
