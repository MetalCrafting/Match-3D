using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] Cubes;
    [SerializeField] Transform[] Spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform S in Spawner)
        {
            Instantiate(Cubes[Random.Range(0, Cubes.Length)], S);
        }
    }
}
