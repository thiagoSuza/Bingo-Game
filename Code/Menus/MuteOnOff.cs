using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MuteOnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject muteOn, MuteOff;
    [SerializeField]
    private AudioMixer theMixer;

    
    // Start is called before the first frame update
    void Start()
    {
        MuteOrNot();
    }

    public void MuteOrNot()
    {
        if(PlayerPrefs.GetInt("Mute") == 1)
        {
            MuteON();
        }
        else
        {
            MuteOFF();


        }
    }
    

    public void MuteON()
    {
        muteOn.SetActive(false);
        MuteOff.SetActive(true);
        theMixer.SetFloat("Master", -80f);
        PlayerPrefs.SetInt("Mute", 1);

    }

    public void MuteOFF()
    {
        muteOn.SetActive(true);
        MuteOff.SetActive(false);
        theMixer.SetFloat("Master",-10f);
        PlayerPrefs.SetInt("Mute", 0);
    }
}
