using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    public GameObject amu;
    GameObject amuIn;

    void Start()
    {
        StartCoroutine("LlamaInvoke");
    }
    
    void Update()
    {
        //int tmp = (int)Time.timeSinceLevelLoad;
        //if (tmp > darBala)
        //{
        //    darBala += 3;
        //    dispara = true;
        //}
        //else
        //{
        //    dispara = false;
        //}
        //if (dispara)
        //{
        //    amuIn = Instantiate(amu, gameObject.transform);
        //    amuIn.transform.position = transform.position;
        //    amuIn.transform.localScale = new Vector3(1, 1, 1);
        //    //amuIn.transform.localPosition = new Vector3(18, 0, -1);
        //    amuIn.transform.eulerAngles = new Vector3(90, 0, 0);
        //    amuIn.transform.parent = null;
        //    Destroy(amuIn, 1.5f);
        //}
        
    }

    void Disparo()
    {
        amuIn = Instantiate(amu, gameObject.transform);
        amuIn.transform.position = transform.position;
        amuIn.transform.localScale = new Vector3(1, 1, 1);
        //amuIn.transform.localPosition = new Vector3(18, 0, -1);
        amuIn.transform.eulerAngles = new Vector3(90, 0, 0);
        amuIn.transform.parent = null;
        Destroy(amuIn, 1.5f);
    }

    IEnumerator LlamaInvoke()
    {
        while (true)
        {
            InvokeRepeating("Disparo", 0.1f, 0.2f);
            yield return new WaitForSeconds(3);
            CancelInvoke();
            yield return new WaitForSeconds(2);
        }
    }
}
