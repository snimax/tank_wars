using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannonControl : MonoBehaviour
{
    public float turretSpeed = 2.0f;
    public float shotCharge = 0.0f;
    private float chargeStart;
    public GameObject cannonBall;
    public float shotForce = 1000.0f;

    public float inSightDistance = 8.0f;
    public float stoppingDistance = 6.0f;
    public float retreatDistance = 3.0f;
    public Transform playerTank;
    private float startShotTime = 0.0f;
    public float fireTimeInterval = 3.0f;

    private bool moveCannonLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        playerTank = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // Save for human enemy player?
        if (Input.GetKey(KeyCode.UpArrow))
        {

            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.z += turretSpeed;
            if (rotation.z <= 180.0f)
            {
                transform.Rotate(0.0f, 0.0f, turretSpeed, Space.Self);
            }

        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.z -= turretSpeed;
            if (rotation.z >= 0.0f)
            {
                transform.Rotate(0.0f, 0.0f, -turretSpeed, Space.Self);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            chargeStart = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            float shotCharge = Time.time - chargeStart;

            shotCharge = shotCharge > 1 ? 1 : shotCharge;
            Quaternion rotation = transform.localRotation;
            Vector3 pos = transform.position;
            GameObject shot = Instantiate(cannonBall, pos, rotation);
            shot.transform.Translate(0.5f, 0.0f, 0.0f, Space.Self);
            shot.GetComponent<Rigidbody>().AddRelativeForce(shotForce * shotCharge, 0.0f, 0.0f);
            Debug.Log(shotCharge);

        }
        */

        float distanceToPlayer = Vector3.Distance(transform.position, playerTank.position);
        Vector3 rotation = transform.localRotation.eulerAngles;
        if (distanceToPlayer > inSightDistance)
        {
            // not in sight, scaning mode
            if(moveCannonLeft)
            {
                if (rotation.z <= 180.0f)
                {
                    rotation.z += turretSpeed;
                    transform.Rotate(0.0f, 0.0f, turretSpeed, Space.Self);
                }
                else
                {
                    moveCannonLeft = false;
                }

            }
            else
            {
                if (rotation.z >= 0.0f)
                {
                    rotation.z -= turretSpeed;
                    transform.Rotate(0.0f, 0.0f, -turretSpeed, Space.Self);
                }
                else
                {
                    moveCannonLeft = true;
                }
            }
        }
        else if (distanceToPlayer < inSightDistance && distanceToPlayer > stoppingDistance)
        {
            // in sight, point the barrel towards the player
            if (rotation.z != 160)
            {
                if (160 - rotation.z >= 0)
                {
                    rotation.z += turretSpeed;
                    transform.Rotate(0.0f, 0.0f, turretSpeed, Space.Self);
                }
                else
                {
                    rotation.z -= turretSpeed;
                    transform.Rotate(0.0f, 0.0f, -turretSpeed, Space.Self);
                }
            }
        }
        else if (distanceToPlayer < stoppingDistance)
        {
            // in distance of shooting
            if (distanceToPlayer > stoppingDistance - 1)
            {
                if (rotation.z != 165)
                {
                    if (165 - rotation.z >= 0)
                    {
                        rotation.z += turretSpeed;
                        transform.Rotate(0.0f, 0.0f, turretSpeed, Space.Self);
                    }
                    else
                    {
                        rotation.z -= turretSpeed;
                        transform.Rotate(0.0f, 0.0f, -turretSpeed, Space.Self);
                    }
                }
                shotCharge = 0.5f;
            }
            else if (distanceToPlayer > stoppingDistance - 2)
            {
                if (rotation.z != 172.5)
                {
                    if (172.5 - rotation.z >= 0)
                    {
                        rotation.z += turretSpeed;
                        transform.Rotate(0.0f, 0.0f, turretSpeed, Space.Self);
                    }
                    else
                    {
                        rotation.z -= turretSpeed;
                        transform.Rotate(0.0f, 0.0f, -turretSpeed, Space.Self);
                    }
                }
                shotCharge = 0.35f;
            }
            else if (distanceToPlayer > stoppingDistance - 3)
            {
                if (rotation.z != 177.5)
                {
                    if (177.5 - rotation.z >= 0)
                    {
                        rotation.z += turretSpeed;
                        transform.Rotate(0.0f, 0.0f, turretSpeed, Space.Self);
                    }
                    else
                    {
                        rotation.z -= turretSpeed;
                        transform.Rotate(0.0f, 0.0f, -turretSpeed, Space.Self);
                    }
                }
                shotCharge = 0.2f;
            }
            else
            {
                shotCharge = 0.1f;
            }

            if(Time.time - startShotTime > fireTimeInterval)
            {
                FireCannon();
            }
        }

    }

    void FireCannon()
    {
        Quaternion rotation = transform.localRotation;
        Vector3 pos = transform.position;
        GameObject shot = Instantiate(cannonBall, pos, rotation);
        shot.transform.Translate(0.5f, 0.0f, 0.0f, Space.Self);
        shot.GetComponent<Rigidbody>().AddRelativeForce(shotForce * shotCharge, 0.0f, 0.0f);
        Debug.Log(shotCharge);

        startShotTime = Time.time;
    } 
}
