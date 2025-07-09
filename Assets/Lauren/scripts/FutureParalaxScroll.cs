using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutureParalaxScroll : MonoBehaviour
{
    private Transform cam;
    private Vector3 lastCamPos;
    private Material mat;
    private float textureOffsetX;
    private float fixedY;

    [Range(0.01f, 0.1f)]
    public float parallaxSpeed = 0.08f;

    void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
            mat = renderer.material;
    }

    void LateUpdate()
    {
        if (mat == null || cam == null) return;

        if (Mathf.Approximately(cam.rotation.eulerAngles.z, 180f))
        {
            float deltaX = cam.position.x - lastCamPos.x;
            textureOffsetX += deltaX * parallaxSpeed;
            mat.mainTextureOffset = new Vector2(textureOffsetX, 0);

            transform.position = new Vector3(cam.position.x, cam.position.y, transform.position.z);

        }
        lastCamPos = cam.position;
    }
}
