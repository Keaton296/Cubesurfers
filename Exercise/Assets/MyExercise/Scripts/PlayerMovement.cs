using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float range = 2;
    public float sensivity = 1;
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (transform.position.x <= range && transform.position.x >= -range && (Input.GetMouseButton(0)|| Input.touchCount == 1)) //Checking the object if it's in the range might be not appropiate for performance since I control the transform
        {
            transform.position += new Vector3(Input.GetAxis("Mouse X") * sensivity * Time.deltaTime,0,0);
            //transform.position += new Vector3(Input.touches[0].deltaPosition.x * sensivity * Time.deltaTime,0,0);
        }
        //The rest of the code makes sure player is in the specified area.
        if (transform.position.x > range)
        {
            transform.position = new Vector3(range,transform.position.y,transform.position.z);
        }
        else if(transform.position.x < -range)
        {
            transform.position = new Vector3(-range,transform.position.y,transform.position.z);
        }
    }
}
