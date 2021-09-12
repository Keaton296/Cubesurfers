using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{   //This is for mountains to move.
    public float speed;
    void Update()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
        if (transform.position.z <= -4.46)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y,41.78f);
        }
    }
}
