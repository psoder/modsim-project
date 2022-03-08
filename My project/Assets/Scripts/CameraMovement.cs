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

    // Update is called once per frame
    void Update()
    {
      Vector3 pos = transform.position;

      if (Input.GetKey("a")  ){
          pos.z += panSpeed * Time.deltaTime;
      }
      
      if (Input.GetKey("d") ){
          pos.z -= panSpeed * Time.deltaTime;
      } 
      if (Input.GetKey("w")){
          pos.x += panSpeed * Time.deltaTime;
      } 
      if (Input.GetKey("s") ){
          pos.x -= panSpeed * Time.deltaTime;
      } 
      

      transform.position = pos;

    }
}
