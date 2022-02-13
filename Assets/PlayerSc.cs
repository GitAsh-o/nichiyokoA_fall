using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSc : MonoBehaviour
{
    [SerializeField] private DrawLine dLine = default;　//予測起動を表示

    [SerializeField] private GameObject Text;

    float a = 0.5f;
    float b = 0.1f;
    float c = 0.9f;
    float sita = 0;
    float speed = 8f;
    int jump = 0;
    int checknum = 0;
    public GameObject offset;
    public GameObject drawCube;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
        sita = a * (Mathf.PI);
        drawCube = GameObject.Find("DrawLine");
        drawCube.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (jump == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(Mathf.Cos(sita) * speed, Mathf.Sin(sita) * speed, 0);
                rb.gravityScale = 1f;
                jump = 0;
                transform.parent = null;
                Text.SetActive(false);
                drawCube.SetActive(false);
                a = 0.5f;
                b = 0.1f;
                c = 0.9f;
                DeletewallSc.istouch = false;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                a += (0.75f * Time.deltaTime);
                if (a >= c)
                {
                    a = c;
                }
                sita = a * (Mathf.PI);
                offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
                drawCube.SetActive(true);
                drawCube.GetComponent<DrawLine>().Set(new Vector3(Mathf.Cos(sita) * speed, Mathf.Sin(sita) * speed, 0));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                a -= (0.75f * Time.deltaTime);
                if (a <= b)
                {
                    a = b;
                }
                sita = a * (Mathf.PI);
                offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
                drawCube.SetActive(true);
                drawCube.GetComponent<DrawLine>().Set(new Vector3(Mathf.Cos(sita) * speed, Mathf.Sin(sita) * speed, 0));
            }

            if (this.gameObject.transform.position.y < -10)
            {
                BreakFloorSc.floorhp = 1;
                GameObject[] bf = GameObject.FindGameObjectsWithTag("break");
                foreach (GameObject breakfloor in bf)
                {
                    breakfloor.SetActive(true);
                }
                if (checknum == 0)
                {
                    rb.velocity = Vector3.zero;
                    gameObject.transform.position = new Vector3(0, 4.375f, 0);
                }
                else if (checknum == 1)
                {
                    gameObject.transform.position = new Vector3(9, 14f, 0);
                }
                else if (checknum == 2)
                {
                    gameObject.transform.position = new Vector3(42.5f, 17f, 0);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.CompareTag("right wall"))
        {
            rb.gravityScale = 0;
            rb.velocity = Vector3.zero;
            jump = 1;
            a = 0f;
            b = -0.4f;
            c = 0.4f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("right");
        }
        if (col.gameObject.CompareTag("left wall"))
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
            jump = 1;
            a = 1.0f;
            b = 0.6f;
            c = 1.4f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("left");
        }
        if (col.gameObject.CompareTag("head wall"))
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
            jump = 1;
            a = 0.5f;
            b = 0.1f;
            c = 0.9f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("head");
        }
        if (col.gameObject.CompareTag("bottom wall"))
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
            jump = 1;
            a = -0.5f;
            b = -0.9f;
            c = -0.1f;
            sita = a * (Mathf.PI);
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
            Debug.Log("bottom");
        }
        if (col.gameObject.CompareTag("wall"))
        {
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
        }
        if (col.gameObject.CompareTag("moving wall"))
        {
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            transform.parent = GameObject.Find("Movingwall").transform;
        }
        if (col.gameObject.CompareTag("deletewall"))
        {
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            DeletewallSc.istouch = true;
        }
        if (col.gameObject.CompareTag("Damage"))
        {
            gameObject.transform.position = new Vector3(0, 4.375f, 0);
        }
        if (col.gameObject.CompareTag("floor"))
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
            jump = 1;
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
        }
        if (col.gameObject.CompareTag("newgoal"))
        {
            SceneManager.LoadScene("NewGoal");
        }
        if (col.gameObject.CompareTag("break"))
        {
            col.gameObject.GetComponent<BreakFloorSc>().breakfloor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakfloor"))
        {
            rb.velocity = Vector3.zero;
            rb.gravityScale = 0;
            jump = 1;
            offset.transform.rotation = Quaternion.Euler(0, 0, 180 * a - 90);
            Text.SetActive(true);
        }
        if (other.gameObject.CompareTag("Check"))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            checknum++;
        }
    }

    public void delete()
    {
        drawCube.SetActive(false);
    }
}
