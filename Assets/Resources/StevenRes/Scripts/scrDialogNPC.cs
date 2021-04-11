using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDialogNPC : MonoBehaviour
{
    public string dialogPath;
    void Start()
    {
        //if(somePlotConditions)
            dialogPath = "Assets/Resources/StevenRes/Dialogs/Dialog.txt";
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
    }
    void Update()
    {
        
    }
}
