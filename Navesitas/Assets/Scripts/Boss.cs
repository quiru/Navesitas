using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int mov = 1;
    int movHoriz = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int tmp = (int)Time.timeSinceLevelLoad;
        if (tmp > 15)
        {
            transform.position -= new Vector3(movHoriz, 0, mov * Time.deltaTime);
            if (tmp == 25)
            {
                movHoriz = -1;
            }
            if (transform.position.z <= 5)
            {
                mov = 0;
                if (transform.position.x > 4.5)
                {
                    movHoriz *= -1;
                }
            }
        }

    }
}
