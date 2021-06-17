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

    [System.Serializable]
    public class Entry
    {
        public string key;
        public GameObject value;

    }
    public List<Entry> entries;
    List<GameObjectToSpawn> gameObjectsToSpawn;







    void Start()
    {
        spawnDictionary = new Dictionary<string, GameObject>();
        FillDictionary();
        ReadJSON();
        BuildGameScene();
    }

    // Update is called once per frame
    void Update()
    {

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
            spawnDictionary.Add(entry.key, entry.value);
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
        foreach (GameObjectToSpawn go in gameObjectsToSpawn)
        {
            GameObject g = Instantiate(spawnDictionary[go.type], go.position, Quaternion.identity);


        }
    }


}
