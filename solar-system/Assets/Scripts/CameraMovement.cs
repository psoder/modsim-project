using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float panSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void FixedUpdate()
    {
        // Moves the camera
        float x = 0, y = 0, z = 0;
        if (Input.GetKey(KeyCode.S))
        {
            z = -panSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            z = panSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            x = -panSpeed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            x = panSpeed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            y = panSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            y = -panSpeed;
        }

        transform.Translate(new Vector3(x, y, z));


        // Rotate the camera side to side
        float rX = 0, rY = 0, rZ = 0;
        float rotationSpeed = 2;
        if (Input.GetKey(KeyCode.Q))
        {
            rY = -rotationSpeed;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rY = rotationSpeed;
        }

        // Rotate the camera up and down
        if (Input.GetKey(KeyCode.Alpha1))
        {
            rX = -rotationSpeed;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            rX = rotationSpeed;
        }

        transform.Rotate(new Vector3(rX, rY, rZ));
    }
}
