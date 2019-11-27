using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public bool flatGround = false;
    public GameObject groundParticle;
    public GameObject terrainParentObject;
    // Start is called before the first frame update
    public int resolution;
    private float[] surface;
    private GameObject[] groundParticles;

    public float terrainConst = 1.0f;
    public float terrainStart = -5.0f;
    public float terrainScalar = 5.0f;

    float terrainMin = 1.0f;

    void Start()
    {
        float cameraWidth = 11;
        float stepSize = cameraWidth / (float)resolution;

        surface = new float[resolution+1];
        groundParticles = new GameObject[resolution+1];

        if(!flatGround)
            surface = generateFractal(surface, 5);

        float sin60 = Mathf.Sin(Mathf.PI / 3.0f);
        int height = Mathf.CeilToInt(terrainScalar/ stepSize + Mathf.Abs(terrainStart));
        int width = Mathf.FloorToInt(cameraWidth / stepSize)-1;
        int a = 0;
        for (int j = 0; j <= height; j++)
        {
            float modJ = (j % 2);
            for (int i = 0; i <= width - modJ; i++)
            {
                float x = stepSize * (i + (0.5f * modJ)) - (cameraWidth - stepSize) / 2.0f;//(float)i + (0.5f * modJ)
                float y = stepSize * j * sin60 + terrainStart + stepSize / 2.0f; //(float)j * sin60
                if (y > terrainScalar * (surface[i] - terrainMin) + terrainStart + terrainConst)
                {
                    continue;
                }
                GameObject g = Instantiate(groundParticle, new Vector3(x, y), Quaternion.identity, gameObject.transform);
                float b = 2.5f;
                g.transform.localScale = new Vector3(stepSize/b, stepSize/b, stepSize/b);
                g.name = "groundParticle";
                //g.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;// ^ RigidbodyConstraints.FreezePositionY;
                a++;
            }
        }
        Debug.Log("Generated ground particles: " + a.ToString());


        /*        int i = 0;

                for (float x = -cameraWidth / 2; x <= cameraWidth / 2; x += stepSize)
                {
                    int j = 0;
                    for (float y = -6; y < 12; y += stepSize)
                    {

                        if (y > terrainScalar * surface[i] + terrainConst)
                        {
                            break;
                        }
                        GameObject g = Instantiate(groundParticle, new Vector3(x, y, 0.0f), Quaternion.identity);
                        g.name = "groundParticle(" + i.ToString() + "," + j.ToString() + ")";
                        g.transform.localScale = new Vector3(stepSize, stepSize, stepSize);

                        groundParticles[i] = g;
                        j++;
                    }
                    i++;
                }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float[] generateFractal(float[] array, int levels)
    {

        int frequency = 1;

        for (int level = 0; level <= levels; level++)
        {
            float y = Random.Range(0.0f, 10.0f);
            for (int i = 0; i < array.Length; i++)
            {
                float x = (float)i / (float)array.Length;
                //float y = (float)level / (float)levels; //Sample different places every level
                array[i] += Mathf.PerlinNoise(frequency * x, y) / (float)frequency;

                //save the minimum terrain level for later use
                if(level == levels && array[i] < terrainMin)
                {
                    terrainMin = array[i];
                }
            }
            frequency *= 2;
        }
        Debug.Log("Minimum ground fractal value:" + terrainMin.ToString());
        return array;
        
    }
}