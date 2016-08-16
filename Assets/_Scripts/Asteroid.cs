using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour
{
    public float Fator = 2;
    public float force = 400;
	void Start ()
	{
        Rigidbody rigid = this.GetComponent<Rigidbody>();

        Vector3 direction = Vector3.zero - this.transform.position;
        direction.Normalize();

        rigid.AddForce(direction * force);
        rigid.angularVelocity = Random.insideUnitSphere * Fator;
    }

	void Update ()
    {
        if((this.transform.position - Vector3.zero).magnitude > 80)
            Destroy(this.gameObject);
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
