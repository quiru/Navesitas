using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCosas : MonoBehaviour
{

    
    void Update()
    {
        transform.position -= new Vector3(0, 0, 1.5f * Time.deltaTime);
        if (transform.position.z < -9)
        {
            transform.position = new Vector3(Random.Range(-10, 10), 0.5f, 9);
        }
    }
}
