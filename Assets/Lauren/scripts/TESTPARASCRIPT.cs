using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TESTPARASCRIPT : MonoBehaviour
{
    [Header("world char")]
    public Transform worldPlayer;

    private Vector3 lastPlayerPos;
    private Material mat;
    private float textureOffsetX;

    [Range(0.01f, 0.1f)]
    public float parallaxSpeed = 0.02f;

    [Header("axis test")]
    public bool followX = true;
    public bool followY = false;

    void Start()
    {
        if (worldPlayer == null)
        {
            Debug.LogWarning("Para scroll = player not assigned  CHECK");
            return;
        }

        lastPlayerPos = worldPlayer.position;

        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
            mat = renderer.material;
    }

    void LateUpdate()
    {
        if (mat == null || worldPlayer == null) return;

        float deltaX = worldPlayer.position.x - lastPlayerPos.x;
        if (Mathf.Abs(deltaX) > 0.0001f)
        {
            textureOffsetX += deltaX * parallaxSpeed;
            mat.mainTextureOffset = new Vector2(textureOffsetX, 0);
        }

        Vector3 bgPos = transform.position;
        if (followX) bgPos.x = worldPlayer.position.x;
        if (followY) bgPos.y = worldPlayer.position.y;
        transform.position = bgPos;

        lastPlayerPos = worldPlayer.position;
    }
}
