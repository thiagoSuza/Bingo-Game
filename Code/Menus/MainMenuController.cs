using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject mainPanel,selectDificultyPanel;
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        selectDificultyPanel.SetActive(false);
    }

    public void SelectLevel()
    {
        mainPanel.SetActive(false);
        selectDificultyPanel.SetActive(true);
    }

    public void MainMenu()
    {
        mainPanel.SetActive(true);
        selectDificultyPanel.SetActive(false);
    }
}
