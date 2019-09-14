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
        currentPath = path;
        var i = 0;
        Run.EachFrame(() =>
        {
            if (i < currentPath.points.Count - 1)
            {
                gameObject.transform.position = currentPath.points[i];
                gameObject.transform.LookAt(currentPath.points[i+1]);
                i++;
            }
        });
    }

    public void AddWagon(bool isPlayer)
    {
        var wagon = Instantiate(GameObject.FindObjectOfType<GameManager>().wagonPrefab, new Vector3(0, 0, 0),
            Quaternion.identity);
        wagons.Add(wagon.GetComponent<Wagon>());
    }


    // Update is called once per frame
    void Update()
    {
    }
}