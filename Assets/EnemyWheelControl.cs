using UnityEngine;

public class EnemyWheelControl : MonoBehaviour
{
    public float movementForce = 4000.0f;
    public float stoppingDistance = 7.0f;
    public float retreatDistance = 4.0f;

    public Transform playerTank;


    // Start is called before the first frame update
    void Start()
    {
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, playerTank.position) > stoppingDistance)
        {
            GetComponent<Rigidbody>().AddRelativeTorque(0.0f, 0.0f, movementForce);
        }
        else if(Vector3.Distance(transform.position, playerTank.position) < retreatDistance)
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
