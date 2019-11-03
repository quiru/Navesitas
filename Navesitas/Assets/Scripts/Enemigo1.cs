using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{


    void Start()
    {
        
    }


    void Update()
    {
        transform.position -= new Vector3(0, 0, 3 * Time.deltaTime);
        if (transform.position.z < -9 || gameObject == null)
        {
            transform.position = new Vector3(Random.Range(-5, 6), 8, 9);
        }
    }
}
