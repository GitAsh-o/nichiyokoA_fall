using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakFloorSc : MonoBehaviour
{
    // Start is called before the first frame update
    public static float floorhp = 1f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void breakfloor()
    {
        floorhp--;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (floorhp == 0)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
