using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject Credits;

    public GameObject Main;

    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void ShowCredits()
    {
        Credits.SetActive(true);
        Main.SetActive(false);
    }

    public void ReturnToMain()
    {
        Main.SetActive(true);
        Credits.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
