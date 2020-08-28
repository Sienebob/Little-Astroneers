using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using JetBrains.Annotations;

public class sum : MonoBehaviour
{
    public int summa = 0;
    

    public int targetSum = 0;
    public Text timerText;
    public float targetTime;
    public Text targetScore;
    public Text yourScore;
    public Text FinalScore;
    public Text FinalSuccess;
    public bool success = false;

    //public GameObject ballObstacle;

    void Start()
    {
       // randomisoi halutun kohdesumman ja asettaa sen targetSum itegeriksi
        targetSum = UnityEngine.Random.Range(4, 20);
        // tekee integeristä stringin score
        string score = targetSum.ToString();
        // nyt voidaan kirjoittaa numero tekstinä
        targetScore.text = score;

        /* Haetaan pallon kuvanvaihtaja kts. alhaalla lisää

        GameObject ball = GameObject.FindGameObjectWithTag("Obstacle");
        var ballRenderer = ball.GetComponent<SpriteRenderer>();
        */

    }

    void Update()
    {
        //laskee ajan ja muuttaa floatin stringiksi
        targetTime -= Time.deltaTime;

        string seconds = (targetTime % 60).ToString("f2");
        timerText.text = seconds;

        //resettaa scenen 3s päästä kun aika loppuu ja kirjoittaa times up näytölle, lukitsee pelaajan liikkumisen
        if (targetTime <= 0)
        {
            
            timerText.text = "Time's up";
            //Invoke("ResetLevel", 3f);
            GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;
        
        }

        //loppukanvaksen numeroiden kirjoitus
        yourScore.text = "Your score " + summa;
        FinalScore.text = "Your final score was " + summa;
        

        //loppu canvaksen onnistuminen / epäonnistuminen kirjoitukset


        if (targetSum == summa) 
            { 
            success = true;
            Debug.Log("score correct");
            }
        else 
        {
            success = false;
        }

        if ((success == true) && (GameObject.Find("Player").GetComponent<PlayerController>().inFinishZone == true))
        {
            
            FinalSuccess.text = "Congradulations you finished the mission successfully Little Astromath!";
            

        }

        else if ((success == true) && (GameObject.Find("Player").GetComponent<PlayerController>().inFinishZone == false))
        {
            FinalSuccess.text = "You have to go to the spaceship at the end!";
        }

        else
        {
            FinalSuccess.text = "You have incorrect score!";
        }
    }

    // metodi jolla voidaan käynnistää leveli uusiksi
        public void ResetLevel()
        {
        SceneManager.LoadScene("Level1");
        }
        

/*Pallon väri muuttuu sen mukaan onko tulos oikea
  
    public void ballColor()
    
    {
        GameObject ball = GameObject.FindGameObjectWithTag("Obstacle");
            var ballRenderer = ball.GetComponent<SpriteRenderer>();

        if (targetSum == summa)
        {
           
            ballRenderer.color = new Color(0f,230f,0f,230f); //Green
        }
        else ballRenderer.color = new Color(255f,0f,0f,230f); //Red
    
    }
    */
    

}
