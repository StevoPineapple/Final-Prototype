using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paw_movement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    public Animator animator;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 219)
        {
            transform.position = new Vector3(transform.position.x,219,transform.position.z);
        }
        if (transform.position.y < 157)
        {
            transform.position = new Vector3(transform.position.x, 157, transform.position.z);
        }

        if (player_movement.controlmode==2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("paw_use");
            }
            float translation_y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(0, translation_y, 0);

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                player_movement.controlmode = 1;

            }
        }
        
    }
}
