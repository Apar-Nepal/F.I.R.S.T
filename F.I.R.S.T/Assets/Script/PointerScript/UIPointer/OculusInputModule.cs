using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusInputModule : VRInputModule
{
    public OVRInput.Button clickButton = OVRInput.Button.PrimaryIndexTrigger;
    public OVRInput.Controller controller = OVRInput.Controller.All;

    public override void Process()
    {
        base.Process();

        if (OVRInput.GetDown(clickButton, controller))
        {
            ProcessPress(m_Data);
        }


        if (OVRInput.GetUp(clickButton, controller))
        {
            ProcessRelease(m_Data);
        }
    }
}
