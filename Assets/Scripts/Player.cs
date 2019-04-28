using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam;
    Vector3 resetPos;
    CursorLockMode cLock; 
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
        cLock = CursorLockMode.Locked; 
        Cursor.lockState = cLock;
    }
    [Range(0,100)]
    public float vertSenativity= 10, horzSenativity = 10;
    public float movementSpeed= 5;
    public float maxCameraAngle = 90f, minCameraAngle = -90f;
    public KeyCode sprint;
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * (mouseX * horzSenativity));
        cam.transform.Rotate(Vector3.left * (mouseY * vertSenativity));
        

        float movement = Input.GetAxis("Vertical");
        float movementH = Input.GetAxis("Horizontal");

        if (Input.GetKey(sprint)){
            transform.Translate(Vector3.forward * movement * (float)(movementSpeed * 1.5f) * Time.deltaTime);
        } else{
            transform.Translate(Vector3.forward * movement * movementSpeed * Time.deltaTime);
        }
        transform.Translate(Vector3.right * movementSpeed * movementH * Time.deltaTime);

        Vector3 camRotation = cam.transform.localRotation.eulerAngles;
        camRotation.x = Mathf.Clamp(camRotation.x, minCameraAngle, maxCameraAngle);
        cam.transform.localRotation = Quaternion.Euler(camRotation.x,0, 0);

        if (Input.GetButtonDown("Jump") && grounded){
            grounded = false; 
            GetComponent<Rigidbody>().AddForce(Vector3.up * force); 
        }
        FallCheck();
    }

    public float fallDistace; 
    void FallCheck(){

        if(transform.position.y < fallDistace){

            transform.position = resetPos; 
        }

    } 
    public float force = 100; 
    public bool grounded = true; 
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag =="Ground" || other.gameObject.tag == "IceBlock") {
            grounded = true;

        }
        
    }
    public GameObject heldGun;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "GunPickUp"){
            Destroy(other.gameObject);
            heldGun.SetActive(true);

        }
    }
    private void OnCollisionStay(Collision other)
    {

        if(other.gameObject.tag == "Ground"){

            resetPos = transform.position;
        }
        
    }
}
