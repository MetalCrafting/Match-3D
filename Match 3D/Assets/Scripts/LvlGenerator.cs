using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] CubePrefabs;
    [SerializeField] Transform Field;
    [SerializeField] int size;
    private CubeDestroyer Cube;
    
    // Start is called before the first frame update
    void Start()
    {
        Transform[,,] Cubes = new Transform[size, size, size];
        foreach (Transform S in Field)
        {
            GameObject SpawnCube = CubePrefabs[UnityEngine.Random.Range(0, CubePrefabs.Length)];
            Instantiate(SpawnCube, S);
            Cube = SpawnCube.GetComponent<CubeDestroyer>();
            Cube.OwnSpawner = S.gameObject;
        }
    }
}
