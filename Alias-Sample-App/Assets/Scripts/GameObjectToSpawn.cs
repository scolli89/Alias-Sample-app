using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectToSpawn
{
    public string type;
    public string script; 
    public Vector3 position;
    public void Print(){
        Debug.Log("Type: "+ type);
        Debug.Log("Script: "+script);
        Debug.Log("Position: "+position);
    }
}
