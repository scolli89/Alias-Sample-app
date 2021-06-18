using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SceneSpawner : MonoBehaviour
{

    Dictionary<string, GameObject> spawnDictionary;
    public string pathToSpawnDirectory = "/Prefabs/SpawnableObjects";
    public string pathToJson = "/scene_contents.json";
    public TextAsset jsonFile;


    public List<Entry> entries;
    List<GameObjectToSpawn> gameObjectsToSpawn;
    public AudioClip sound;




    void Start()
    {
        spawnDictionary = new Dictionary<string, GameObject>();
        FillDictionary();
        ReadJSON();
        BuildGameScene();
    }

    void FillDictionary()
    {
        ///<TODO>
        /// This is a temparary solution.
        /// I want to change it from loading from the inspector to 
        /// reading the assets folder of the names in the file 
        ///then making a dictionary out of the names of files and the files
        ///</TODO>

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
                    audio.clip = sound;
                    click = clickGo.AddComponent<sound>();
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


}
