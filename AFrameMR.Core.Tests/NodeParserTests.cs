using System.IO;
using AFrameMR.Core.Services;
using HtmlAgilityPack;
using NUnit.Framework;

namespace AFrameMR.Core.Tests
{
    public class NodeParserTests
    {
        private NodeParser _nodeParser;
        private string _htmlMarkup;
        private HtmlDocument _htmlDocument;
        
        [SetUp]
        public void Setup()
        {
            var path = TestContext.CurrentContext.TestDirectory + "\\TestFiles\\easyScene1.html";
            _htmlMarkup = File.ReadAllText(path);
            _nodeParser = new NodeParser();
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(_htmlMarkup);
        }

        [Test]
        public void NodeParser__ParseBox__PositionShouldBeCorrect()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(-1, box.Position.X);
            Assert.AreEqual(0.5, box.Position.Y);
            Assert.AreEqual(-3, box.Position.Z);            
        }
        
        [Test]
        public void NodeParser__ParseBox__RotationShouldBeCorrect()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(0, box.Rotation.X);
            Assert.AreEqual(45, box.Rotation.Y);
            Assert.AreEqual(0, box.Rotation.Z);            
        }     
        
        [Test]
        public void NodeParser__ParseBox__ColorShouldBeCorrect()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual("#4CC3D9", box.Color);
        }          
        
        [Test]
        public void NodeParser__ParseBox__WidthShouldBeCorrect()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            node.SetAttributeValue("width", "3.14");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(3.14f, box.Width);
        }   
        
        [Test]
        public void NodeParser__ParseBox__HeightShouldBeCorrect()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            node.SetAttributeValue("height", "3.14");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(3.14f, box.Height);
        }          
        
        [Test]
        public void NodeParser__ParseBox__DepthShouldBeCorrect()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            node.SetAttributeValue("depth", "3.14");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(3.14f, box.Depth);
        }
        
        [Test]
        public void NodeParser__ParseBox__DepthShouldHandleJunk()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            node.SetAttributeValue("depth", "junk");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(1f, box.Depth);
        }
        
        [Test]
        public void NodeParser__ParseBox__ShouldHandleErrorIfNumberMissing()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            node.SetAttributeValue("position", "1 2");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(0, box.Position.X);
            Assert.AreEqual(0, box.Position.Y);
            Assert.AreEqual(0, box.Position.Z);            
        }   
        
        [Test]
        public void NodeParser__ParseBox__ShouldHandleErrorIfNumberMissing2()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            node.SetAttributeValue("position", "1");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(0, box.Position.X);
            Assert.AreEqual(0, box.Position.Y);
            Assert.AreEqual(0, box.Position.Z);            
        }        
        
        [Test]
        public void NodeParser__ParseBox__ShouldHandleErrorIfNumberBad()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-box");
            node.SetAttributeValue("position", "1 bad 2");
            
            // act
            var box = _nodeParser.ParseBox(node);

            // assert
            Assert.AreEqual(0, box.Position.X);
            Assert.AreEqual(0, box.Position.Y);
            Assert.AreEqual(0, box.Position.Z);            
        }
    }
}