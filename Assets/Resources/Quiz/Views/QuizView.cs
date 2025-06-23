using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizView : MonoBehaviour, IQuizView
{
    [SerializeField]
    private GameObject _questionContainer;
    [SerializeField]
    private GameObject _resultsContainer;

    [SerializeField]
    private TMP_Text _questionNumberText;
    [SerializeField]
    private TMP_Text _quizCounterText;
    [SerializeField]
    private TMP_Text _resultsText;

    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private Button _menuButton;

    public event Action OnNextButtonClicked;
    public event Action OnBackButtonClicked;

    private void Start()
    {
        SetVisibilityResults(false);
        _nextButton.onClick.AddListener(HandleNextButtonClick);
        _backButton.onClick.AddListener(HandleBackButtonClick);
    }

    void OnDestroy()
    {
        if (_nextButton != null)
        {
            _nextButton.onClick.RemoveListener(HandleNextButtonClick);
        }
        if (_backButton != null)
        {
            _backButton.onClick.RemoveListener(HandleBackButtonClick);
        }
    }

    public IQuestionView GetQuestionView()
    {
        return _questionContainer.GetComponent<QuestionView>();
    }

    public void SetCorrectResultText(string text)
    {
        _quizCounterText.text = text;
    }

    private void HandleNextButtonClick()
    {
        OnNextButtonClicked?.Invoke();
    }

    private void HandleBackButtonClick()
    {
        OnBackButtonClicked?.Invoke();
    }

    public void SetVisibilityResults(bool isVisible)
    {
        _questionContainer.SetActive(!isVisible);
        _nextButton.gameObject.SetActive(!isVisible);
        _backButton.gameObject.SetActive(!isVisible);
        _menuButton.gameObject.SetActive(isVisible);
        _resultsContainer.SetActive(isVisible);
    }

    public void SetQuestionNumberText(string text)
    {
        _questionNumberText.text = text;
    }

    public void SetFullResultsText(string text)
    {
        _resultsText.text = text;
    }
}
