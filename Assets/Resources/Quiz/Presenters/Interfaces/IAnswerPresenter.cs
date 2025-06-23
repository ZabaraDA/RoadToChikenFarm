using System;
using UnityEngine;

public interface IAnswerPresenter : IInitializable, IDisposable
{
    event Action<IAnswerModel> OnAnswerSelected;
}
