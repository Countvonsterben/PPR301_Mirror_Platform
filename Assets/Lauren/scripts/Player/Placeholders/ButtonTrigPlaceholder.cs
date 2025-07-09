using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigPlaceholder : MonoBehaviour
{
    public GameObject doorActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (doorActivate != null)
                doorActivate.SetActive(true);

            Destroy(gameObject);
        }
    }
}
