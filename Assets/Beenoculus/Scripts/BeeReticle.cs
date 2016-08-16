using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeeReticle : MonoBehaviour
{

    private Material mat;
    private bool active = false;
    private float state = -1;

    void Start()
    {
        mat = this.GetComponent<Renderer>().material;

    }

    void Update()
    {

    }

    public void SetState(bool active, float state)
    {
        this.active = active;
        mat.SetFloat("_Fator", state);
    }
}
