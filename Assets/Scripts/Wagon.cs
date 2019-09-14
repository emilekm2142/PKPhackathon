using System.Collections;
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
