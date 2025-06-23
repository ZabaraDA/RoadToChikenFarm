using UnityEngine;
using Newtonsoft.Json;


public class Answer
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("answerText")]
    public string Text { get; set; }
    [JsonProperty("isCorrectAnswer")]
    public bool IsCorrect { get; set; }
}
