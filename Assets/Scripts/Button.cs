using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator anim;
    public GameObject[] messageTo;
    public string messageContent;
    public GameObject pipe;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject g in messageTo){
            g.GetComponent<Wall_Mounted>().StartPartical(messageContent);
        }
        pipe.GetComponent<LineRenderer>().material.SetColor("_Color", Color.yellow);
        anim.SetBool("Pushed", true);
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject g in messageTo) {
            g.GetComponent<Wall_Mounted>().StartPartical("Nopped out of there");
        }
        pipe.GetComponent<LineRenderer>().material.SetColor("_Color", Color.black);
        anim.SetBool("Pushed", false);
    }
}
