using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizPresenter : IQuizPresenter
{
    private IQuizView _quizView;
    private IQuizModel _quizModel;
    private IQuestionPresenter _questionPresenter;
    public QuizPresenter(IQuizView quizView, IQuizModel quizModel) 
    {
        _quizModel = quizModel;
        _quizView = quizView;
    }

    public void Dispose()
    {
        _quizView.OnNextButtonClicked -= LoadNextQuestion;
        _quizView.OnBackButtonClicked -= LoadBackQuestion;
        _quizModel.OnModelCurrentQuestionChanged -= OnModelCurrentQuestionChanged;
        _questionPresenter.Dispose();
    }

    public void Initialize()
    {
        _quizView.OnNextButtonClicked += LoadNextQuestion;
        _quizView.OnBackButtonClicked += LoadBackQuestion;
        _quizModel.OnModelCurrentQuestionChanged += OnModelCurrentQuestionChanged;
        LoadNextQuestion();
    }

    public void LoadBackQuestion()
    {

        if (_quizModel.TryGetBackQuestion(out IQuestionModel questionModel))
        {
            LoadQuestion(questionModel);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LoadNextQuestion()
    {

        if (_quizModel.TryGetNextQuestion(out IQuestionModel questionModel))
        {
            LoadQuestion(questionModel);
        }
        else
        {
            LoadResults();
        }
    }
    private void LoadQuestion(IQuestionModel questionModel)
    {
        _quizModel.LoadQuestion(questionModel);
        _quizView.SetQuestionNumberText($"Quiz ({questionModel.Id}/{_quizModel.QuestionList.Count})");
    }

    private void LoadResults()
    {
        _quizView.SetVisibilityResults(true);
        _quizView.SetQuestionNumberText($"Results");
        int correctQuestionCount = _quizModel.GetCorrectQuestionCount();
        int questionCount = _quizModel.GetQuestionCount();
        _quizView.SetCorrectResultText($"{correctQuestionCount}/{questionCount}");
        string fullResultsText = $"You know the theory at {correctQuestionCount} out of {questionCount}" 
            + (correctQuestionCount == questionCount ? "!" :", you should read it again and you will definitely pass this test with the maximum score!");
        _quizView.SetFullResultsText(fullResultsText);
    }

    private void OnModelCurrentQuestionChanged(IQuestionModel questionModel)
    {
        if (_questionPresenter != null)
        {
            _questionPresenter.Dispose();
        }
        _quizView.SetCorrectResultText(questionModel.Id + "/" + _quizModel.QuestionList.Count);
        IQuestionView questionView = _quizView.GetQuestionView();
        IQuestionPresenter questionPresenter = new QuestionPresenter(questionView, questionModel);

        questionPresenter.Initialize();

        _questionPresenter = questionPresenter;
    }
}
