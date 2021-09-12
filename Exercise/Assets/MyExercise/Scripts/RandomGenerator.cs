using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public float waitseconds = 1;
    public GameObject collectable;
    public Material[] mats = new Material[5];
    public float collectablespeed;
    void Start()
    {
        StartCoroutine(MakeCollectable());
    }
    IEnumerator MakeCollectable()
    {
        while (true)
        {
            int randomcolor = Random.Range(0,5);
            Debug.Log(randomcolor);
            GameObject newobject = Instantiate(collectable,transform.position + new Vector3(Random.Range(-0.14f,0.14f),0,0),Quaternion.identity);
            MeshRenderer objectrenderer = newobject.GetComponent<MeshRenderer>();
            Collectable objectcollectable = newobject.GetComponent<Collectable>();
            newobject.GetComponent<Collectable>().speed = collectablespeed;
            switch (randomcolor)
            {
                case 0:
                    objectcollectable.collectablecolor = CubeColor.Green;
                    objectrenderer.material = mats[0];
                break;
                case 1:
                    objectcollectable.collectablecolor = CubeColor.Red;
                    objectrenderer.material = mats[1];
                break;
                case 2:
                    objectcollectable.collectablecolor = CubeColor.Yellow;
                    objectrenderer.material = mats[2];
                break;
                case 3:
                    objectcollectable.collectablecolor = CubeColor.Blue;
                    objectrenderer.material = mats[3];
                break;
                case 4:
                    objectcollectable.collectablecolor = CubeColor.Purple;
                    objectrenderer.material = mats[4];
                break;
                
            }
            yield return new WaitForSeconds(waitseconds);
        }
    }
}
