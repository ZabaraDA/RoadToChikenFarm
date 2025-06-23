using UnityEngine;

public interface IQuizPresenter : IInitializable, IDisposable
{
    void LoadNextQuestion();
    void LoadBackQuestion();
    //bool TryGetNextQuestion();
    //bool TryGetBackQuestion();
}
