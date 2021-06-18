using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_other_objects : Clickable
{
    public override void Clicked()
    {

        manager.ToggleAllButThis(gameObject.name);
    }
}
