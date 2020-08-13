using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;

    public GameObject itemButton;
    
    // nostettavan itemin laskennallinen arvo
    public int itemValue;


    // hakee inventory scriptin pelaajanta
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    // kun pelaaja osuu itemiin itemi lisätään inventory listalle seuraavaan vapaaseen paikkaan ja tuhotaan itemi pelimaailmasta
    // sitten plussataan sum scriptin summaan listaan lisätyn itemin arvo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    GameObject.Find("Sum").GetComponent<sum>().summa += itemValue;
                    break;
                
               
                }
               
                
            
            }
            
        }
    }
}
