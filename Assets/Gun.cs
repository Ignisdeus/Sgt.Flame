using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); 
    }

    Renderer rend;
    Ray ray;
    RaycastHit hit;
    float rayLenght = 10f;
    public Transform muzzle; 
    void Update()
    {
        if(Input.GetButton("Fire1")){
            ChangeColor("Fire");
            if (Physics.Raycast(muzzle.position, muzzle.TransformDirection(Vector3.forward), out hit, rayLenght)) {

                if (hit.collider.tag != " Untagged") {
                    GunInteractionHot(hit.collider.gameObject, hit.collider.tag);
                }

            }
        } else if(Input.GetButton("Fire2")){
            ChangeColor("Ice");
            if (Physics.Raycast(muzzle.position, muzzle.TransformDirection(Vector3.forward), out hit, rayLenght)) {

                if (hit.collider.tag != " Untagged") {
                    GunInteractionCold(hit.collider.gameObject, hit.collider.tag);
                }

            }
        } else{
            //ChangeColor("FuckThis");
            ice.Stop();
            fire.Stop();
            
        }


    }

    void GunInteractionCold(GameObject x, string tag){
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
    public ParticleSystem ice, fire; 
    void ChangeColor(string x){
        
        switch (x){

            case "Fire":
                rend.material.SetColor("_Color", Color.red);
                fire.Play();
                break;
            case "Ice":
                ice.Play();
                rend.material.SetColor("_Color", Color.blue);
                break;
            default:
                rend.material.SetColor("_Color", Color.black);
                break; 
        }
    } 
}
