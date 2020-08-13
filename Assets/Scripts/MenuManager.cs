using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
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
}
