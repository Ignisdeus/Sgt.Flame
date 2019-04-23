using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        targetScale = transform.localScale;

    }

    public float timer = 0f;
    public float tickTime = 2f;
    public float growingAmount = 1f;
    public float maxSize, minSize; 
    Vector3 targetScale; 
    private void Update()
    {
        if(timer > tickTime){
            timer = 0;
            targetScale = new Vector3(transform.localScale.x, transform.localScale.y , transform.localScale.z + growingAmount); 
        }
        if (timer < -tickTime){
            timer = 0;
            targetScale = new Vector3(transform.localScale.x, transform.localScale.y , transform.localScale.z - growingAmount);
        }

        targetScale.z = Mathf.Clamp(targetScale.z, minSize, maxSize);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.2f);
        
    }


}
