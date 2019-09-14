using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    public Thomas thomas;
    List<Wagon> wagons = new List<Wagon>();
    void Start()
    {
        
    }

    public GoToPosition(Vector3 p)
    {
        this.transform.position = p;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
