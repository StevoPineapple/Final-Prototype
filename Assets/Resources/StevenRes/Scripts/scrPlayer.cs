using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayer : MonoBehaviour
{
    public GameObject talkObj;
    public bool inTalkRange;
    public bool isTalking;
    public GameObject dummyObj;
    DialogManager dialogManager;
    int talkAgainTick = 30; //frame before can talk again
    int talkTick = 0;
    //oldstuff from last project
    #region oldstuff
    private int resetCount = 300;
    private int resetTick = 0;
    private SpriteRenderer sprRenderer;
    private Vector3 selfPos;
    private Rigidbody2D selfBody;
    private Vector3 currVelocity;
    private float selfAngle;
    private Vector3 mousePos;
    private Vector3 prevMousePos;
    private Camera mainCam;
    private float moveSpd = 9.1f; //Add soft speed 
    public float deltaAngle;
    public int numOfDiamond;
    public bool lockMovement = false;
    float moveSmoothRate = 0.3f;
    float turnSmoothRate = 0.7f;
    float scrollSpeed = 0.35f;
    Renderer rend;
    #endregion
    void Start()
    {
        dialogManager = GameObject.Find("objDialogManager").GetComponent<DialogManager>();
        selfBody = gameObject.GetComponent<Rigidbody2D>();
        selfPos = gameObject.transform.position;
        mainCam = Camera.main;
        currVelocity = selfBody.velocity;
    }

    void keyMove()
    {
        //float adjAngle;
        selfPos = gameObject.transform.position;
        /*adjAngle = getAngle(selfPos.y-mousePos.y,selfPos.x-mousePos.x);
        Debug.Log(adjAngle);
        if(adjAngle<0){
            adjAngle=-adjAngle;
            adjAngle=180-adjAngle;
            adjAngle=adjAngle+180;
        }*/
        if(!lockMovement)
        {
            if(Input.GetKey(KeyCode.W))
                currVelocity.y = 1.0f*moveSpd;
            else if(Input.GetKey(KeyCode.S))
                currVelocity.y = -1.0f*moveSpd;
            if(Input.GetKey(KeyCode.A))
                currVelocity.x = -1.0f*moveSpd;
            else if(Input.GetKey(KeyCode.D))
                currVelocity.x = 1.0f*moveSpd;
        }
    }

    public void TalkToDummy()
    {
        talkObj = dummyObj;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.eulerAngles);
    }

    public float getAngle(float oppLen, float adjLen)
    {
        return(Mathf.Rad2Deg*Mathf.Atan2(oppLen,adjLen));
    }

    void HandleMovement()
    {
        selfBody.velocity = Vector3.Lerp(selfBody.velocity,currVelocity,moveSmoothRate);
        currVelocity = new Vector3(0,0,0);
    }
    void FixedUpdate()
    {
        keyMove();
        HandleMovement();
        
    }
    void Update()
    {
        if(inTalkRange&&!isTalking)
        {
            if(talkTick < talkAgainTick)
            {
                talkTick+=1;
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("StartTalking");
                isTalking = true;
                lockMovement = true;
                dialogManager.StartTalking(talkObj);
            }
        } 
    }
    public void StopTalking()
    {
        talkTick = 0;
        isTalking = false;
        lockMovement = false;
    }
}
