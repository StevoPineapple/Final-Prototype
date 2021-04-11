using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject talkObj;
    scrPlayer player;
    public TextMeshProUGUI dialogBoxText;
    string text;
    public GameObject dialogBox;
    public bool isTalking;
    StreamReader reader;
    Vector3 dialogBoxOffset = new Vector3(1,2,0);
    void Start()
    {
        player = GameObject.Find("objPlayer").GetComponent<scrPlayer>();
    }

    public void StartTalking(GameObject talkObj)
    {
        dialogBox.transform.position = player.transform.position+dialogBoxOffset;
        reader = new StreamReader(talkObj.GetComponent<scrDialogNPC>().dialogPath);
        isTalking = true;
        text = reader.ReadLine();
    }
    public void StopTalking()
    {
        reader.Close();
        isTalking = false;
        dialogBox.transform.position = GameObject.Find("objOffScreenPos").transform.position;
        player.StopTalking();
    }
    void Update()
    {
        if(isTalking)
        {
            if(Input.GetKeyDown(KeyCode.Space))
                text = reader.ReadLine();
            if(text != "<END>")
            {
                if(text.Substring(0,2) == "M:")
                {
                    dialogBoxText.color = new Color(1,1,1);
                }
                else if(text.Substring(0,2) == "G:")
                {
                    dialogBoxText.color = new Color(0.9f,0.78f,0.22f,1);
                }
                dialogBoxText.text = text.Substring(2);
            }
            else
            {
                StopTalking();
                Debug.Log("StopTalking");
            }
        }
    }
}
