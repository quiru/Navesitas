using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    int sangre = 100;
    int vida = 6;
    public GameObject amu;
    GameObject amuIn;

    void Start()
    {
        InvokeRepeating("Disparo", 1, 0.5f);
        //PlayerPrefs.SetInt("highScore",5);
        //PlayerPrefs.GetInt("highScore").ToString();
    }

    int tmp;
    void Update()
    {
        tmp = (int)Time.timeSinceLevelLoad;
        tmp %= 2;
        transform.position -= new Vector3(0, 0, 3 * Time.deltaTime);
        if (transform.position.z < -9 || gameObject == null)
        {
            transform.position = new Vector3(Random.Range(-5, 6), 8, 9);
        }

        
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.name == "amu")
        {
            Destroy(coll.gameObject);
            sangre -= 10;
            if (sangre <= 0)
            {
                vida -= 1;
                if (vida <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    gameObject.transform.position = new Vector3(Random.Range(-5, 6), 8, 10);
                    sangre = 100;
                }



            }
        }
    }

    void Disparo()
    {
        if (transform.position.z < 8 && tmp == 0)
        {
            amuIn = Instantiate(amu, gameObject.transform);
            amuIn.transform.position = transform.position;
            amuIn.transform.localScale = new Vector3(1, 1, 1);
            amuIn.transform.localPosition = new Vector3(16, 0, -1);
            amuIn.transform.eulerAngles = new Vector3(90, 0, 0);
            amuIn.transform.parent = null;
            Destroy(amuIn, 1.5f);
        }
    }
}
