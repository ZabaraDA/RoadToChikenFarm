using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    [JsonProperty("id")]
    public int Id { get; set; }
    [JsonProperty("questionText")]
    public string Text { get; set; }
    [JsonProperty("answers")]
    public List<Answer> Answers { get; set; }
}
