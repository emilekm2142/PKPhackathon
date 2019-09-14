using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApiManager : MonoBehaviour
{
    private int userId = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Color GetColor()
    {
//        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        return new Color(1, 0, 1);
    }
    
}
