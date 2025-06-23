using System;
using UnityEngine;

public interface IAnswerModel
{
    int Id { get; set; }
    string Text { get; set; }
    bool IsCorrect { get; set; }
    bool IsSelected { get; set; }

    event Action<bool> OnModelIsSelectedChanged;
}
