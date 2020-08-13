using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    
    

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
                
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        foreach (Transform child in transform)
        {

            
            child.GetComponent<SpawnItem>().SpawnDroppedItem();

            //toMinus -= negativeSum;
            Debug.Log("Itemi tiputettu" + child.gameObject);
            Debug.Log(child.gameObject.GetComponent<SpawnItem>().negativeValue);
            GameObject.Find("Sum").GetComponent<sum>().summa -= child.gameObject.GetComponent<SpawnItem>().negativeValue;
            GameObject.Destroy(child.gameObject);

            
         
        }
        
    
    
    
    }


}
