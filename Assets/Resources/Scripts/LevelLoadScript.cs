using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

public class LevelLoadScript : MonoBehaviour
{
    void Start()
    {
        //Application.dataPath
        TextAsset text = Resources.Load<TextAsset>("Json/SceneInfoJson");
        Debug.Log(text);
        //var pageContextList = JsonUtility.FromJson<JsonContainer<List<PageContext>>>(text.text);
        var pageContextList = JsonConvert.DeserializeObject<JsonContainer<List<PageContext>>>(text.text);
        Debug.Log(pageContextList);
        Debug.Log(pageContextList.Value != null);
        Debug.Log(pageContextList.Value.FirstOrDefault().Text);
    }
}
