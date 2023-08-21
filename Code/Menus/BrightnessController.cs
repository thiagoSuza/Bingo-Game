using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    [SerializeField]
    private GameObject brightPanel;
    // Start is called before the first frame update
    void Start()
    {
        float brightness = PlayerPrefs.GetFloat("BG");
        
        brightPanel.GetComponent<Image>().color = new Color(0, 0, 0, brightness);
    }

  
}
