using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amu : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, 10 * Time.deltaTime);
    }
}
