using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestionPresenter : IQuestionPresenter
{
    private IQuestionView _questionView;
    private IQuestionModel _questionModel;

    private ICollection<IAnswerPresenter> answerPresenters;
    public QuestionPresenter(IQuestionView questionView, IQuestionModel questionModel)
    {
        _questionView = questionView;
        _questionModel = questionModel;
    }

    public event Action<IAnswerModel> OnAnswerSelected;

    public void Dispose()
    {
        foreach (var answerPresenter in answerPresenters)
        {
            answerPresenter.Dispose();
        }
    }

    public void Initialize()
    {
        answerPresenters = new List<IAnswerPresenter>();
        _questionView.DestroyAllAnswer();
        LoadAnswer();
    }

    public void LoadAnswer()
    {
        _questionView.SetQuestionText(_questionModel.Text);
        foreach (IAnswerModel answerModel in _questionModel.Answers)
        {
            GameObject loadedPrefab = Resources.Load<GameObject>("Prefabs/Answer");
            GameObject instantiateGameObject =  _questionView.LoadAnswer(loadedPrefab);

            IAnswerView answerView = instantiateGameObject.GetComponent<AnswerView>();
            IAnswerPresenter answerPresenter = new AnswerPresenter(answerView, answerModel);

            answerPresenter.OnAnswerSelected += HandleAnswerSelected;

            answerPresenter.Initialize();
            answerPresenters.Add(answerPresenter);
        }
    }

    private void HandleAnswerSelected(IAnswerModel selectedAnswerModel)
    {
        Debug.Log($"QuestionPresenter: Получил уведомление о выборе ответа: '{selectedAnswerModel.Text}'");

        

        _questionModel.SetSelectedAnswer(selectedAnswerModel);
    }

}