using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;

public class PresetManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public Preset GetPreset(int id)
    {
        return new Preset(
            new Color(1, 0, 1),
            new Texture2D(0, 0)
        );
    }
}
