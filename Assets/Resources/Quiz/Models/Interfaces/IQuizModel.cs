using System;
using System.Collections.Generic;

public interface IQuizModel
{
    event Action<IQuestionModel> OnModelCurrentQuestionChanged;
    event Action<ICollection<IQuestionModel>> OnModelQuestionListChanged;

    IQuestionModel CurrentQuestion { get; set; }

    ICollection<IQuestionModel> QuestionList { get; set; }

    int GetCorrectQuestionCount();
    int GetQuestionCount();
    void LoadQuestion(IQuestionModel questionModel);
    bool TryGetNextQuestion(out IQuestionModel questionModel);
    bool TryGetBackQuestion(out IQuestionModel questionModel);
}
