using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMediumController : MonoBehaviour
{
     public QuestionAndAnswerMediumSO[] data;

    [SerializeField]
    private int index;
    private int starIndex;

    [SerializeField]
    private GameObject[] photos;
    [SerializeField]
    private GameObject[] stars;
    [SerializeField]
    private GameObject winPanel, correctImg, wrongImg;

    [SerializeField]  
    private Text auxString;

    private List<int> auxList;
    private List<int> auxListIndex;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        auxList = new List<int>();
        auxListIndex = new List<int>();
        RandomQuestion();
        SelectPhoto();       

    }

    
       

   /* public void CheckAnswer()
    {
        if(type.text.Equals(data[index].answer, StringComparison.OrdinalIgnoreCase))
        {
            CorrectAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }*/
   

    public void RandomAnswer()
    {
        int x;

        do
        {
            x = UnityEngine.Random.Range(1, 4);
        }
        while (auxList.Contains(x));

        auxList.Add(x);
        
    }
    public void AddNewStar()
    {
        stars[starIndex].SetActive(true);
        starIndex++;
    }




    public void CorrectAnswer()
    {       
        
        StartCoroutine(Correct());
        
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
        foreach (GameObject e in photos)
        {
            e.SetActive(false);
        }

        photos[data[index].photoIndex].SetActive(true);
        auxString.text = data[index].answer;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Replay()
    {
        SceneManager.LoadScene(3);
    }

    IEnumerator Correct()
    {
        AddNewStar();
        yield return new WaitForSeconds(1.5f);        
        auxList.Clear();
        RandomQuestion();
        SelectPhoto();
    }

    
}
