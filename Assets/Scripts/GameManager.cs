﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DefaultNamespace;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = System.Random;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
	public GameObject wagonPrefab;
	public GameObject railSegmentPrefab;
    public GameObject cityPrefab;
    public GameObject trainPrefab;
    public GameObject thomasPrefab;
    public GameObject pendolinoPrefab;
    public List<TrainPath> trainPaths  = new List<TrainPath>();
    public CustomizationManager customizationManager;
    public ApiManager apiManager;
    // Start is called before the first frame update
    private void Awake()
    {
        
        customizationManager = GameObject.FindObjectOfType<CustomizationManager>();
        apiManager = GameObject.FindObjectOfType<ApiManager>();
    }

    GameObject makeRails(List<Vector3> points, float offset)
    {
	    var go = Instantiate(railSegmentPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    var x = go.GetComponent<LineRenderer>();
    x.positionCount = points.Count;
    for (int i = 0; i < points.Count; i++)
    {
	    x.SetPosition(i, points[i] + new Vector3(offset,0,0));
    }

    return go;
    }
    void Start()
    {
        MakeCity("Poznan", new Vector3(14, 1.276719f, 25));
        LoadCities();
        var t = MakeTrain("Tomek", TrainTypes.Thomans, new Vector3(0, 0, 0));
        var l = MakeBezierBetweenTwoPoints(new Vector3(14, 0, 25), new Vector3(0, 0, 0), 15);
        for (var i2 =0; i2<l.Item1.Count-1; i2+=90){
	        Debug.DrawLine(l.Item1[i2], l.Item1[i2+1], Color.red, 1000);

        }

        makeRails(l.Item1, 0);
        makeRails(l.Item1, 2f);

        foreach (var user in apiManager.users)
        {
	        t.AddWagon(false);
        }
    }

    Train MakeTrain(string name, TrainTypes type, Vector3 position)
    {
	    var a = Instantiate(trainPrefab, position, Quaternion.identity);
        var train = a.GetComponent<Train>();
        train.name = name;
        GameObject lokomotywa = null;
        if (type == TrainTypes.Thomans)
        {
            lokomotywa = Instantiate(thomasPrefab, train.gameObject.transform);
        }
        else if(type == TrainTypes.Pendolino)
        {
            lokomotywa = Instantiate(pendolinoPrefab, train.gameObject.transform);
        }
        return train;
    }

    City MakeCity(string name, Vector3 position)
    {
        var a = Instantiate(cityPrefab, position, Quaternion.identity);
        a.gameObject.name = name;
        a.GetComponent<City>().name = name;
        return a.GetComponent<City>();
    }

    TrainPath MakePath(string name, Vector3 start, Vector3 end)
    {
	    var a =new TrainPath();
	    a.name = name;
	    a.points = MakeBezierBetweenTwoPoints(start, end, 25).Item1;
	    return a;
    }
    public Tuple<List<Vector3>, List<Vector3>> MakeBezierBetweenTwoPoints(Vector3 A, Vector3 D, float distance = 1.0f)
    {
	    float angle1 = UnityEngine.Random.Range(0.0f, 6.28f);
	    float angle2 = UnityEngine.Random.Range(0.0f, 6.28f);
	    angle1 = 0;
	    angle2 = 0;
	    Vector3 B = A + new Vector3(Mathf.Cos(angle1)*distance, 0, 0) + new Vector3(Mathf.Sin(angle1), 0, 0);
	    Vector3 C = D + new Vector3(Mathf.Cos(angle2)*distance, 0, 0) + new Vector3(Mathf.Sin(angle2), 0, 0);
	    
		int interpolationPoints = 1000;
		float dt = 1.0f / interpolationPoints;
		var curve = new List<Vector3>();
		var direction = new List<Vector3>();
		//Calculating the total length of the path to know what the interpolation distance should be
		float totalLength = 0;
		for (int i=1; i<interpolationPoints; i++){
			float t = i/interpolationPoints;
			Vector3 derivative = (-A*3*Mathf.Pow((1-t),2) + 3*B*Mathf.Pow((1-t),2) - 6.0f*B*t*(1-t) +6.0f*C*t*(1-t)-3*C*t*t + 3*D*t*t);
			float speed = Mathf.Sqrt(derivative[0]*derivative[0] + derivative[1]*derivative[1]+ derivative[2]*derivative[2]);
			totalLength += speed * dt;
		}
		
	    float t2 = 0;
	    float interpolationLength = 0.1f;
	    //calculating the number of samples in the final path
	    interpolationPoints = (int)(totalLength / interpolationLength);
		while (t2<1){
			Vector3 curvePoint = A*Mathf.Pow((1-t2),3) + 3*B*t2*(1-t2)*(1-t2) + 3*C*t2*t2*(1-t2) + D*t2*t2*t2;
			Vector3 derivative = (-A*3*Mathf.Pow((1-t2),2) + 3*B*Mathf.Pow((1-t2),2) - 6*B*t2*(1-t2) +6*C*t2*(1-t2)-3*C*t2*t2 + 3*D*t2*t2);
			float speed = Mathf.Sqrt(derivative[0]*derivative[0] + derivative[1]*derivative[1]+ derivative[2]*derivative[2]);
			curve.Add(curvePoint);
			direction.Add(derivative/speed);
			t2 += interpolationLength / speed;
		}
		var tuple = new Tuple<List<Vector3>, List<Vector3>>(curve,direction);

		return tuple;
    }
	public Tuple<List<Vector3>, List<Vector3>> GenerateRails(Tuple<List<Vector3>, List<Vector3>> path, float trackWidth=1.0f)
    {
	    var left = new List<Vector3>();
	    var right = new List<Vector3>();
	    for (int i = 0; i < path.Item1.Count; i++)
	    {
		    float x = path.Item1[i][0];
		    float y = path.Item1[i][1];
		    float z = path.Item1[i][2];
		    
		    float dirX = path.Item2[i][0];
		    float dirY = path.Item2[i][1];
		    float dirZ = path.Item2[i][2];
		    left.Add(new Vector3(x+dirZ, 0, z-dirX));
		    right.Add(new Vector3(x-dirZ, 0, z+dirX));
	    }
	    return new Tuple<List<Vector3>, List<Vector3>>(left, right);
    }

    private void LoadCities()
    {
    
	    for (int i = 0; i < Math.Min(10, apiManager.TrainRide.points.Count); i++)
	    {
		    Point point = apiManager.TrainRide.points[i];
		    MakeCity(point.stationName, new Vector3(100.0f * (float) point.lat, 1.276719f, 100.0f * (float) point.lng));
	    }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
