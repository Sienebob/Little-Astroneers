using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject item;

    private Transform player;
    public int negativeValue;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        //menosuunta oikealle
        if (player.transform.localScale.x == 1)
        { 
        Vector2 playerPos = new Vector2(player.position.x - 2, player.position.y +1);
        Instantiate(item, playerPos, Quaternion.identity);
        }
        // menosuunta vasemmalle
        else 
        { 
        Vector2 playerPos = new Vector2(player.position.x + 2, player.position.y +1);
        Instantiate(item, playerPos, Quaternion.identity);
        }
    }

    public void Update()
    {
  
    }
}
