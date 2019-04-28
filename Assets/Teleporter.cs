using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportPoint; 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            other.gameObject.transform.position = teleportPoint.transform.position; 
        }
    }
}
