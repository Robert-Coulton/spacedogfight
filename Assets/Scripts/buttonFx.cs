using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFx : MonoBehaviour
{
    // Start is called before the first frame update
    public void HoverSound()
    {
        AudioManager.instance.Play("buttonHoverFx");
    }

    // Update is called once per frame
    public void ClickSound()
    {
        AudioManager.instance.Play("buttonClick");
    }
}
