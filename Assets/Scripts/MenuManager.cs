using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject StartImage;
    public void PlayLevel1()
    {

        //Show start image, start level 3s after that
        StartImage.SetActive(true);
        Invoke ("StartLevel1",5f);
        Debug.Log("Scenemanager loadscene Level1");
    }

public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Scenemanager Quit Painettu");
    }

    public void OptionsMenu()
    {
        //SceneManager.LoadScene("OptionsMenu");
        Debug.Log("Scenemanager Options Painettu");
    }

public void StartLevel1()
    {
    SceneManager.LoadScene("Level1");
    }
}
