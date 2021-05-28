using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    public float fuse = 2.0f;

    public GameObject fire;

    public int firePower;



    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explosion", fuse);
    }

    // Update is called once per frame
    void Explosion()
    {
        Vector3 placePosition = new Vector3(0, 0, 0);

        placePosition.x = Mathf.Round(transform.position.x);
        placePosition.y = 0;
        placePosition.z = Mathf.Round(transform.position.z);

        //Instantiate(fire, transform.position, Quaternion.identity);

        for(int x = 0; x < firePower; x++)
        {
            bool continua = true;

            foreach (GameObject pillar in GameObject.FindGameObjectsWithTag("Pillars"))
            {
                if (pillar.transform.position == placePosition + new Vector3(x, 0, 0))
                {
                    continua = false;
                    break;
                }
            }

            if (continua)
            {
                Instantiate(fire, placePosition + new Vector3(x, 0, 0), Quaternion.identity);
            }
            else
            {
                break;
            }

        }

        for (int x = 0; x < firePower; x++)
        {
            bool continua = true;

            foreach (GameObject pillar in GameObject.FindGameObjectsWithTag("Pillars"))
            {
                if(pillar.transform.position == placePosition - new Vector3(x, 0, 0))
                {
                    continua = false;
                    break;
                }
            }

            if (continua)
            {
                Instantiate(fire, placePosition - new Vector3(x, 0, 0), Quaternion.identity);
            }
            else
            {
                break;
            }
            
        }


        for(int z = 0; z < firePower; z++)
        {
            bool continua = true;

            foreach (GameObject pillar in GameObject.FindGameObjectsWithTag("Pillars"))
            {
                if (pillar.transform.position == placePosition + new Vector3(0, 0, z))
                {
                    continua = false;
                    break;
                }
            }

            if (continua)
            {
                Instantiate(fire, placePosition + new Vector3(0, 0, z), Quaternion.identity);
            }
            else
            {
                break;
            }
        }

        for (int z = 0; z < firePower; z++)
        {
            bool continua = true;

            foreach (GameObject pillar in GameObject.FindGameObjectsWithTag("Pillars"))
            {
                if (pillar.transform.position == placePosition - new Vector3(0, 0, z))
                {
                    continua = false;
                    break;
                }
            }

            if (continua)
            {
                Instantiate(fire, placePosition - new Vector3(0, 0, z), Quaternion.identity);
            }
            else
            {
                break;
            }
        }

        Destroy(gameObject);
    }
}
