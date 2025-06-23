using System;
using UnityEngine;

public class AnswerPresenter : IAnswerPresenter
{
    private IAnswerView _answerView;
    private IAnswerModel _answerModel;

    public event Action<IAnswerModel> OnAnswerSelected;

    public AnswerPresenter(IAnswerView answerView, IAnswerModel answerModel)
    {
        _answerView = answerView;
        _answerModel = answerModel;
    }

    public void Dispose()
    {
        _answerModel.OnModelIsSelectedChanged -= OnModelIsSelectedChanged;
        _answerView.OnViewIsSelectedChanged -= OnViewIsSelectedChanged;
    }

    public void Initialize()
    {
        _answerModel.OnModelIsSelectedChanged += OnModelIsSelectedChanged;
        _answerView.OnViewIsSelectedChanged += OnViewIsSelectedChanged;
        OnModelIsSelectedChanged(_answerModel.IsSelected);
        _answerView.SetText(_answerModel.Text);
    }

    private void OnViewIsSelectedChanged()
    {
        _answerModel.IsSelected = !_answerModel.IsSelected;
        OnAnswerSelected?.Invoke(_answerModel);
        Debug.Log("IsSelected: " + _answerModel.IsSelected);
    }
    private void OnModelIsSelectedChanged(bool isSelected)
    {
        if (isSelected)
        {
            _answerView.SetColor(new Color(255 / 255f, 136 / 255f, 0 / 255f, 255 / 255f));
        }
        else
        {
            _answerView.SetColor(new Color(217 / 255f, 217 / 255f, 217 / 255f, 255 / 255f));
        }
    }
}
