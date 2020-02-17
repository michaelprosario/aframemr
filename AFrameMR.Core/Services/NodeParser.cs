
using System;
using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;
using HtmlAgilityPack;

namespace AFrameMR.Core.Services
{
    public class NodeParser
    {
        public Box ParseBox(HtmlNode htmlNode)
        {
            checkForNullHtmlNode(htmlNode);
            var box = new Box();
            ProcessPosition(htmlNode, box);
            ProcessRotation(htmlNode, box);
            box.Color = GetStringAttribute(htmlNode, "color");
            box.Width = GetFloatFromAttribute(htmlNode, "width", 1);
            box.Height = GetFloatFromAttribute(htmlNode, "height", 1);
            box.Depth = GetFloatFromAttribute(htmlNode, "depth", 1);
            
            return box;
        }
        
        public GLTFModel ParseGltfModel(HtmlNode htmlNode)
        {
            checkForNullHtmlNode(htmlNode);
            var gltfModel = new GLTFModel();
            ProcessPosition(htmlNode, gltfModel);
            ProcessRotation(htmlNode, gltfModel);
            gltfModel.Source= GetStringAttribute(htmlNode, "src");
            
            return gltfModel;
        }        
        
        public Plane ParsePlane(HtmlNode htmlNode)
        {
            checkForNullHtmlNode(htmlNode);
            var plane = new Plane();
            ProcessPosition(htmlNode, plane);
            ProcessRotation(htmlNode, plane);
            plane.Color = GetStringAttribute(htmlNode, "color");
            plane.Width = GetFloatFromAttribute(htmlNode, "width", 1);
            plane.Height = GetFloatFromAttribute(htmlNode, "height", 1);

            return plane;
        }      
        
        public DocumentElement ParseSphere(HtmlNode htmlNode)
        {
            checkForNullHtmlNode(htmlNode);
            var sphere = new Sphere();
            ProcessPosition(htmlNode, sphere);
            ProcessRotation(htmlNode, sphere);
            sphere.Color = GetStringAttribute(htmlNode, "color");
            sphere.Radius = GetFloatFromAttribute(htmlNode, "radius", 1);
            return sphere;
        }        
        
        public DocumentElement ParseCylinder(HtmlNode htmlNode)
        {
            checkForNullHtmlNode(htmlNode);
            var cylinder = new Cylinder();
            ProcessPosition(htmlNode, cylinder);
            ProcessRotation(htmlNode, cylinder);
            cylinder.Color = GetStringAttribute(htmlNode, "color");
            cylinder.Radius = GetFloatFromAttribute(htmlNode, "width", 1);
            cylinder.Height = GetFloatFromAttribute(htmlNode, "height", 1);
            return cylinder;
        }        

        private string GetStringAttribute(HtmlNode htmlNode, string attributeName)
        {
            checkForNullHtmlNode(htmlNode);
            
            var result = "";

            if (!htmlNode.Attributes.Contains(attributeName))
            {
                return result;
            }
            
            var attributeString = htmlNode.Attributes[attributeName].Value;
            if (!string.IsNullOrEmpty(attributeString))
            {
                result = attributeString;
            }

            return result;
        }

        private static float GetFloatFromAttribute(HtmlNode htmlNode, string attributeName, float defaultValue)
        {
            float returnValue = defaultValue;

            if (!htmlNode.Attributes.Contains(attributeName))
            {
                return returnValue;
            }
            
            var attributeString = htmlNode.Attributes[attributeName].Value;
            if (!string.IsNullOrEmpty(attributeString))
            {
                var numberParsed = float.TryParse(attributeString, out var parsedNumber);
                if (numberParsed)
                {
                    returnValue = parsedNumber;
                }
            }

            return returnValue;
        }
        
        private void ProcessRotation(HtmlNode htmlNode, ITransform sceneObject)
        {
            sceneObject.Rotation = getVector3FromString(htmlNode, "rotation");
        }
        
        private void ProcessPosition(HtmlNode htmlNode, ITransform sceneObject)
        {
            sceneObject.Position = getVector3FromString(htmlNode,"position");
        }

        private Vector3 getVector3FromString(HtmlNode htmlNode, string attributeName)
        {
            checkForNullHtmlNode(htmlNode);
            
            var result = new Vector3();
            if (!htmlNode.Attributes.Contains(attributeName))
                return result;
            
            var attributeString = htmlNode.Attributes[attributeName].Value;
            if (!string.IsNullOrEmpty(attributeString))
            {
                var parts = attributeString.Split(' ');
                if (parts.Length == 3)
                {
                    var num1Parsed = float.TryParse(parts[0], out var x);
                    var num2Parsed = float.TryParse(parts[1], out var y);
                    var num3Parsed = float.TryParse(parts[2], out var z);

                    if (num1Parsed && num2Parsed && num3Parsed)
                    {
                        result = new Vector3()
                        {
                            X = x, Y = y, Z = z
                        };
                    }
                }
            }

            return result;
        }

        private static void checkForNullHtmlNode(HtmlNode htmlNode)
        {
            if (htmlNode == null)
            {
                throw new ArgumentNullException("html node not defined");
            }
        }
    }
}
