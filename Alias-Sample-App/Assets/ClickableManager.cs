using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableManager : MonoBehaviour
{
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
