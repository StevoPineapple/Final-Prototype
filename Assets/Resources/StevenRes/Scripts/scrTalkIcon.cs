using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTalkIcon : MonoBehaviour
{
    Vector3 initPos;
    scrPlayer player;
    void Start()
    {
        initPos = transform.position;
        player = GameObject.Find("objPlayer").GetComponent<scrPlayer>();
    }

    void FixedUpdate()
    {
        if(player.isTalking)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
        }
    }
    public void ReturnToInitPos()
    {
        transform.position = initPos;
    }
}
