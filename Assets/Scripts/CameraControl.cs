using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    public Rigidbody2D player;
    public float movement;
    float camFov;
    


    void Start()
    {
        camFov = 120.0f;
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        offset = transform.position - Player.transform.position;
        
    }

    
    void Update()
    {
        movement = math.abs(player.velocity.x/2);

        transform.position = Player.transform.position + offset;

        Camera.main.fieldOfView = camFov + movement;

        
        //Debug.Log(camFov);
    }

    
   





}
