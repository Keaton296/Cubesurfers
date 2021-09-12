using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //This is for every collectable box, they have speed variable but they should be edited from their random generator.
    public CubeColor collectablecolor;
    public float speed;
    void Update()
    {
        transform.position -= Vector3.forward * speed * Time.deltaTime;
        if (transform.position.z <= 7.5)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            col.gameObject.GetComponent<HeightHandler>().AddCube(collectablecolor);
             Destroy(gameObject);
        }
       
    }
}
