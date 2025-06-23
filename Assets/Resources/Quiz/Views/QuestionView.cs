using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionView : MonoBehaviour, IQuestionView
{
    [SerializeField]
    private TMP_Text _questionText;
    [SerializeField]
    private GameObject _answerPanel;


    public void SetQuestionText(string text)
    {
        _questionText.text = text;
    }

    public void DestroyAllAnswer()
    {
        List<GameObject> childrenToDestroy = new List<GameObject>();

        for (int i = 0; i < _answerPanel.transform.childCount; i++)
        {
            Transform child = _answerPanel.transform.GetChild(i);
            if (child.gameObject.GetComponent<AnswerView>() != null)
            {
                childrenToDestroy.Add(child.gameObject);
            }
        }

        foreach (GameObject child in childrenToDestroy)
        {
            Debug.Log("Destroy " + child.name);
            Destroy(child);
        }
    }

    public GameObject LoadAnswer(GameObject answer)
    {
        var answerGameObject = Instantiate(answer);
        answerGameObject.transform.SetParent(_answerPanel.transform);

        return answerGameObject;
    }
}
