using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Clickable : MonoBehaviour
{
    public ClickableManager manager;
    private void OnMouseDown()
    {
        Clicked();
    }
    public abstract void Clicked();

    public void ToggleMesh()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh != null)
        { // mesh renderer is present
            mesh.enabled = !mesh.enabled;
        }
    }
}
