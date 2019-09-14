using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public string name;

    public string currentWayName;
    public List<Vector3> currentWay;
    public float timePassedSinceWayBegin;
    
    public bool isFollowingAnyPath = false;
    // Start is called before the first frame update
    public Thomas thomas;
    List<Wagon> wagons = new List<Wagon>();
    void Start()
    {
        
    }

    public void FollowPath(List<Vector3> path, float length)
    {
        isFollowingAnyPath = true;
        currentWayName = "Warszawa Inowroclaw";
        
    }

    public void AddWagon(Wagon w)
    {
        //make joint
        wagons.Add(w);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
