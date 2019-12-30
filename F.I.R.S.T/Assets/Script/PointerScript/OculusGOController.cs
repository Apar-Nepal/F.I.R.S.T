using UnityEngine;

public class OculusGOController : MonoBehaviour
{
    public GameObject m_modelOculusGoController;
    public OVRInput.Controller m_controller;

    private enum ControllerType
    {
        Go
    }

    private ControllerType activeControllerType = ControllerType.Go;

    private bool m_prevControllerConnected = false;
    private bool m_prevControllerConnectedCached = false;

    void Start()
    {
        OVRPlugin.SystemHeadset headset = OVRPlugin.GetSystemHeadsetType();
        switch (headset)
        {
            case OVRPlugin.SystemHeadset.Oculus_Go:
                activeControllerType = ControllerType.Go;
                break;
            default:
#if UNITY_EDITOR || !UNITY_ANDROID
                activeControllerType = ControllerType.Go;
#endif
                break;
        }
    }

    private void Update()
    {
        bool controllerConnected = OVRInput.IsControllerConnected(m_controller);
        m_modelOculusGoController.SetActive(controllerConnected && (activeControllerType == ControllerType.Go));

        m_prevControllerConnected = controllerConnected;
        m_prevControllerConnectedCached = true;

        if (!controllerConnected)
        {
            return;
        }
    }
}
