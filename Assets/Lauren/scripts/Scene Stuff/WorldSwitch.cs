/* using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldSwitch : MonoBehaviour
{
    [SerializeField] public CameraMovement cameraMovement;
    [SerializeField] public Transform overworldPlayer;
    [SerializeField] public Transform underworldPlayer;

    private bool isUnderworldActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isUnderworldActive = !isUnderworldActive;

            if (isUnderworldActive)
            {
                cameraMovement.target = underworldPlayer;
                cameraMovement.transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else
            {
                cameraMovement.target = overworldPlayer;
                cameraMovement.transform.rotation = Quaternion.Euler(0, 0, 0);  // normal rotation
            }
        }
    }
}
*/
