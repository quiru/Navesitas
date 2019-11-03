using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo0 : MonoBehaviour
{
    int movVert = -4;
    int movHoriz = 4;
    int cambiaMov = 0;
    int sangre = 100;
    int vida = 4;

    void Start()
    {
        cambiaMov = Random.Range(0, 2);
        Invoke("LlamaCorru", 1.6f);
    }

    void LlamaCorru()
    {
        StartCoroutine("CambiaMov");
    }

    IEnumerator CambiaMov()
    {
        while (true)
        {
            movVert *= -1;
            yield return new WaitForSeconds(1);
        }
    }


    void Update()
    {
        transform.position += new Vector3(0, 0, movVert * Time.deltaTime);

        if (transform.position.x <= 10)
        {
            if (transform.position.x <= -10)
            {
                movHoriz *= -1;
            }
        }
        else
        {
            movHoriz *= -1;
        }

        if (cambiaMov == 0)
        {
            transform.position += new Vector3(movHoriz * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(movHoriz * Time.deltaTime, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.name == "amu")
        {
            //Destroy(coll.gameObject);
            sangre -= 15;
            if (sangre <= 0)
            {
                vida -= 1;
                if (vida <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    StopCoroutine("CambiaMov");
                    gameObject.transform.position = new Vector3(Random.Range(-5, 5), 8, 8.5f);
                    movVert = -4;
                    sangre = 100;
                    Invoke("LlamaCorru", 1.6f);
                }
                


            }
        }
    }
}
