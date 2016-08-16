using UnityEngine;
using System.Collections;

public class GizmoBox : MonoBehaviour
{

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(this.transform.position, this.GetComponent<BoxCollider>().size);
    }
}
