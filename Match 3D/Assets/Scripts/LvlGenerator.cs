using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] CubePrefabs;
    [SerializeField] Transform Field;
    [SerializeField] int size;
    
    // Start is called before the first frame update
    void Start()
    {
        Transform[,,] Cubes = new Transform[size, size, size];
        foreach (Transform S in Field)
        {
            Instantiate(CubePrefabs[UnityEngine.Random.Range(0, CubePrefabs.Length)], S);
        }
    }
}
