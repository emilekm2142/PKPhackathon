﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GoToPosition(Vector3 position)
    {
        
    }

    bool IsPlayer()
    {
        return Utils.HasComponent<Player>(this.gameObject);
    }

    void ChangeColor(Color c)
    {
        GetComponent<Renderer>().material.color = c;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
