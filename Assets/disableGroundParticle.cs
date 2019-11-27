using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableGroundParticle : MonoBehaviour
{
    public float threshold = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            if((rb.velocity.x + rb.velocity.y) <= threshold)
            {
                rb.velocity.Set(0.0f, 0.0f, 0.0f);
                rb.rotation.Set(0.0f, 0.0f, 0.0f, 0.0f);
                rb.isKinematic = false;
                //Destroy(rb);
            }
        }
    }
}
