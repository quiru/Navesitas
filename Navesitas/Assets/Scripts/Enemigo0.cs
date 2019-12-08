using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo0 : MonoBehaviour
{
    int movVert = -4;
    int movHoriz = 4;
    int cambiaMov = 0;
    int sangre = 100;
    int vida = 5;
    public GameObject amu;
    GameObject amuIn;
    public AudioClip sonExplosion;
    public ParticleSystem explo;
    AudioSource reprod;

    void Start()
    {
        cambiaMov = Random.Range(0, 2);
        Invoke("LlamaCorru", 1.6f);
        InvokeRepeating("Disparo", 1, 0.6f);
        gameObject.AddComponent<AudioSource>();
        reprod = GetComponent<AudioSource>();
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
            Destroy(coll.gameObject);
            sangre -= 10;
            if (sangre <= 0)
            {
                vida -= 1;
                if (vida <= 0)
                {
                    Destroy(gameObject, 0.7f);
                    reprod.clip = sonExplosion;
                    reprod.Play();
                    explo.Play();
                }
                else
                {
                    StopCoroutine("CambiaMov");
                    gameObject.transform.position = new Vector3(Random.Range(-5, 5), 8, 8.5f);
                    movVert = -4;
                    sangre = 100;
                    Invoke("LlamaCorru", 1.6f);
                    explo.Stop();
                }
                


            }
        }
    }

    void Disparo()
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
