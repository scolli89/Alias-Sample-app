using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    ///<summary>
    /*
    This is the abstract class that all of the clickable scripts will inherit from. 
    The main features are the OnMouseDown method for which the clickable classes's Clicked method is then called. 
    Each child class would override the abstract Clicked with the functionality approprate to their class. 
    Finaly, since the hide_other_objects.cs Clicked is intended to hide all other object accept for itself, it was needed that each clickable was able to be toggled. 
    So the ToggleMesh method ensures that each instance of a clickable can be toggle. This is to be called by the ClickableManager of the scene.
    */
    ///</summary>

    ///<notes>
    /*
    It is assummed that the hide_other_objects class's Clicked functionality is intented to only toggle the visibility of other CLickable subclasses. 
    */
    ///</notes>

    public ClickableManager manager;
    private MeshRenderer mesh;
    private void Awake(){
        mesh = GetComponent<MeshRenderer>(); // assignmend moved here so it only needs to be called once/ 
    }
    private void OnMouseDown()
    {
        Clicked();
    }
    public abstract void Clicked();

    public void ToggleMesh()
    {
        // MeshRenderer mesh = GetComponent<MeshRenderer>(); // moved to Awake as it is not 
        if (mesh != null)
        { // mesh renderer is present
            mesh.enabled = !mesh.enabled;
        }
    }
}
