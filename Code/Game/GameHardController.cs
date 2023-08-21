using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameHardController : MonoBehaviour
{
    public static GameHardController instance;

    [SerializeField]
    private string[] emotions;
    [SerializeField]
    private Text emotionText;
    [SerializeField]
    private Button[] lineA;
    [SerializeField]
    private Button[] lineB;
    [SerializeField]
    private Button[] lineC;
    [SerializeField]
    private Button[] lineD;
    [SerializeField]
    private Button[] lineE;

    [SerializeField]
    private Button[] col1;
    [SerializeField]
    private Button[] col2;
    [SerializeField]
    private Button[] col3;
    [SerializeField]
    private Button[] col4;
    [SerializeField]
    private Button[] col5;

    [SerializeField]
    private Button[] diagonalS;
    [SerializeField]
    private Button[] diagonalI;

    [SerializeField]
    private Button randomEmotionBtn;


    [SerializeField]
    private string stringInUse;

    [SerializeField]
    private GameObject winPanel,correctImg,wrongImg,nextEmotionImg;

    private List<int> emotionsList;


    [SerializeField]
    private int auxA, auxB, auxC, auxD, auxE;
    [SerializeField]
    private int aux1, aux2, aux3, aux4, aux5;
    [SerializeField]
    private int auxD1, auxD2;

    public bool wrongOpt;

    [SerializeField]
    private GameObject wheelStatic, wheelPlay;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        emotionsList = new List<int>();
        wrongOpt = true;
    }

    public void RandomQuestion()
    {
      
        StartCoroutine(WheelPlay());
        

    }

    IEnumerator WheelPlay()
    {
        wheelStatic.SetActive(false);
        wheelPlay.SetActive(true);
        yield return new WaitForSeconds(2f);
        wheelStatic.SetActive(true);
        wheelPlay.SetActive(false); int x;

        wrongOpt = true;
        if (emotionsList.Count == 35)
        {

        }
        else
        {
            do
            {
                x = UnityEngine.Random.Range(0, emotions.Length);

            }
            while (emotionsList.Contains(x));
            emotionsList.Add(x);
            stringInUse = emotions[x];
            emotionText.text = stringInUse;
        }
        randomEmotionBtn.interactable = false;
    }

    public void Compare(string s)
    {
        if (s == stringInUse) 
        {
            StartCoroutine(CorrectAnswer());                  
            wrongOpt = false;
            randomEmotionBtn.interactable = true;
            emotionText.text = "- - - - -";

        }
        else
        {
            StartCoroutine (WrongAnswer());
        }
    }


  /*  public void CheckcorrectAnswer()
    {
        switch (stringInUse)
        {
            case "alegria":
                auxAccount++;
                if(auxAccount == 4)
                {
                    EmotionTaskCompleted();
                }
                break;
             case "amor":
                auxAccount++;
                if (auxAccount == 1)
                {
                    EmotionTaskCompleted();
                }
                break;
            case "medo":
                auxAccount++;
                if (auxAccount == 4)
                {
                    EmotionTaskCompleted();
                }
                break;
            case "raiva":
                auxAccount++;
                if (auxAccount == 4)
                {
                    EmotionTaskCompleted();
                }
                break;
            case "surpresa":
                auxAccount++;
                if (auxAccount == 2)
                {
                    EmotionTaskCompleted();
                }
                break;
            case "tristeza":
                auxAccount++;
                if (auxAccount == 4)
                {
                    EmotionTaskCompleted();
                }
                break;
        }
    }*/

    public void EmotionTaskCompleted()
    {
        
        StartCoroutine(Finished());
    }

    IEnumerator Finished()
    {
        yield return new WaitForSeconds(1.8f);
        nextEmotionImg.SetActive(true);
        yield return new WaitForSeconds(2f);
        nextEmotionImg.SetActive(false);
    }

    IEnumerator CorrectAnswer()
    {
        
        yield return new WaitForSeconds(1f);
        
    }

    IEnumerator WrongAnswer()
    {
        wrongImg.SetActive(true);
        yield return new WaitForSeconds(1f);
        wrongImg.SetActive(false);
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void CheckVictoryCondition()
    {
        
        foreach(Button b in lineA)
        {
            if(b.interactable == false)
            {
                auxA++;
            }
        }

        foreach (Button b in lineB)
        {
            if (b.interactable == false)
            {
                auxB++;
            }
        }

        foreach (Button b in lineC)
        {
            if (b.interactable == false)
            {
                auxC++;
            }
        }

        foreach (Button b in lineD)
        {
            if (b.interactable == false)
            {
                auxD++;
            }
        }

        foreach (Button b in lineE)
        {
            if (b.interactable == false)
            {
                auxE++;
            }
        }

        foreach (Button b in col1)
        {
            if (b.interactable == false)
            {
                aux1++;
            }
        }

        foreach (Button b in col2)
        {
            if (b.interactable == false)
            {
                aux2++;
            }
        }

        foreach (Button b in col3)
        {
            if (b.interactable == false)
            {
                aux3++;
            }
        }

        foreach (Button b in col4)
        {
            if (b.interactable == false)
            {
                aux4++;
            }
        }

        foreach (Button b in col5)
        {
            if (b.interactable == false)
            {
                aux5++;
            }
        }

        foreach (Button b in diagonalS)
        {
            if (b.interactable == false)
            {
                auxD1++;
            }
        }

        foreach (Button b in diagonalI)
        {
            if (b.interactable == false)
            {
                auxD2++;
            }
        }


        if (aux1 == 5 || aux2 ==5 || aux3 == 5 || aux4 ==5 || aux5 == 5) 
        {
            winPanel.SetActive(true);
        }
        else
        {
            aux1 = 0;
            aux2 = 0;
            aux3 = 0;
            aux4 = 0;
            aux5 = 0;
        }

        if (auxA == 5 || auxB == 5 || auxC == 5 || auxD == 5 || auxE == 5)
        {
            winPanel.SetActive(true);
        }
        else
        {
            auxA = 0;
            auxB = 0;
            auxC = 0;
            auxD = 0;
            auxE = 0;
        }

        if (auxD1 == 5 || auxD2 == 5 )
        {
            winPanel.SetActive(true);
        }
        else
        {
            auxD1 = 0;
            auxD2 = 0;
            
        }
    }
}
