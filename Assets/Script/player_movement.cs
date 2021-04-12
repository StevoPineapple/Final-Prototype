using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 0.1f;
 
    public static int controlmode;
    // Start is called before the first frame update
    void Start()
    {
        controlmode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlmode == 1){
            float translation_x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(translation_x, 0, 0);
        }
    }
}
