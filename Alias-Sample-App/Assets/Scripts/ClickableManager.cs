using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableManager : MonoBehaviour
{
    ///<summary>
    /*
    The clickableManager is a class which is used to manage all instances of the scene's Clcikable spawned objects.
    The clickablemanager holds reference to all clickable scripts in the scene in the clicables list. 
    It iterates through the clickables list when its ToggleAllButThis method is called to toggle their mesh renderer. 
    AddEntry is used by the SceneSpawner to added the new clickables to the list. 
    */
    ///</summary>
    ///<notes>
    /*
    Making this class was seen to be better than the alternative of have each hide_other_objects have reference to each clickable.  
    */
    ///</notes>


    public List<Entry> clickables;
    public void Awake()
    {
        clickables = new List<Entry>();
    }
    public void AddEntry(string name, Clickable script)
    {
        clickables.Add(new Entry(name, script));
    }
    public void ToggleAllButThis(string caller)
    {
        foreach (Entry entry in clickables)
        {
            if (entry.key == caller)
            {
                continue;
            }
            entry.script.ToggleMesh();
        }
    }
}
