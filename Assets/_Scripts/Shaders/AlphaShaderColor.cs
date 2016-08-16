using UnityEngine;
using System.Collections;

public class AlphaShaderColor : MonoBehaviour
{
    private Renderer renderer;

    private Color colorToGo = new Color(0.1f, 0.2f, 0.3f, 0.0f);

    void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }

    public void SetColor(Color color)
    {
        colorToGo = color;
        breakLoop = true;
        renderer.material.SetColor("_Color", color);
    }

    public Color GetColor()
    {
        return renderer.material.GetColor("_Color");
    }

    public void SetColor(Color color, float time)
    {
        if (colorToGo == color)
        {
            return;
        }
        else
        {
            colorToGo = color;
            breakLoop = true;
        }
        StartCoroutine(this._SettingColor(color, time));
    }

    private bool breakLoop = false;

    IEnumerator _SettingColor(Color color, float time)
    {
        yield return new WaitForEndOfFrame();
        breakLoop = false;
        Color atual = renderer.material.GetColor("_Color");
        float timeStamp = 0;
        while (timeStamp < 1)
        {
            timeStamp += (Time.deltaTime/time);
            renderer.material.SetColor("_Color", Color.Lerp(atual, color, timeStamp));
            if (breakLoop)
            {
                breakLoop = false;
                break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
