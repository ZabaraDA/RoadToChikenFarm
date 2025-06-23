using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class QuizModel : IQuizModel
{
    public event Action<IQuestionModel> OnModelCurrentQuestionChanged;
    public event Action<ICollection<IQuestionModel>> OnModelQuestionListChanged;

    private IQuestionModel _currentQuestion;
    public IQuestionModel CurrentQuestion
    {
        get => _currentQuestion;
        set
        {
            if (_currentQuestion != value)
            {
                _currentQuestion = value;
                OnModelCurrentQuestionChanged?.Invoke(_currentQuestion);
                Debug.Log($"Field '{nameof(CurrentQuestion)}' changed in model");
            }
        }
    }
    public ICollection<IQuestionModel> QuestionList { get; set; }

    public QuizModel(ICollection<IQuestionModel> questionList)
    {
        QuestionList = questionList;
    }

    public int GetQuestionCount()
    {
        return QuestionList.Count();
    }
    public int GetCorrectQuestionCount()
    {
        return QuestionList.Where(x => x.SelectedAnswer.IsCorrect).Count();
    }

    public void LoadQuestion(IQuestionModel questionModel)
    {
        CurrentQuestion = questionModel;
    }
    private IQuestionModel TryGetQuestion(int questionId)
    {
        return QuestionList.FirstOrDefault(x => x.Id == questionId);
    }

    public bool TryGetNextQuestion(out IQuestionModel questionModel)
    {
        questionModel = TryGetQuestion(CurrentQuestion != null ? CurrentQuestion.Id + 1 : 1);
        return questionModel != null;
    }

    public bool TryGetBackQuestion(out IQuestionModel questionModel)
    {
        questionModel = TryGetQuestion(CurrentQuestion.Id - 1);
        return questionModel != null;
    }

}