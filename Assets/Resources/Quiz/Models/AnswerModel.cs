using System;
using UnityEngine;

public class AnswerModel : IAnswerModel
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }

    private bool _isSelected;

    public event Action<bool> OnModelIsSelectedChanged;

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                OnModelIsSelectedChanged?.Invoke(_isSelected);
                Debug.Log($"Field '{nameof(IsSelected)}' changed in model");
            }
        }
    }
}
