using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myRB;
    public Animator animator;

    public float maxSpeed;
    public float jumpPower;

    public LayerMask groundLayer;
    public Transform groundCheck;
    float groundCheckRadius = 0.2f;
    public bool isGrounded;
    

    public bool canMove = true;
    public bool inFinishZone = false;
 


    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

    }

 
    void Update()
    {
        // canMove boolilla voidaan pysäyttää pelaaja menujen ym. ajaksi
        if (canMove == true) 
        { 
            
            Movement();
        
            Jump();
            myRB.gravityScale = 1;
        }
        //pysäyttää liikkeen ja painovoiman kun pelaaja ei saa liikkua
        else 
            { 
                myRB.velocity = new Vector2(0f, 0f);
                myRB.gravityScale = 0;
            }
            
           // pudotuskuolema jos tippuu kentältä
        if(myRB.transform.position.y <= -8)
        {
            SceneManager.LoadScene("Level1");
        }
        

        

    }
    // asettaa boolin onko finishzonessa, tarkastetaan tämä kun aika loppuu
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            inFinishZone = true;
            Debug.Log("zones");
        }
        else 
        { 
            inFinishZone = false;
            Debug.Log("ei zones");
        }
    }
        

    // tarkastetaan onko pelaaja maassa, jos on niin hypätään kun painetaan välilyöntiä, soitetaan animaatio ja ääni
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            animator.SetTrigger("Jump_animation");
            SoundManager.PlaySound("PlayerJump");
        }

    }

    // pelaaja liikkuu kun painetaan liikkumisnappeja, soitetaan myös animaatio ja ääni kun ei liikuteta pysäytetään animaatio ja ääni
    private void Movement()
    {
        
        
         float move = Input.GetAxis("Horizontal");
        
       

        myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
        if (Input.GetAxisRaw("Horizontal") != 0 && isGrounded)
            {
            transform.localScale = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 1);
            animator.SetBool("Walk_animation", true);
            GetComponent<AudioSource>().UnPause();
        }
        else
            {
            animator.SetBool("Walk_animation", false);
            GetComponent<AudioSource>().Pause();
                
            }

    }

    

}
