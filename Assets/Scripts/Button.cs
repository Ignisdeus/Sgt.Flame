using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Animator anim; 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("Pushed", true);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Pushed", false);
    }
}
