using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public GameObject Credits;

    public GameObject Main;

    public Image TitleImage;

    void Update()
    {
        if(Input.anyKeyDown && TitleImage.IsActive())
        {
            TitleImage.gameObject.SetActive(false);
        }
    }

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
