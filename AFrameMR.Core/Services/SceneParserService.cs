
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
                        response.DocumentElements.Add(nodeParser.ParseBox(node));
                        break;
                    case "a-sphere":
                        response.DocumentElements.Add(nodeParser.ParseSphere(node));
                        break;
                    case "a-plane":
                        response.DocumentElements.Add(nodeParser.ParsePlane(node));
                        break;
                    case "a-cylinder":
                        response.DocumentElements.Add(nodeParser.ParseCylinder(node));
                        break;
                    case "a-sky":
                        //var box2 = new Box();
                        //response.DocumentElements.Add(box2);
                        break;
                }
            }

            return response;
        }
    }
}
