using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightActivation : MonoBehaviour
{
    [Header("obj references")]
    public WeightActivation otherButton;
    public GameObject blockade;

    private SpriteRenderer sr;
    private bool isPressed = false;
    private bool permanentlyActivated = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (permanentlyActivated) return;

        if (collision.CompareTag("Player"))
        {
            isPressed = true;
            sr.color = Color.green;

            CheckBothButtons();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (permanentlyActivated) return;

        if (collision.CompareTag("Player"))
        {
            isPressed = false;
            sr.color = Color.red;
        }
    }

    void CheckBothButtons()
    {
        if (isPressed && otherButton != null && otherButton.IsPressed())
        {
            if (blockade != null)
                blockade.SetActive(false);

            permanentlyActivated = true;
            otherButton.permanentlyActivated = true;

            sr.color = Color.green;
            otherButton.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    public bool IsPressed()
    {
        return isPressed || permanentlyActivated;
    }
}