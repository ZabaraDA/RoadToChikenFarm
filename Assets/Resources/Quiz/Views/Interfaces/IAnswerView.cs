using System;
using UnityEngine;
using UnityEngine.UI;

public interface IAnswerView
{
    event Action OnViewIsSelectedChanged;

    void SetColor(Color color);
    void SetText(string text);
}
