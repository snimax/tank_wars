using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseExplosion : MonoBehaviour
{
    public float radius = 1.0f;
    public float power = 500.0f;
    public float breakThreshold = 400.0f;
    public GameObject terrainContainer;
    // Start is called before the first frame update
    float i = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0.0f;
            Collider[] colliders = Physics.OverlapSphere(new Vector3(pos.x, pos.y), radius);

            foreach (Collider hit in colliders)
            {
                GameObject particle = hit.gameObject;
                if (particle.transform.parent.gameObject != terrainContainer)
                {
                    Rigidbody rb = particle.GetComponent<Rigidbody>();
                    if (rb == null)
                    {
                        rb = particle.AddComponent<Rigidbody>();
                        i++;
                        Debug.Log("Active particles: " + i.ToString());
                    }
                    rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                    rb.AddExplosionForce(power, pos, radius);
                    
                }
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0.0f;
            Collider[] colliders = Physics.OverlapSphere(pos, radius);

            foreach (Collider hit in colliders)
            {
                GameObject particle = hit.gameObject;
                if(particle.transform.parent.gameObject != terrainContainer)
                {
                    Rigidbody rb = particle.GetComponent<Rigidbody>();
                    if (rb == null)
                    {
                        rb = particle.AddComponent<Rigidbody>();
                        i++;
                        Debug.Log("Active particles: " + i.ToString());
                    }
                    rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                    rb.AddExplosionForce(-power, pos, radius);
                    
                }
            }
        }
    }
    
    void addExplosiveForce(Vector3 pos, GameObject go)
    {
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        if (rb)
        {
            Vector3 objPos = go.transform.position;

            Vector3 heading = objPos - pos;
            float distance = heading.magnitude;
            Vector3 direction = power * heading / distance;
            /*if (direction.magnitude > breakThreshold)
            {
                Destroy(go);
                Debug.Log(go.name);
            }
            else
            {*/
                rb.AddForce(new Vector2(direction.x, direction.y));
            go.GetComponent<Collider2D>().enabled = true;
                
            //}
        }
    }
}
