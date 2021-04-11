using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDialogueTrig : MonoBehaviour
{
    GameObject objIcon;
    public GameObject objWithDialog;
    float talkIconOffset = 2;
    void Start()
    {
        objIcon = GameObject.Find("objTalkIcon");
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.gameObject.name == "objPlayer")
        {
            other.GetComponent<scrPlayer>().inTalkRange = true;
            other.GetComponent<scrPlayer>().talkObj = objWithDialog;
            objIcon.transform.position = new Vector3(transform.position.x,
                transform.position.y+talkIconOffset,transform.position.z);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "objPlayer")
        {
            other.GetComponent<scrPlayer>().inTalkRange = false;
            other.GetComponent<scrPlayer>().TalkToDummy();
            objIcon.GetComponent<scrTalkIcon>().ReturnToInitPos();
        }
    }
}
