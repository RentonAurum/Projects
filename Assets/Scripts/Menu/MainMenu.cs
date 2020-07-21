using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Livello");
    }

    /*public void Settings()
    {
        SceneManager.LoadScene("ProgettoGameDev");
    }*/

    /*public void Credits()
    {
        SceneManager.LoadScene("ProgettoGameDev");
    }*/

    public void Quit()
    {
        Application.Quit();
    }
}
