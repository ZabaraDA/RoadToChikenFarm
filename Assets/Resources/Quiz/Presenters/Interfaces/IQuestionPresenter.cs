using System;
using UnityEngine;

public interface IQuestionPresenter : IInitializable, IDisposable
{
    void LoadAnswer();

    event Action<IAnswerModel> OnAnswerSelected;
}
