using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class WorldSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    public Transform PlayerOverworld;
    public Transform PlayerUnderworld;

    private bool inUnderworld = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            inUnderworld = !inUnderworld;

            if (inUnderworld)
            {
                virtualCam.Follow = PlayerUnderworld;
                virtualCam.LookAt = PlayerUnderworld;
                virtualCam.transform.rotation = Quaternion.Euler(0, 0, 180);
            }

            else
            {
                virtualCam.Follow = PlayerOverworld;
                virtualCam.LookAt = PlayerOverworld;
                virtualCam.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}

