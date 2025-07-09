using UnityEngine;

public class ParalaxScroll : MonoBehaviour
{
    public Transform cam; // assign CM_Overworld here
    private Vector3 lastCamPos;
    private Material mat;
    private float textureOffsetX;

    [Range(0.01f, 0.1f)]
    public float parallaxSpeed = 0.02f;

    void Start()
    {
        if (cam == null)
            cam = Camera.main.transform;

        lastCamPos = cam.position;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
            mat = renderer.material;
    }

    void LateUpdate()
    {
        if (mat == null || cam == null) return;

        float deltaX = cam.position.x - lastCamPos.x;
        textureOffsetX += deltaX * parallaxSpeed;
        mat.mainTextureOffset = new Vector2(textureOffsetX, 0);

        transform.position = new Vector3(cam.position.x, transform.position.y, transform.position.z);

        lastCamPos = cam.position;
    }
}
