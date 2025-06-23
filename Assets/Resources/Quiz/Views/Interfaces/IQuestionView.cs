using System.Collections.Generic;
using UnityEngine;

public interface IQuestionView
{
    GameObject LoadAnswer(GameObject answer);
    void DestroyAllAnswer();
    void SetQuestionText(string text);
}
