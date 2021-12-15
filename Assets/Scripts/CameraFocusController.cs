using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraFocusController : MonoBehaviour
{
    void Start()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFocusMode(FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

        //Application.targetFrameRate = 30;
    }

    void Update()
    {
        
    }
}
