using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] Collider coll;
    private Collider[] Neighbours = new Collider[26];
    public GameObject OwnSpawner;
    private int c = 0;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DestroyCubes();
        }
    }

    public void DestroyCubes()
    {
        if (c >= 2)
        {
            // Destroy( coll );
            foreach (Collider N in Neighbours)
            {
                if (N != null)
                {
                    CubeDestroyer Neighbour = N.gameObject.GetComponent<CubeDestroyer>();
                    Destroy(Neighbour.OwnSpawner);
                }
            }
            Neighbours = null;
            c = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!Neighbours.Contains(other))
        {
            if (other.GetComponent<Collider>().isTrigger)
            {
                if (other.gameObject.GetComponent<Renderer>().material.color == coll.gameObject.GetComponent<Renderer>().material.color)
                {
                    // Debug.Log(other.gameObject.GetComponent<Renderer>().material.color);
                    Neighbours[c] = other;
                    c++;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Neighbours.Contains(other))
        {
            for (int i = 0; i < Neighbours.Length; i++)
            {
                if ((Neighbours[i] == other))
                {
                    Neighbours[i] = null;
                    break;
                }
            }
        }
    }
}
