using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_show_object : Clickable
{
    ///<summary>
    /*
    The hide_show_object.cs is one of the scripts described in the assignment pdf. This class simple toggles its mesh renderer on/off. 
    As described in the pdf, it is functinoaly even when hidden. 
    */
    ///</summary>
    public override void Clicked()
    {
        ToggleMesh();
    }
}
