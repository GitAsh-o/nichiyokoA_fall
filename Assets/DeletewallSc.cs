using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletewallSc : MonoBehaviour
{
    float time = 0;
    bool isactive = true;
    public static bool istouch;
    public Rigidbody2D Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5.0f)
        {
            isactive = !isactive;
            if (istouch == true)
            {
                if (isactive == false)
                {
                    Player.gravityScale = 1;
                }
            }
            this.gameObject.GetComponent<SpriteRenderer>().enabled = isactive;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = isactive;
            time = 0f;
        }
    }
}
