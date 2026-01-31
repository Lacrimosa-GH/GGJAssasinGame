using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   
    public void Play()
    {
        SceneManager.LoadScene("HospitalLevel");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    public void QuitGame()
    {
        Application.Quit();
    }
}

