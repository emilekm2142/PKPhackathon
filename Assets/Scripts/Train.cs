using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public string name;

    public TrainPath currentPath;
    public bool isFollowingAnyPath = false;
    // Start is called before the first frame update
    public Thomas thomas;
    List<Wagon> wagons = new List<Wagon>();
    void Start()
    {
        
    }

    public void FollowPath(TrainPath path)
    {
        var d = Run.EachFrame(() =>
        {
            //run
            
        });

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
