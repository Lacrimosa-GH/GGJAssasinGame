using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWinCon
    : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (other.gameObject.CompareTag("lose"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
