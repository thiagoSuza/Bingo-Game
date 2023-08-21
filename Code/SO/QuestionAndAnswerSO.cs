using UnityEngine;

[CreateAssetMenu(fileName = "Question 1", menuName = "ScriptableObjects/Q&A")]
public class QuestionAndAnswerSO : ScriptableObject
{
    public int photoIndex;
    public string wrongA;
    public string wrongB;
    public string answer;
}
