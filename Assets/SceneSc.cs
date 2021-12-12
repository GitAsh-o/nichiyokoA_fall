using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stage()
    {
        SceneManager.LoadScene("main");
    }

    public void home()
    {
        SceneManager.LoadScene("Home");
    }
}
