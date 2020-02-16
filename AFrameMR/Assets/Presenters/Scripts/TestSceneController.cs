using AFrameMR.Core.Entities;
using AFrameMR.Core.Presenters;
using AFrameMR.Core.Requests;
using AFrameMR.Core.Responses;
using AFrameMR.Core.Services;
using UnityEngine;

public class TestSceneController : MonoBehaviour
{
    private AFrameSceneBehavior _behavior;
    void Start()
    {
        string filePath = "C:\\dev\\AframeMR\\AFrameMR\\Assets\\TestFiles\\easyScene1.html";
        var response = ParseHtmlFile(filePath);
        _behavior = GetComponent<AFrameSceneBehavior>();
        MakeScene(response.Scene);
    }

    private SceneParserResponse ParseHtmlFile(string filePath)
    {
        string htmlContent = System.IO.File.ReadAllText(filePath);
        var request = new SceneParserRequest()
        {
            HtmlContent = htmlContent
        };
        var sceneParserService = new SceneParserService();
        var response = sceneParserService.ParseScene(request);
        return response;
    }

    private void MakeScene(AFrameScene scene)
    {
        var presenter = new AFrameScenePresenter(_behavior);
        presenter.MakeScene(scene);
    }
}
