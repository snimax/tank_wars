using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableGroundParticle : MonoBehaviour
{
    public float threshold = 0.0001f;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void LateUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            if ((rb.velocity.x + rb.velocity.y) <= threshold)
            {
                if (i++ > 100)
                {
                    Destroy(rb);
                }
            }
            else
            {
                i = 0;
            }
        }
    }
}
