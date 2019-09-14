using System;
using System.Collections;
using System.Collections.Generic;
using Classes;
using DefaultNamespace;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cityPrefab;
    public List<TrainPath> trainPaths  = new List<TrainPath>();
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

    City MakeCity(string name, Vector3 position)
    {
        var a = Instantiate(cityPrefab, position, Quaternion.identity);
        a.GetComponent<City>().name = name;
        return a.GetComponent<City>();
    }
    public List<Vector3> MakeBezierBetweenTwoPoints(Vector3 first, Vector3 second)
    {
        //return Vector3.Lerp(Vector3.Lerp(p0, p1, t), Vector3.Lerp(p1, p2, t), t);
        var a = new List<Vector3>();
        a.Add(first);
        a.Add(second);
        return a;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
