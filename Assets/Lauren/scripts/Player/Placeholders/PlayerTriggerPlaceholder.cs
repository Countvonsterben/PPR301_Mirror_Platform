using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerPlaceholder : MonoBehaviour
{
    public GameObject doorActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            Destroy(collision.gameObject);
            doorActivate.SetActive(true);
            Destroy(collision.gameObject);
        }
    }
}
