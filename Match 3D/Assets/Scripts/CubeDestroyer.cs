using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    [SerializeField] Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().isTrigger)
        {
            if (other.gameObject.GetComponent<Renderer>().material.color == coll.gameObject.GetComponent<Renderer>().material.color)
            {
                Debug.Log(other.gameObject.GetComponent<Renderer>().material.color);
            }
        }
    }
}
