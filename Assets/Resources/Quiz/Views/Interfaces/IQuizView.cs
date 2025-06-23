using System;
using UnityEngine;

public interface IQuizView
{
    void SetCorrectResultText(string text);
    void SetQuestionNumberText(string text);
    void SetFullResultsText(string text);
    void SetVisibilityResults(bool isVisible);
    IQuestionView GetQuestionView();

    event Action OnNextButtonClicked;
    event Action OnBackButtonClicked;
}
