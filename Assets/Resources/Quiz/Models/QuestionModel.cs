using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestionModel : IQuestionModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public ICollection<IAnswerModel> Answers { get; set; }
    private IAnswerModel _selectedAnswer { get; set; }
    public IAnswerModel SelectedAnswer 
    {
        get => _selectedAnswer;
        set
        {
            if (_selectedAnswer != value)
            {
                _selectedAnswer = value;
                OnModelSelectedAnswerChanged?.Invoke(_selectedAnswer);
                Debug.Log($"Field '{nameof(SelectedAnswer)}' changed in model");
            }
        }
    }
    public event Action<IAnswerModel> OnModelSelectedAnswerChanged;

    public void SetSelectedAnswer(IAnswerModel answerModel)
    {
        SelectedAnswer = answerModel;
        foreach (IAnswerModel model in Answers)
        {
            if (model != answerModel && model.IsSelected)
            {
                model.IsSelected = false;
            }
        }
    }

}
