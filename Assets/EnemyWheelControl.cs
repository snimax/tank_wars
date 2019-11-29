using UnityEngine;

public class EnemyWheelControl : MonoBehaviour
{
    public float movementForce = 4000.0f;
    public float inSightDistance = 8.0f;
    public float stoppingDistance = 6.0f;
    public float retreatDistance = 3.0f;

    public Transform playerTank;


    // Start is called before the first frame update
    void Start()
    {
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTank.position);
        Debug.Log("distanceToPlayer = " + distanceToPlayer);
        if (distanceToPlayer < inSightDistance && distanceToPlayer > stoppingDistance)
        {
            GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 0.0f, movementForce);
        }
        else if(distanceToPlayer < retreatDistance)
        {
            GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 0.0f, -movementForce);
        }
        

        /*
        // Keep for human enemy player?
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 leftForce = transform.TransformVector(new Vector3(0.0f, 0.0f, movementForce));
            //Debug.DrawRay(transform.position, leftForce);
            //Debug.DrawRay(new Vector3(0.0f, 0.0f), leftForce);
            GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 0.0f, movementForce);
            Debug.Log("Left " + GetComponent<Rigidbody>().angularVelocity.magnitude);
            //GetComponent<Rigidbody>().AddForce(transform.localToWorldMatrix * leftForce);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Vector3 rightForce = transform.TransformVector(new Vector3(0.0f, 0.0f, -movementForce));
            //Debug.DrawRay(transform.position, rightForce);
            //Debug.DrawRay(new Vector3(0.0f, 0.0f), rightForce);
            GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 0.0f, -movementForce);
            Debug.Log("Right " + GetComponent<Rigidbody>().angularVelocity.magnitude);
            //GetComponent<Rigidbody>().AddForce(transform.localToWorldMatrix * rightForce);
        }
        */
    }
}
