using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public GameObject cityPrefab;
    public GameObject trainPrefab;
    public GameObject thomasPrefab;
    public GameObject pendolinoPrefab;
    public List<TrainPath> trainPaths  = new List<TrainPath>();
    public CustomizationManager customizationManager;
    // Start is called before the first frame update
    private void Awake()
    {
        
        customizationManager = GameObject.FindObjectOfType<CustomizationManager>();
    }

    void Start()
    {
        MakeCity("Poznan", new Vector3(14, 1.276719f, 25));
        var t = MakeTrain("Tomek", TrainTypes.Thomans, new Vector3(0, 0, 0));

        var l = MakeBezierBetweenTwoPoints(new Vector3(14, 1.276719f, 25), new Vector3(0, 0, 0), 5);
        
        for (var i2 =0; i2<l.Item1.Count-1; i2++){
	        Debug.DrawLine(l.Item1[i2], l.Item1[i2+1], Color.red, 1000);
        }
        var i = 0;
        Run.EachFrame(() =>
        {
	       // Debug.Log("joy");
	  
	        if (i<l.Item1.Count-1){
		       
		        t.gameObject.transform.position = l.Item1[i];
		        t.gameObject.transform.rotation = Quaternion.Euler(l.Item2[i]);
		        i+=200;
	        }
	        
        });
       
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
        a.GetComponent<City>().name = name;
        return a.GetComponent<City>();
    }
    
    public Tuple<List<Vector3>, List<Vector3>> MakeBezierBetweenTwoPoints(Vector3 A, Vector3 D, float distance = 1.0f)
    {
	    float angle1 = UnityEngine.Random.Range(0.0f, 6.28f);
	    float angle2 = UnityEngine.Random.Range(0.0f, 6.28f);
	    Vector3 B = A + new Vector3(Mathf.Cos(angle1)*distance, 0, 0) + new Vector3(Mathf.Sin(angle1), 0, 0);
	    Vector3 C = D + new Vector3(Mathf.Cos(angle2)*distance, 0, 0) + new Vector3(Mathf.Sin(angle2), 0, 0);
	    
		int interpolation_points = 10000;
		var curve = new List<Vector3>();
		var direction = new List<Vector3>();
		//Calculating the total length of the path to know what the interpolation distance should be
		float totalLength = 0;
		for (int i=1; i<interpolation_points; i++){
			float t = i/interpolation_points;
			Vector3 derivative = (-A*3*Mathf.Pow((1-t),2) + 3*B*Mathf.Pow((1-t),2) - 6.0f*B*t*(1-t) +6.0f*C*t*(1-t)-3*C*t*t + 3*D*t*t);
			float speed = Mathf.Sqrt(derivative[0]*derivative[0] + derivative[1]*derivative[1]);
			totalLength += speed;
		}
		
	    float t2 = 0;
		while (t2<1){
			Vector3 curvePoint = A*Mathf.Pow((1-t2),3) + 3*B*t2*(1-t2)*(1-t2) + 3*C*t2*t2*(1-t2) + D*t2*t2*t2;
			Vector3 derivative = (-A*3*Mathf.Pow((1-t2),2) + 3*B*Mathf.Pow((1-t2),2) - 6*B*t2*(1-t2) +6*C*t2*(1-t2)-3*C*t2*t2 + 3*D*t2*t2);
			float speed = Mathf.Sqrt(derivative[0]*derivative[0] + derivative[1]*derivative[1]);
			curve.Add(curvePoint);
			direction.Add(derivative/speed);
			t2 += 1.0f/interpolation_points*(totalLength/interpolation_points)/speed;
		}
		var tuple = new Tuple<List<Vector3>, List<Vector3>>(curve,direction);

		return tuple;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
