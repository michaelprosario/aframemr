
using AFrameMR.Core.Entities;
using AFrameMR.Core.Requests;
using AFrameMR.Core.Responses;
using HtmlAgilityPack;
using System;

namespace AFrameMR.Core.Services
{
    public class SceneParserService
    {
        public SceneParserResponse ParseScene(SceneParserRequest request)
        {
            var nodeParser = new NodeParser();
            var response = new SceneParserResponse();

            var doc = new HtmlDocument();
            doc.LoadHtml(request.HtmlContent);

            foreach( var node in doc.DocumentNode.SelectSingleNode("//a-scene").ChildNodes) {
                switch (node.Name)
                {
                    case "a-box":
                        response.Scene.DocumentElements.Add(nodeParser.ParseBox(node));
                        break;
                    case "a-sphere":
                        response.Scene.DocumentElements.Add(nodeParser.ParseSphere(node));
                        break;
                    case "a-plane":
                        response.Scene.DocumentElements.Add(nodeParser.ParsePlane(node));
                        break;
                    case "a-cylinder":
                        response.Scene.DocumentElements.Add(nodeParser.ParseCylinder(node));
                        break;
                }
            }

            return response;
        }
    }
}
