using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingwallSc : MonoBehaviour
{
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (12f > time && time >= 0f)
        {
            if (3f > time && time >= 0f)
            {
                transform.position += new Vector3(0f, 1.5f * Time.deltaTime, 0f);
            }
            else if (6f > time && time >= 3f)
            {
                transform.position += new Vector3(0f, 0f * Time.deltaTime, 0f);
            }
            else if (9f > time && time >= 6f)
            {
                transform.position += new Vector3(0f, -1.5f * Time.deltaTime, 0f);
            }
            else if (12f > time && time >= 9f)
            {
                transform.position += new Vector3(0f, 0f * Time.deltaTime, 0f);
            }
        }
        if (time >= 12f)
        {
            time = 0f;
        }
    }
}
