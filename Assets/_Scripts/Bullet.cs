using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    private Vector3 _direction;
    private float _force;
    private Rigidbody rigidBody;

	void Start ()
    {
        Destroy(this.gameObject, 3);
	    this.rigidBody = this.transform.GetComponent<Rigidbody>();
        if(!rigidBody)
            Debug.Log("BIRLL");
    }

    public void SetParameters(float force, Vector3 direction, Quaternion rotation)
    {
        this._direction = direction;
        this._force = force;
        this.transform.rotation = rotation;
    }
	
	void Update ()
	{
        this.rigidBody.AddForce(_direction * _force * Time.deltaTime);
    }
}
