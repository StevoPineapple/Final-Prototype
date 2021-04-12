using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class show_sign : MonoBehaviour
{
 
    public GameObject paw;
    public GameObject icon;
    public static int collisions = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player_movement.controlmode == 2)
        {
            paw.SetActive(true);
        }
        else {
            paw.SetActive(false);
        }

        if (collisions == 0)
        {
            icon.SetActive(false);
        }
        else {
            if (Input.GetKeyDown("space"))
            {

                player_movement.controlmode = 2;
            }
        }

    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "This_is_Mae")
        {
            icon.SetActive(true);
           
        }
        collisions++;
    }

   

    void OnTriggerExit2D(Collider2D collision)
    {
        collisions--;
    }
}

    

