using UnityEngine;
using System.Collections;

public class BeeFocusButtom : MonoBehaviour
{

    public float TimeToActive = 1f;
    public  bool Focused { get { return focused;} }

    private bool focused = false;
    private float timeStamp = 0;
    private bool active = false;
    private BeeReticle reticle;

    void Start()
    {
        //procura pelo reticle na cena
        
        reticle = GameObject.FindObjectOfType<BeeReticle>();
        //se o reticle nao tiver na cena ele só avisa
        if(!reticle)
            Debug.LogWarning("reticle not found, check the camera");
    }

    void Update()
    {
        //se o objeto estiver sendo focado
        if (active)
        {
            //se o objeto foi focado pelo tempo nescessario
            if (focused)
            {
                active = false;
                focused = false;
                timeStamp = 0;
                if(reticle)
                    reticle.SetState(false, Map(timeStamp,0,TimeToActive, -1,1));
            }

            //soma o tempo :v
            timeStamp += Time.deltaTime;

            //checo se o reticle esta associado, se tiver o reticle é ativado 
            //e o valor do tempo é convertido entre -1~1
            if(reticle)
                reticle.SetState(true, Map(timeStamp, 0,TimeToActive, -1,1));

            //focou pelo tempo  
            if (timeStamp > TimeToActive)
            {
                timeStamp = 0;
                focused = true;
            }
        }
        else
        {
            active = false;
            focused = false;
            timeStamp = 0;
            if (reticle)
                reticle.SetState(false, Map(timeStamp, 0, TimeToActive, -1, 1));
        }
    }

    //função chamada quando o objeto é focado
    public void OnEnterFocus() {this.active = true; Debug.Log("entro");}

    //função chamada quando o objeto sai de foco
    public void OnExitFocus() {this.active = false; Debug.Log("saiu"); }

    //converte um valor de um range pra outro 
    private float Map(float x, float in_min, float in_max, float out_min, float out_max)
    { return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min; }
}
