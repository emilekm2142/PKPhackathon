using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    public bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnTriggerEnter(Collider other){
        colliding =true;
    }

    public void OnTriggerStay(Collider other)
    {
       // colliding = true;
    }

    public void OnTriggerExit(Collider other){
        colliding =false;
    }
    private TrainPath currentPath;

    public void FollowPath(TrainPath path)
    {
        currentPath = path;
        var i = 0;
        Run.EachFrame(() =>
        {
            if (!colliding)
            {
                if (i < currentPath.points.Count - 1)
                {
                    gameObject.transform.position = currentPath.points[i];
                    gameObject.transform.LookAt(currentPath.points[i + 1]);
                    i++;
                }
            }
        });
    }

    bool IsPlayer()
    {
        return Utils.HasComponent<Player>(this.gameObject);
    }

    public void ChangeColor(Color c)
    {
        GetComponent<Renderer>().material.color = c;
    }

    public void ChangeTexture(Texture2D t)
    {
        GetComponent<Renderer>().material.mainTexture = t;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
