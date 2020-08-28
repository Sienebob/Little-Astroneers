using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider Volume;

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = Volume.value;
    }



}
