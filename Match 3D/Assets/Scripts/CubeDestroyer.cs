using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] Collider coll;
    private Collider[] Neighbours;
    public GameObject OwnSpawner;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Neighbours.Length >= 2)
        {
            // Destroy( coll );
            while (Neighbours.Length > 0)
            {
                long i = Neighbours.Length - 1;
                CubeDestroyer Neighbour = Neighbours[i].gameObject.GetComponent<CubeDestroyer>();
                Destroy(Neighbour.OwnSpawner);
            }
            Neighbours = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().isTrigger)
        {
            if (other.gameObject.GetComponent<Renderer>().material.color == coll.gameObject.GetComponent<Renderer>().material.color)
            {
                Debug.Log(other.gameObject.GetComponent<Renderer>().material.color);
                Neighbours[Neighbours.Length] = other;
            }
        }
    }
}
