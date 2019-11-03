using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{

    int velMov = 0;
    public GameObject amu;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

            if (transform.position.x < -10.8)
            {
                velMov = 0;
            }
            else if(transform.position.x > -11)
            {
                velMov = 10;
                transform.eulerAngles = new Vector3(0, -10, 0);
            }
            transform.position -= new Vector3(velMov * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            

            if (transform.position.x > 10.8)
            {
                velMov = 0;
                
            }
            else if (transform.position.x < 11)
            {
                velMov = 10;
                transform.eulerAngles = new Vector3(0, 10, 0);
            }
            transform.position += new Vector3(velMov * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position.z > 5.8)
            {
                velMov = 0;
            }
            else if (transform.position.z < 6)
            {
                velMov = 8;
            }
            transform.position += new Vector3(0, 0, velMov * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (transform.position.z < -5.8)
            {
                velMov = 0;
            }
            else if (transform.position.z > -6)
            {
                velMov = 8;
            }
            transform.position -= new Vector3(0, 0, velMov * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            amu = Instantiate(amu, gameObject.transform);
            amu.transform.position = transform.position;
            amu.transform.localScale = new Vector3(1, 1, 1);
            amu.transform.parent = null;
            amu.name = "amu";
        }
    }
}
