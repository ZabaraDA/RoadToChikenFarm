using System;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestionModel
{
    int Id { get; set; }
    string Text { get; set; }
    ICollection<IAnswerModel> Answers { get; set; }
    IAnswerModel SelectedAnswer { get; set; }

    event Action<IAnswerModel> OnModelSelectedAnswerChanged;
    void SetSelectedAnswer(IAnswerModel answerModel);

}
