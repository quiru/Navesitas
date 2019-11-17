using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    int mov = 1;
    int movHoriz = 0;
    int sangre = 200;
    GameObject mensWin;
    public Button salir;
    public Button reset;
    public static int canonDestruidos = 0;

    void Start()
    {
        transform.GetComponent<Collider>().enabled = false;
        mensWin = GameObject.Find("TextMeshPro");
        mensWin.SetActive(false);
        salir.gameObject.SetActive(false);
        reset.gameObject.SetActive(false);
    }


    void Update()
    {
        int tmp = (int)Time.timeSinceLevelLoad;
        if (tmp > 90)
        {
            //gameObject.transform.GetChild(5).gameObject.SetActive(true);
            //gameObject.SetActive(true);
            transform.GetComponent<Collider>().enabled = true;
            transform.position -= new Vector3(movHoriz * Time.deltaTime, 0, mov * Time.deltaTime);
            if (tmp == 105)
            {
                movHoriz = 1;
            }
            if (transform.position.z <= 5)
            {
                mov = 0;
                if (transform.position.x <= 4.5)
                {
                    if (transform.position.x <= -4.5)
                    {
                        movHoriz *= -1; 
                    }
                }
                else
                {
                    movHoriz *= -1;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.transform.name == "amu")
        {
            Destroy(coll.gameObject);
            sangre -= 5;
            if (sangre <= 0 && canonDestruidos == 4)
            {
                Destroy(gameObject);
                mensWin.SetActive(true);
                salir.gameObject.SetActive(true);
                reset.gameObject.SetActive(true);

            }
        }
    }
}
