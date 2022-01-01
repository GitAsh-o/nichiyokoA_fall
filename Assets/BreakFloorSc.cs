using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorSc : MonoBehaviour
{
    // Start is called before the first frame update
    public float floorhp;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            floorhp --;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (floorhp == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
