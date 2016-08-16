using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtom : MonoBehaviour
{

    private BeeFocusButtom beeButtom;
  
    void Start()
    {
        beeButtom = this.GetComponent<BeeFocusButtom>();
    }

    void Update()
    {

        if (beeButtom.Focused)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
