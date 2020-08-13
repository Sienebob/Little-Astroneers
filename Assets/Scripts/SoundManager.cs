using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerWalk, playerJump;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        playerWalk = Resources.Load<AudioClip>("PlayerWalking");
        playerJump = Resources.Load<AudioClip>("PlayerJump");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "PlayerWalking":
                audioSource.PlayOneShot(playerWalk);
                break;
            case "PlayerJump":
                audioSource.PlayOneShot(playerJump);
                break;

        }
    }
}
