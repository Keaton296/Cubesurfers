using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : ScriptableObject
{       //Ive used scriptableobjects to make the list.
        public CubeColor color;
        public int index;
        public GameObject model;
        public PlayerCube(CubeColor _color,int _index,GameObject boxmodel,Material colormaterial)
        {
            color = _color;
            index = _index;
            model = boxmodel;
            boxmodel.GetComponent<MeshRenderer>().material = colormaterial;
        }
}
