using UnityEngine;
using System.Collections;

public class Torret : MonoBehaviour
{
    public GameObject Bullet;
    public float ShotForce = 200;
    public float ShotInterval = 0.6f;

    private float timeStamp = 0;

	void Start () {}
	
	void Update ()
	{
        timeStamp += Time.deltaTime;

	    if (timeStamp > ShotInterval)
	    {
	        timeStamp = 0;
	        GameObject bullet = (GameObject) Instantiate(Bullet, new Vector3(this.transform.position.x, this.transform.position.y - 0.5f, this.transform.position.z), Quaternion.identity);

	        Vector3 direction = this.transform.rotation*Vector3.forward;
            Debug.Log("direction: " + direction);

            bullet.GetComponent<Bullet>().SetParameters(ShotForce, direction, this.transform.rotation);
	    }
	}
}
