using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform Field;
    private GameObject FirstGameObj = null;
    //private Transform FirstTrans = null;
    private GameObject SecondGameObj = null;
    //private Transform SecondTrans = null;
    [SerializeField] Material[] colors;
    [SerializeField] float CubeSpeed = 10f;
    [SerializeField] Saves saves;
    public long score = 0;
    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;
    [SerializeField] bool IsLvl = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLvl)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        highScoreText.text = "Highscore: " + saves.HighScore.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider != null)
                {
                    GameObject HitGO = hit.collider.gameObject;
                    if (HitGO.TryGetComponent<CubeDestroyer>(out CubeDestroyer CubeDest))
                    {
                        if (FirstGameObj == null)
                        {
                            FirstGameObj = CubeDest.OwnSpawner;/*
                            FirstTrans = FirstGameObj.transform;*/
                        }
                        else if (SecondGameObj == null)
                        {
                            SecondGameObj = CubeDest.OwnSpawner;/*
                            SecondTrans = SecondGameObj.transform;*/
                            SwapCubes(FirstGameObj, SecondGameObj/*, FirstTrans, SecondTrans*/);
                            FirstGameObj = null;
                            SecondGameObj = null;
                        }
                        /*else
                        {
                            FirstGameObj = null;
                            SecondGameObj = null;
                        }*/
                    }
                }
            }
        }
        if (score > saves.HighScore)
        {
            saves.HighScore = score;
        }
        RenderSettings.skybox = saves.skyboxes[saves.skyboxIndex];
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

    public void Play4x4x4()
    {
        SceneManager.LoadScene(2);
    }

    public void ToSettings()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void SwapCubes(GameObject Cube1, GameObject Cube2/*, Transform Pos1, Transform Pos2*/)
    {
        int colNum1 = Cube1.GetComponent<CubeDestroyer>().colorNum;
        int colNum2 = Cube2.GetComponent<CubeDestroyer>().colorNum;
        Material color1 = colors[colNum1];
        Material color2 = colors[colNum2];

        Cube1.GetComponent<MeshRenderer>().material = color2;
        Cube1.GetComponent<CubeDestroyer>().colorNum = colNum2;
        Cube2.GetComponent<MeshRenderer>().material = color1;
        Cube2.GetComponent<MeshRenderer>().material = color2;
        /*
        foreach (Transform spawner in Field)
        {
            if (spawner.gameObject.CompareTag("Spawner"))
            {
                spawner.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                spawner.gameObject.GetComponent<Collider>().enabled = false;
            }
        }

        Vector3 Move1 = Pos2.transform.position - Pos1.transform.position;
        Vector3 Move2 = Pos1.transform.position - Pos2.transform.position;

        while (Cube1.transform.position != Pos2.transform.position)
        {
            // Cube1.transform.Translate(Move1 * Time.deltaTime * CubeSpeed, Space.World);
            // Cube2.transform.Translate(Move2 * Time.deltaTime * CubeSpeed, Space.World);
            Cube1.transform.position = Pos2.transform.position;
            Cube2.transform.position = Pos1.transform.position;
        }

        if (Cube1.transform.position == Pos2.transform.position)
        {
            foreach (Transform spawner in Field)
            {
                if (spawner.gameObject.CompareTag("Spawner"))
                {
                    spawner.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    spawner.gameObject.GetComponent<Collider>().enabled = true;
                }
            }

            foreach (Transform cube in Field)
            {
                if (cube.TryGetComponent<CubeDestroyer>(out CubeDestroyer CubeDest))
                {
                    CubeDest.DestroyCubes();
                }
            }
        }
        */
    }
}
