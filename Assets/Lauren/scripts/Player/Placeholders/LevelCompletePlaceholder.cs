using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletePlaceholder : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Level done");
            Time.timeScale = 0f;
            // Invoke("CompleteLevel", 2f); go next level
        }
    }

    private void CompleteLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
