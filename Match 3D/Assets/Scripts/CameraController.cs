using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float Padding = 1f;
    [SerializeField] bool inverted;
    [SerializeField] float speed = 0.25f;
    private Vector3 x = new Vector3(0, -1, 0);
    private Vector3 y = new Vector3(1, 0, 0);

    private void Start()
    {
        x = x * speed;
        y = y * speed;
        if (inverted)
        {
            x = -x;
            y = -y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x >= Screen.width - Padding)
        {
            this.transform.Rotate(x);
            // Debug.Log("RIGHT!");
        }
        else if (Input.mousePosition.x <= Padding)
        {
            this.transform.Rotate(-x);
            // Debug.Log("LEFT!");
        }
        if (Input.mousePosition.y >= Screen.height - Padding)
        {
            this.transform.Rotate(y);
            // Debug.Log("UP!");
        }
        else if (Input.mousePosition.y <= Padding)
        {
            this.transform.Rotate(-y);
            // Debug.Log("DOWN!");
        }
    }
}
