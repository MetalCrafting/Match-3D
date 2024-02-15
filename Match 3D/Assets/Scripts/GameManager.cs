using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform Field;
    private GameObject FirstGameObj = null;
    private Transform FirstTrans = null;
    private GameObject SecondGameObj = null;
    private Transform SecondTrans = null;
    [SerializeField] float CubeSpeed = 10f;
    public int skyboxIndex;
    public Material[] skyboxes;
    
    // Start is called before the first frame update
    void Start()
    {
        // SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
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
                            FirstGameObj = CubeDest.OwnSpawner;
                            FirstTrans = FirstGameObj.transform;
                        }
                        else if (SecondGameObj == null)
                        {
                            SecondGameObj = CubeDest.OwnSpawner;
                            SecondTrans = SecondGameObj.transform;
                            SwapCubes(FirstGameObj, SecondGameObj, FirstTrans, SecondTrans);
                        }
                        else
                        {
                            FirstGameObj = null;
                            SecondGameObj = null;
                        }
                    }
                }
            }
        }
        RenderSettings.skybox = skyboxes[skyboxIndex];
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

    public void SwapCubes(GameObject Cube1, GameObject Cube2, Transform Pos1, Transform Pos2)
    {
        foreach (Transform spawner in Field)
        {
            if (spawner.gameObject.CompareTag("Spawner"))
            {
                spawner.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                spawner.gameObject.GetComponent<Collider>().enabled = false;
            }
        }

        while (Cube1.transform.position != Pos2.transform.position)
        {
            // Cube1.transform.Translate((Pos2.transform.position - Pos1.transform.position) * Time.deltaTime * CubeSpeed);
            // Cube2.transform.Translate((Pos1.transform.position - Pos2.transform.position) * Time.deltaTime * CubeSpeed);
            Cube1.transform.position = Pos2.transform.position;
            Cube2.transform.position = Pos1.transform.position;
        }

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
}
