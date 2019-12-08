using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MovPersonaje : MonoBehaviour
{

    int velMov = 0;
    int sangre = 100;
    int vidas = 3;
    public GameObject amuPre;
    GameObject amuIn;
    public ParticleSystem tiro;
    public ParticleSystem explosion;
    AudioSource Reproductor;
    public AudioClip sonDisparo;
    public AudioClip sonExplosion;
    GameObject mensLose;
    public Button salir;
    public Button reset;
    public Image blood;
    public GameObject tranparente;
    public Material matTrans;
    bool vidaMenos;
    public GameObject bombPre;
    GameObject bomb;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        Reproductor = GetComponent<AudioSource>();
        mensLose = GameObject.Find("TextMeshPro1");
        mensLose.SetActive(false);
        salir.gameObject.SetActive(false);
        reset.gameObject.SetActive(false);
        StartCoroutine("VerificaDaño");
        explosion.Stop();
    }

    int cont;
    void Update()
    {
        cont = (int)Time.timeSinceLevelLoad;
        if (Input.GetKey(KeyCode.A))
        {

            if (transform.position.x < -10.8)
            {
                velMov = 0;
            }
            else if(transform.position.x > -11)
            {
                velMov = 8;
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
                velMov = 8;
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
            else if (transform.position.z >= -6)
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
            tiro.Play();
            Destroy(amuIn, 1.2f);
            Reproductor.clip = sonDisparo;
            Reproductor.Play();
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            tiro.Stop();
        }

        if (Input.touchCount > 0)
        {
            Touch toque = Input.GetTouch(0);

            if (toque.phase == TouchPhase.Began)
            {
                firstPressPos = toque.position;
            }

            if (toque.phase == TouchPhase.Moved)
            {
                secondPressPos = toque.position;
                currentSwipe = secondPressPos - firstPressPos;
                currentSwipe.Normalize();

                float movHoriz = 0;
                float movVert = 0;

                movHoriz = currentSwipe.x;
                movVert = currentSwipe.y;

                gameObject.transform.position += new Vector3(movHoriz * (Time.deltaTime + .2f), 0, movVert * (Time.deltaTime + .2f));


                if (transform.position.x > 10)
                {
                    movHoriz = 0;
                    transform.position = new Vector3(10, transform.position.y, transform.position.z);
                }

                if (transform.position.x < -10)
                {
                    movHoriz = 0;
                    transform.position = new Vector3(-10, transform.position.y, transform.position.z);
                }

                if (transform.position.z < -6)
                {
                    movVert = 0;
                    transform.position = new Vector3(transform.position.x, transform.position.y, -6);
                }

                if (transform.position.z > 5)
                {
                    movVert = 0;
                    transform.position = new Vector3(transform.position.x, transform.position.y, 5);
                }

                
            }

            
        }
    }

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public void Disparar()
    {
        amuIn = Instantiate(amuPre, gameObject.transform);
        amuIn.transform.position = transform.position;
        amuIn.transform.eulerAngles = new Vector3(90, 0, 0);
        amuIn.transform.localScale = new Vector3(1, 1, 1);
        amuIn.transform.parent = null;
        amuIn.name = "amu";
        Destroy(amuIn, 1.2f);
        Reproductor.clip = sonDisparo;
        Reproductor.Play();
        tiro.Play();
    }

    public void Bomb()
    {
        bomb = Instantiate(bombPre, gameObject.transform);
        bomb.transform.position = transform.position;
        bomb.transform.eulerAngles = new Vector3(90, 0, 0);
        bomb.transform.localScale = new Vector3(2.5f, 2, 2.5f);
        bomb.transform.parent = null;
        bomb.name = "bomb";
        Destroy(bomb, 1.2f);
        Reproductor.clip = sonDisparo;
        Reproductor.Play();
        tiro.Play();
    }

    public void Chispaso()
    {
        tiro.Stop();
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.GetComponent<Enemigo0>() || coll.gameObject.GetComponent<Enemigo1>() || coll.gameObject.GetComponent<Enemigo2>() || coll.gameObject.GetComponent<Boss>() || coll.gameObject.GetComponent<DisparoBoss>())
        {
            Destroy(gameObject, 0.7f);
            Destroy(coll.gameObject);
            explosion.Play();
            Reproductor.clip = sonExplosion;
            Reproductor.Play();
            mensLose.SetActive(true);
            salir.gameObject.SetActive(true);
            reset.gameObject.SetActive(true);
        }
        else if (coll.gameObject.GetComponent<AmuEnemy>() && vidaMenos == false)
        {
            sangre -= 5;
            blood.fillAmount -= 0.05f;
            Destroy(coll.gameObject);
            if (sangre <= 0)
            {
                vidas -= 1;
                sangre = 100;
                blood.fillAmount = 1;
                transform.position = new Vector3(0, 8, -6);
                vidaMenos = true;
                if (vidas <= 0)
                {
                    Destroy(gameObject);
                    mensLose.SetActive(true);
                    salir.gameObject.SetActive(true);
                    reset.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            explosion.Stop();
        }
    }

    IEnumerator VerificaDaño()
    {
        while (true)
        {
            if (vidaMenos)
            {
                StartCoroutine("CambiaMaterial");
                yield return new WaitForSeconds(3);
                vidaMenos = false;
            }
            yield return new WaitForSeconds(0.01f);

        }
    }

    IEnumerator CambiaMaterial()
    {
        Material colorActual = tranparente.GetComponent<Renderer>().material;
        tranparente.GetComponent<Renderer>().material = matTrans;
        yield return new WaitForSeconds(0.3f);
        tranparente.GetComponent<Renderer>().material = colorActual;
        yield return new WaitForSeconds(0.3f);
        tranparente.GetComponent<Renderer>().material = matTrans;
        yield return new WaitForSeconds(0.3f);
        tranparente.GetComponent<Renderer>().material = colorActual;
        yield return new WaitForSeconds(0.3f);
        tranparente.GetComponent<Renderer>().material = matTrans;
        yield return new WaitForSeconds(0.3f);
        tranparente.GetComponent<Renderer>().material = colorActual;
        yield return new WaitForSeconds(0.3f);
    }
}
