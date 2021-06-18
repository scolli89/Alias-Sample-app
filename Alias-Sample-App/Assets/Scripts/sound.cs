using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : Clickable
{
    public override void Clicked()
    {
        Debug.Log("Sound Click");
        AudioSource audio =GetComponent<AudioSource>();
        audio.PlayOneShot(audio.clip,1);
    }
}
