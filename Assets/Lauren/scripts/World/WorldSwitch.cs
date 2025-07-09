using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;

public class WorldSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera overworldCam;
    public CinemachineVirtualCamera underworldCam;

    private bool inUnderworld = false;

    void Start()
    {
        // Ensure correct starting state
        overworldCam.Priority = 10;
        underworldCam.Priority = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            inUnderworld = !inUnderworld;

            if (inUnderworld)
            {
                overworldCam.Priority = 0;
                underworldCam.Priority = 10;
            }
            else
            {
                overworldCam.Priority = 10;
                underworldCam.Priority = 0;
            }
        }
    }
}
