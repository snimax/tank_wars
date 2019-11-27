using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallScript : MonoBehaviour
{
    public float force = 500.0f;
    public float radius = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "tank")
        {
            Vector3 pos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(new Vector3(pos.x, pos.y), radius);

            foreach (Collider hit in colliders)
            {
                GameObject particle = hit.gameObject;

                if (particle.name == "groundParticle" && particle.transform.parent.gameObject.name != "terrainContainer")
                {
                    Rigidbody rb = particle.GetComponent<Rigidbody>();
                    if (rb == null)
                    {
                        rb = particle.AddComponent<Rigidbody>();
                    }
                    rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
                    rb.AddExplosionForce(force, pos, radius);
                    Debug.Log(particle.name);
                }
            }
            gameObject.SetActive(false);
        }
    }
}