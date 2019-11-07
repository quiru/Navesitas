using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{

    int velMov = 0;
    int sangre = 100;
    int vidas = 3;
    public GameObject amuPre;
    GameObject amuIn;
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
            amuIn = Instantiate(amuPre, gameObject.transform);
            amuIn.transform.position = transform.position;
            amuIn.transform.eulerAngles = new Vector3(90, 0, 0);
            amuIn.transform.localScale = new Vector3(1, 1, 1);
            amuIn.transform.parent = null;
            amuIn.name = "amu";
            Destroy(amuIn, 2);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<Enemigo0>() || coll.gameObject.GetComponent<Enemigo1>() || coll.gameObject.GetComponent<Enemigo2>())
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
        else if (coll.gameObject.GetComponent<AmuEnemy>())
        {
            sangre -= 5;
            Destroy(coll.gameObject);
            if (sangre <= 0)
            {
                vidas -= 1;
                transform.position = new Vector3(0, 8, -6);
                if (vidas <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
