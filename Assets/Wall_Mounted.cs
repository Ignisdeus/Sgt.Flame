using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall_Mounted : MonoBehaviour
{
    public ParticleSystem ice, fire; 
    void Start()
    {
        ice.Stop();
        fire.Stop(); 
    }

    Ray ray;
    RaycastHit hit;
    public Transform muzzle;
    float rayLenght = 10;
    bool fireOn = false, iceOn = false; 
    private void Update()
    {
        if (Physics.Raycast(muzzle.position, muzzle.TransformDirection(Vector3.forward), out hit, rayLenght)) {

            
            if(fireOn){
                GunInteractionHot(hit.collider.gameObject, hit.collider.tag);
            }else if(iceOn){
                GunInteractionCold(hit.collider.gameObject, hit.collider.tag);

            }

        }
    }


    void GunInteractionCold(GameObject x, string tag)
    {
        switch (tag) {

            case "IceBlock":
                x.GetComponent<IceBlock>().timer += Time.deltaTime;
                break;
            default:

                break;
        }
    }
    void GunInteractionHot(GameObject x, string tag)
    {
        switch (tag) {

            case "IceBlock":
                x.GetComponent<IceBlock>().timer -= Time.deltaTime;
                break;
            default:

                break;
        }
    }


    public void StartPartical(string x){
        switch (x){

            case "Fire":
                fire.Play();
                fireOn = true; 
                break;

            case "Ice":
                ice.Play();
                iceOn = true;
                break; 
            default:
                ice.Stop();
                fire.Stop();
                iceOn = false;
                fireOn = false; 
                break; 


        }

    }
}
