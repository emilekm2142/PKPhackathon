using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CustomizationManager customizationManager;
    // Start is called before the first frame update
    private void Awake()
    {
        customizationManager = GameObject.FindObjectOfType<CustomizationManager>();
    }

    void Start()
    {
        
    }

    Train MakeTrain(TrainTypes type)
    {
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
