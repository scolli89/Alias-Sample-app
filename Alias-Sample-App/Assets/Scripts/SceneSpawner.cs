using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SceneSpawner : MonoBehaviour
{
    ///<summary>
    /*
    The sceneSpawner class is attacjed to a gameobject, given reference to the json file in the asset folder, 
    and given the list of entries into the spawnDictionary of the name of the prefab, as seen in the scene contents json, and the assoicated default object prefab.

    This class has several methods but all are called concurrently from the Start method. it was seperated for redability purposes. 
    Fill Dictionary populates the dictionary with the entries list so that quick look up of the key word and prefab pair can occur when instantiating the gameobjects.

    Read Json parses the provided json file and fills a list of GameObjectTospawn classes. These classes are just data holders for the list and are used to build the gameObjects later. 

    BuildGameScene iterates through the list of gameObjectToSpawns building the gameObject according to the provided data. 
    
    The Finish method destroys this object in the scene. It is reliant on the destroyAfterBuild variable to be true. 
    */
    ///</summary>

    ///<notes>
    /* 
    The soudPlaysAlawys = true; It is assumed that the intended functionality of the sound.cs class is to play the sound whether visible or not. 
    This variarble would change that functionality if the inteded effect was for the object to not play the sound when not visible. 

    The destroyAfterBuild = true. This class doesn't do anything once everything is built. It makes to remove it from the scene. However, this functionality can be toggled. 
    */
    ///</notes>



    [Space]
    [Header("Building Scene GameObjects")]

    Dictionary<string, GameObject> spawnDictionary;
    List<GameObjectToSpawn> gameObjectsToSpawn;
    public List<Entry> entries;
    public AudioClip soundClip;
    public TextAsset jsonFile;
    [Space]
    [Header("Assumption Variables")]
    public bool soundPlaysAlways = true;
    public bool destroyAfterBuild = true;

    void Start()
    {
        spawnDictionary = new Dictionary<string, GameObject>();
        FillDictionary();
        ReadJSON();
        BuildGameScene();
        Finish();
    }

    void FillDictionary()
    {
        foreach (Entry entry in entries)
        {
            spawnDictionary.Add(entry.key, entry.go);
        }
    }

    void ReadJSON()
    {
        gameObjectsToSpawn = new List<GameObjectToSpawn>();

        SpawnObjects game_objectsInJson = JsonUtility.FromJson<SpawnObjects>(jsonFile.text);
        foreach (var game_object in game_objectsInJson.game_objects)
        {

            GameObjectToSpawn go = new GameObjectToSpawn();
            go.type = game_object.type;
            go.script = game_object.script;
            go.position = new Vector3(game_object.position.x, game_object.position.y, game_object.position.z);
            gameObjectsToSpawn.Add(go);
        }
    }
    void BuildGameScene()
    {
        GameObject clickManagerGO = new GameObject();
        ClickableManager clickableManager = clickManagerGO.AddComponent<ClickableManager>();
        clickableManager.name = "ClickableManager";

        foreach (GameObjectToSpawn go in gameObjectsToSpawn)
        {
            GameObject clickGo = Instantiate(spawnDictionary[go.type], go.position, Quaternion.identity);
            Clickable click;
            // Clickable click = (new GameObject()).AddComponent<Clickable>();
            switch (go.script)
            {
                case ("hide_show_object.cs"):
                    Debug.Log("Hide show");
                    click = clickGo.AddComponent<hide_show_object>();
                    break;
                case ("hide_other_objects.cs"):
                    Debug.Log("Hide other");
                    click = clickGo.AddComponent<hide_other_objects>();
                    break;
                case ("sound.cs"):
                    Debug.Log("Sound");
                    AudioSource audio = clickGo.AddComponent<AudioSource>();
                    audio.clip = soundClip;
                    sound soundScript = clickGo.AddComponent<sound>();
                    soundScript.soundPlaysAlways = soundPlaysAlways;
                    click = (Clickable)soundScript;
                    break;
                default:
                    Debug.Log("no script added");
                    click = null;
                    break;
            }

            if (click == null)
            {
                continue;
            }

            click.manager = clickableManager;
            clickableManager.AddEntry(clickGo.name, click);




        }
    }
    void Finish()
    {
        if (destroyAfterBuild)
        {
            Destroy(this.gameObject);
        }
    }

}
