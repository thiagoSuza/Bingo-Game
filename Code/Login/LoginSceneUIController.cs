using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginSceneUIController : MonoBehaviour
{
    [SerializeField]
    private GameObject loginPanel, creatPanel,resetPanel;
    // Start is called before the first frame update
    void Start()
    {
        loginPanel.SetActive(true);
        creatPanel.SetActive(false);
        resetPanel.SetActive(false);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void ActiveCreatPanel()
    {
        loginPanel.SetActive(false);
        creatPanel.SetActive(true);
        resetPanel.SetActive(false);
    }

    public void ActiveLoginPanel()
    {
        loginPanel.SetActive(true);
        creatPanel.SetActive(false);
        resetPanel.SetActive(false);
    }

    public void ActiveResetPanel()
    {
        resetPanel.SetActive(true);
        creatPanel.SetActive(false);
    }
}
