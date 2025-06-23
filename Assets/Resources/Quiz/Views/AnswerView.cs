using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AnswerView : MonoBehaviour, IAnswerView
{

    [SerializeField]
    private Button _button;
    [SerializeField]
    private Image _image;
    [SerializeField]
    private TMP_Text _text;

    public event Action OnViewIsSelectedChanged;

    private void Start()
    {
        //_image =  GetComponentInChildren<Image>().gameObject.GetComponentInChildren<Image>();
        //_text = GetComponent<TMP_Text>();
        //_button = GetComponent<Button>();
        _button.onClick.AddListener(OnAnswerClick);
        Debug.Log("AnswerView Start");
    }

    public void SetColor(Color color)
    {
        Debug.Log("AnswerView SetColor: " + color.ToString());
        _image.color = color;
    }

    public void OnAnswerClick()
    {
        OnViewIsSelectedChanged?.Invoke();
        Debug.Log("AnswerView OnAnswerClick");
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
