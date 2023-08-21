using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OptionsPanel : MonoBehaviour
{
    [SerializeField]
    private AudioMixer theMixer;

    [SerializeField]
    private GameObject panel,brightPanel;

    [SerializeField]
    private GameObject muteOn,MuteOff;

    [SerializeField]
    private Slider masterSlider, brightnessSlider;

    
  

   

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Master"))
        {
            theMixer.SetFloat("Master", PlayerPrefs.GetFloat("Master"));
            masterSlider.value = PlayerPrefs.GetFloat("Master");

        }

        if (PlayerPrefs.HasKey("BG"))
        {
            
            float brightness = PlayerPrefs.GetFloat("BG");
            brightnessSlider.value= brightness;
            brightPanel.GetComponent<Image>().color = new Color(0, 0, 0, brightness);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenPanel()
    {
        panel.SetActive(true);
    }


    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    public void MuteON()
    {
        muteOn.SetActive(false);
        MuteOff.SetActive(true);
        theMixer.SetFloat("Master", -80f);

    }

    public void MuteOFF()
    {
        muteOn.SetActive(true);
        MuteOff.SetActive(false);
        theMixer.SetFloat("Master", masterSlider.value);
    }
    public void SetMasterVol()
    {
        
        theMixer.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("Master", masterSlider.value);
    }
    public void SetBrightness()
    {
        float brightness = brightnessSlider.value;
        PlayerPrefs.SetFloat("BG", brightness);
        brightPanel.GetComponent<Image>().color = new Color(0, 0, 0, brightness);
        
    }

}
