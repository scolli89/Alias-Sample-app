using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_other_objects : Clickable
{
    ///<summary>
    /*
    The hide_other_objects.cs is one of the scripts described in the assignment pdf. This class calls the clickablemanager, as inherited from CLickable, object's 
    ToggleAllButThis method to toggle all other clickable objects. 
    */
    ///</summary>
    ///</notes>
    /*
    It was assumed that the clickble was to be able to operate when not visible. As in clicking it when not visible would activate it's effect.
    */
    ///</notes>


    public override void Clicked()
    {
        manager.ToggleAllButThis(gameObject.name);
    }
}
