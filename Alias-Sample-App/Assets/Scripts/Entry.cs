using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Entry
{
    ///<summary>
    // This class is intented to have two purposes.
    // 1. It is used to populated the SceneSpawner list of prefabs to spawn. Here the script field goes un used as non of the prefabs 
    // are supposed to have a script attached to them.
    // 2. It is used in the ClickableManager list of clickable scripts. Here the gameobject field goes un-used as the the gameobject is nolonger relevent, it only needs the script to work. 
    ///</summary>
    public Entry(){}
    public Entry(string key,GameObject go){
        this.key = key;
        this.go = go;
    }
    public Entry(string key,Clickable script){
        this.key = key;
        this.script = script;
    }
    public string key;
    public GameObject go; // used for the prefabs
    public Clickable script; // used for the instances, the script is the only thing that matters now. 

}
