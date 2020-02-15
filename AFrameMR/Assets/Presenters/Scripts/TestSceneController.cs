using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;
using AFrameMR.Core.Requests;
using AFrameMR.Core.Services;
using UnityEngine;

public class TestSceneController : MonoBehaviour, IAFrameScenePresenter
{
    private AFrameSceneImplementation _implementation;
    void Start()
    {
        string filePath = "C:\\dev\\AframeMR\\AFrameMR\\Assets\\TestFiles\\easyScene1.html";
        string htmlContent = System.IO.File.ReadAllText(filePath);
        var request = new SceneParserRequest()
        {
            HtmlContent = htmlContent
        };
        var sceneParserService = new SceneParserService();
        var response = sceneParserService.ParseScene(request);

        _implementation = GetComponent<AFrameSceneImplementation>();
        MakeScene(response.Scene);
    }

    public void MakeScene(AFrameScene scene)
    {
        var presenter = new AFrameMR.Core.Presenters.AFrameScenePresenter(_implementation);
        presenter.MakeScene(scene);
    }
}
