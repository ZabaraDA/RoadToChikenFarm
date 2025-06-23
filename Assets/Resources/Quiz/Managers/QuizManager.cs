using Newtonsoft.Json;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _quizPanel;
    private IQuizPresenter _quizPresenter;

    private void Start()
    {
        ICollection<IQuestionModel> questionList = new List<IQuestionModel>();

        foreach (var question in GetQuizData())
        {
            ICollection<IAnswerModel> answerList = new List<IAnswerModel>();
            foreach (var answer in question.Answers)
            {
                IAnswerModel answerModel = new AnswerModel
                {
                    Id = answer.Id,
                    Text = answer.Text,
                    IsCorrect = answer.IsCorrect
                };
                answerList.Add(answerModel);
            }
            IQuestionModel questionModel = new QuestionModel
            {
                Id = question.Id,
                Text = question.Text,
                Answers = answerList
            };
            questionList.Add(questionModel);
        }

        IQuizView quizView = _quizPanel.GetComponent<QuizView>();
        IQuizModel quizModel = new QuizModel(questionList);
        IQuizPresenter quizPresenter = new QuizPresenter(quizView, quizModel);

        quizPresenter.Initialize();
        _quizPresenter = quizPresenter;
    }

    private void OnDestroy()
    {
        _quizPresenter.Dispose();
    }

    private List<Question> GetQuizData()
    {
        TextAsset text = Resources.Load<TextAsset>("Json/QuizJson");
        Debug.Log("QuizJson success read");
        var quizContainer = JsonConvert.DeserializeObject<JsonContainer<List<Question>>>(text.text);

        return quizContainer.Value;
    }
}
