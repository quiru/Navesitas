using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    int cambiaDir = 2;
    int sangre = 100;
    int vida = 4;
    public GameObject amu;
    GameObject amuIn;

    void Start()
    {
        Invoke("CallCorru", 55);
        InvokeRepeating("Disparo", 5, 0.5f);
    }


    void Update()
    {
        int tmp =(int) Time.timeSinceLevelLoad;
        if (tmp >= 50)
        {
            transform.position += new Vector3(cambiaDir * Time.deltaTime, 0, 0);
            if (transform.position.x >= 10)
            {
                cambiaDir *= -1;
                
            }
            if (transform.position.x < -17)
            {
                transform.position = new Vector3(-17, 8, Random.Range(-3, 5));
                cambiaDir *= -1;
            }
        }
        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.name == "amu")
        {
            Destroy(coll.gameObject);
            sangre -= 5;
            if (sangre <= 0)
            {
                vida -= 1;
                if (vida <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.transform.position = new Vector3(-17, 8, Random.Range(-3, 5));
                    sangre = 100;

                }



            }
        }
    }

    void CallCorru()
    {
        StartCoroutine("PararMov");
    }
    IEnumerator PararMov()
    {
        while (true)
        {
            int guardaCam = cambiaDir;
            cambiaDir = 0;
            yield return new WaitForSeconds(1.5f);
            cambiaDir = guardaCam;
            yield return new WaitForSeconds(7);
        }
    }
    void Disparo()
    {
        amuIn = Instantiate(amu, gameObject.transform);
        amuIn.transform.position = transform.position;
        amuIn.transform.localScale = new Vector3(1, 1, 1);
        amuIn.transform.localPosition = new Vector3(18, 0, -1);
        amuIn.transform.eulerAngles = new Vector3(90, 0, 0);
        amuIn.transform.parent = null;
        Destroy(amuIn, 1.5f);
    }
}
