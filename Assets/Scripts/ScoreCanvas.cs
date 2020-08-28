using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCanvas : MonoBehaviour
{
    public static bool ShowScore = false;
    public GameObject ShowScoreCanvas;
    public GameObject SuccessImage;
    public GameObject ReplayImage;
    
    void Start()
    {
        
    }

    // peliajan loppuessa näyttää score canvaksen missä on pelin pistetiedot, lukitsee pelaajan liikkeet odottaa 3 sekuntia (toinen scripti)
    
    void Update()
    {
        if ((GameObject.Find("Sum").GetComponent<sum>().targetTime <= 0) || 
            ((GameObject.Find("Sum").GetComponent<sum>().success == true)) && 
            (GameObject.Find("Player").GetComponent<PlayerController>().inFinishZone == true))
        {
            Pause();
            
        }
    }


    void Pause()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        ShowScoreCanvas.SetActive(true);
        ReplayImage.SetActive(true);
        Time.timeScale = 1f;
        ShowScore = true;
        if ((GameObject.Find("Sum").GetComponent<sum>().success == true) && 
            GameObject.Find("Player").GetComponent<PlayerController>().inFinishZone == true)
        {
            SuccessImage.SetActive(true);
            
        }



    }
    public void ResetLevel()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("replay pressed");
    }

}
