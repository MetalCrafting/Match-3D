using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RESET()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void Play4x4x4()
    {
        SceneManager.LoadScene(1);
    }
}