using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{

    public static bool GamePause = false;

    public GameObject pauseMenu;
    public GameObject GunPause;
    public GameObject CameraPause;



    void Update()

    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            if (GamePause)

            {
                Resume();
            }
            else
            {

                Pause();
            }

        }

    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GunPause.GetComponent<Gun>().enabled = true;
        CameraPause.GetComponent<CameraController>().enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GunPause.GetComponent<Gun>().enabled = false;
        CameraPause.GetComponent<CameraController>().enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void PauseOut()
    {
        pauseMenu.SetActive(true);
        Cursor.visible = false;
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void Quit()
    {
        Application.Quit();                   
    }

}