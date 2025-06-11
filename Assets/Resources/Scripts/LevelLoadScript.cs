using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LevelLoadScript : MonoBehaviour
{
    [SerializeField]
    private int _currentPageId;
    [SerializeField]
    private TMP_Text _pageText;
    [SerializeField]
    private TMP_Text _pageHeader;
    [SerializeField]
    private Image _pageImage;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private Button _toStartButton;
    private int _minPageId;
    private int _maxPageId;
    [SerializeField]
    private GameObject _contentContainer;
    private Vector3 _contentContainerDefaultPosition;

    void Start()
    {
        _contentContainerDefaultPosition = _contentContainer.transform.localPosition;
        FillPageContextById(_currentPageId);
    }

    public void LoadNextPageForScene()
    {
        _currentPageId++;
        FillPageContextById(_currentPageId);
    }
    public void LoadBackPageForScene()
    {
        _currentPageId--;
        FillPageContextById(_currentPageId);
    }

    private void FillPageContextById(int pageId)
    {

        PageContext pageContext = GetPageContextFromJsonById(pageId);

        _contentContainer.transform.localPosition = _contentContainerDefaultPosition;
        _backButton.gameObject.SetActive(pageId > _minPageId);
        _nextButton.gameObject.SetActive(pageId < _maxPageId);
        _toStartButton.gameObject.SetActive(pageId == _maxPageId);

        _pageText.text = pageContext.Text;
        _pageHeader.text = pageContext.Header;

        Texture2D loadedTexture = Resources.Load<Texture2D>("Page Image/" + pageContext.ImageName);
        _pageImage.sprite = Sprite.Create(loadedTexture, new Rect(0, 0, loadedTexture.width, loadedTexture.height), Vector2.one * 0.5f);
    }

    private PageContext GetPageContextFromJsonById(int sceneId)
    {
        //Application.dataPath
        TextAsset text = Resources.Load<TextAsset>("Json/SceneInfoJson");
        Debug.Log("Json text" + text);
        //var pageContextList = JsonUtility.FromJson<JsonContainer<List<PageContext>>>(text.text);
        var pageContextContainer = JsonConvert.DeserializeObject<JsonContainer<List<PageContext>>>(text.text);
        
        _minPageId = pageContextContainer.Value.Min(x => x.Id);
        _maxPageId = pageContextContainer.Value.Max(x => x.Id);
        Debug.Log("Min Scene Id: " + _minPageId);
        Debug.Log("Max Scene Id: " + _maxPageId);
        return pageContextContainer.Value.FirstOrDefault(x => x.Id == sceneId);
    }
}
