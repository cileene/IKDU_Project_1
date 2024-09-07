using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to limit the frame rate of the game to a specific value
// Just connect this script to a game object
public class FrameRateLimiter : MonoBehaviour
{
    [Tooltip("The target frame rate, 0 = no limit")]
    public int targetFrameRate = 60;

    [Tooltip("Turn vSync on or off")]
    public bool vSync = false;

    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        if (vSync)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}