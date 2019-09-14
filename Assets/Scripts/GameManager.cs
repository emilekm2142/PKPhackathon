using System;
using System.Collections;
using System.Collections.Generic;
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
    public Tuple(List<Vector3>, List<Vector3>) MakeBezierBetweenTwoPoints(Vector3 A, Vector3 B, Vector3 C, Vector3 D)
    {
		interpolation_points = 10000;
		var curve = new List<Vector3>();
		var direction = new List<Vector3>();
		//Calculating the total length of the path to know what the interpolation distance should be
		double totalLength = 0;
		for (int i=1; i<interpolation_points; i++){
			double t = i/interpolation_points;
			Vector3 derivative = (-A*3*Math.pow((1-t),2) + 3*B*Math.pow((1-t),2) - 6*B*t*(1-t) +6*C*t*(1-t)-3*C*t*t + 3*D*t*t);
			double speed = Math.sqrt(derivative[0]*derivative[0] + derivative[1]*derivative[1]);
			totalLength += speed;
		}
		
		double t = 0;
		while (t<1){
			Vector3 curvePoint = A*Math.pow((1-t),3) + 3*B*t*(1-t)*(1-t) + 3*C*t*t*(1-t) + D*t*t*t;
			Vector3 derivative = (-A*3*Math.pow((1-t),2) + 3*B*Math.pow((1-t),2) - 6*B*t*(1-t) +6*C*t*(1-t)-3*C*t*t + 3*D*t*t);
			double speed = Math.sqrt(derivative[0]*derivative[0] + derivative[1]*derivative[1]);
			curve.Add(curvePoint);
			direction.Add(derivative/speed);
			t += 1/interpolation_points*(totalLength/interpolation_points)/speed;
		}
		Tuple(curve, direction);
		
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
