using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEasyController : MonoBehaviour
{
    public QuestionAndAnswerSO[] data;

    [SerializeField]
    private int index;
    private int starIndex;

    [SerializeField]
    private GameObject[] photos;
    [SerializeField]
    private GameObject[] btns;
    [SerializeField]
    private GameObject[] stars;   
    [SerializeField]
    private GameObject winPanel,correctImg, wrongImg;

    private string auxString;

    private List<int> auxList;
    private List<int> auxListIndex;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        starIndex = 0;
        auxList = new List<int>();
        auxListIndex = new List<int>();
        RandomQuestion();
        SelectPhoto();
        DelegateBtnsAnswers();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BtnAction(string answer)
    {

        if (answer.Equals(data[index].answer, StringComparison.OrdinalIgnoreCase))
        {

            CorrectAnswer();
            
        }
        else
        {
            WrongAnswer();

        }
    }

    public void DelegateBtnsAnswers()
    {
        for (int i = 0; i < btns.Length; i++)
        {
            RandomAnswer();
            string answer = auxString;
            btns[i].GetComponent<Button>().onClick.AddListener(() => BtnAction(answer));
            Text text = btns[i].GetComponentInChildren<Text>();
            text.text = answer;

        }
    }

    public void RandomAnswer()
    {
        int x;

        do
        {
            x = UnityEngine.Random.Range(1, 4);
        }
        while (auxList.Contains(x));

        auxList.Add(x);
        Choose(x);
    }


    public void Choose(int x)
    {
        switch (x)
        {
            case 1:
                auxString = data[index].wrongA;
                break;

            case 2:
                auxString = data[index].wrongB;
                break;

            

            case 3:
                auxString = data[index].answer;
                break;
        }
    }

    public void CorrectAnswer()
    {
        
        for (int i = 0; i < btns.Length; i++)
        {

            btns[i].GetComponent<Button>().onClick.RemoveAllListeners();


        }
        auxList.Clear();
        RandomQuestion();
        SelectPhoto();
        DelegateBtnsAnswers();
        StartCoroutine(Correct());
    }

    public void AddNewStar()
    {
        stars[starIndex].SetActive(true);
        starIndex++;
    }

    public void WrongAnswer()
    {
        wrongImg.SetActive(true);

    }


    public void RandomQuestion()
    {
        int x;
        if (auxListIndex.Count == 5)
        {

            
            winPanel.SetActive(true);
        }
        else
        {
            do
            {
                x = UnityEngine.Random.Range(0, data.Length);
            }
            while (auxListIndex.Contains(x));
            auxListIndex.Add(x);
            index = x;
        }

    }

    public void SelectPhoto()
    {
        foreach(GameObject e in photos)
        {
            e.SetActive(false);
        }

        photos[data[index].photoIndex].SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator Correct()
    {
        AddNewStar();
        yield return new WaitForSeconds(1.5f);
        
    }

   
}
