using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class AsteroidsController : MonoBehaviour
{
    public GameObject Asteroid;
    public float PitchMin = -60;
    public float PitchMax = 60;
    public float WorldSize = 80;
    public float SpawnDelay = 5f;

    private float timeStamp = 0;
	
	void Update ()
	{
	    timeStamp += Time.deltaTime;
	    if (timeStamp > SpawnDelay)
	    {
	        Instantiate(Asteroid, this.GeneratePosition(), Quaternion.identity);
	        timeStamp = 0;
	    }
	}
    
    private Vector3 GeneratePosition()
    {
        float x, y, z;

        float pitch = Mathf.Deg2Rad*Random.Range(0, 360);
        float roll = Mathf.Deg2Rad*Random.Range(PitchMin, PitchMax);

        x = WorldSize*Mathf.Cos(roll)*Mathf.Sin(pitch);
        y = WorldSize*Mathf.Sin(roll)*Mathf.Sin(pitch);
        z = WorldSize*Mathf.Cos(pitch);

        return new Vector3(x,y,z);
    }
}
