using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnsController : MonoBehaviour
{
    private Button click;
    [SerializeField]
    private GameObject used;
    


    private void Start()
    {
        used.SetActive(false);
        click = GetComponent<Button>();
    }
    public void OnDisable()
    {
        if(GameHardController.instance.wrongOpt == false)
        {
            click.interactable = false;
            GameHardController.instance.CheckVictoryCondition();
            used.SetActive(true);
        }
        
    }
}
