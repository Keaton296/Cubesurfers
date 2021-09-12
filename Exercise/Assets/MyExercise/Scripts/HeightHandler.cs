using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightHandler : MonoBehaviour
{   //This is all the code that manages the tower. Mainly there are 3 methods that could be described as: add,check and rearrange
    //public int towerheight = 1;
    public float cubeheight; // this is the height of cubes in world unit.
    public Transform playertransform;   //this is the transform of player's model.
    public Material[] cubecolors = new Material[5]; 
    public GameObject playercubeinstance;
    public Transform playerblocks; //this is a parent for every player's cube
    public List<PlayerCube> cubes = new List<PlayerCube>(); //list that stores all cubes.
    public CubeColor addcolor; //this is just to add cubes via pressing space. for testing purposes.
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCube(addcolor);
            
        }
    }
    public void AddCube(CubeColor color)
    {
        //move all cubes 1 unit up
        //Add cube to the list and instantiate it at the bottom
        //Check all cubes if there is 5 color match, if true rearrange remaining cubes (SetBlocks method)
        MoveCubesUp();
        cubes.Add(new PlayerCube(color,cubes.Count,Instantiate(playercubeinstance,playerblocks.position,Quaternion.identity,playerblocks),cubecolors[(int)color]));
        CheckFiveColors();
        //SetBlocks();

    }
    void CheckFiveColors()
    {
        PlayerCube red = null; 
        PlayerCube green = null;
        PlayerCube yellow = null;
        PlayerCube purple = null;
        PlayerCube blue = null;
    foreach (PlayerCube item in cubes)
    {
        switch (item.color)
        {
            case CubeColor.Green:
                green = item;
            break;
            case CubeColor.Red:
                red = item;
            break;
            case CubeColor.Yellow:
                yellow = item;
            break;
            case CubeColor.Purple:
                purple = item;
            break;
            case CubeColor.Blue:
                blue = item;
            break;
        }
    }
       if (red != null && green != null && yellow != null && purple != null && blue != null)
       {
           Destroy(red.model);
           Destroy(green.model);
           Destroy(yellow.model);
           Destroy(purple.model);
           Destroy(blue.model);
           cubes.Remove(red);
           cubes.Remove(blue);
           cubes.Remove(green);
           cubes.Remove(purple);
           cubes.Remove(yellow);
           SetBlocks(); //Block placement will only be ruined after destroying five cubes, so if there's a destruction, Rearranging method is called.
       } 
    }
    void SetBlocks()
    {
        playertransform.position = transform.position + Vector3.up * cubes.Count * cubeheight/2*3;
        foreach (PlayerCube item in cubes)
        {
            item.index = cubes.FindIndex(a => a == item);
            item.model.transform.position = playerblocks.position + Vector3.up*(cubes.Count - item.index - 1)*cubeheight/2*3;
        }
    }
    void MoveCubesUp()
    {
        playertransform.position += Vector3.up*cubeheight/2*3; //For unknown reason for this specific gameobject,this transform moves 1/3 less than we demand. so I multiply the original value with 2/3.
        foreach (Transform item in playerblocks.GetComponentsInChildren<Transform>())
        {
            if (item == playerblocks)
            {
                continue;
            }
            item.position += Vector3.up * cubeheight/2*3;
        }
    }
}
public enum CubeColor
{
    Green,Red,Yellow,Blue,Purple
}
