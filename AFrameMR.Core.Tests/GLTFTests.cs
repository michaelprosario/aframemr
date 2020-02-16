using System.IO;
using AFrameMR.Core.Services;
using HtmlAgilityPack;
using NUnit.Framework;

namespace AFrameMR.Core.Tests
{
    [TestFixture]
    public class GltfTests
    {
        private NodeParser _nodeParser;
        private string _htmlMarkup;
        private HtmlDocument _htmlDocument;
        
        [SetUp]
        public void SetupTests()
        {
            var path = TestContext.CurrentContext.TestDirectory + "\\TestFiles\\lantern\\viewer.html";
            _htmlMarkup = File.ReadAllText(path);
            _nodeParser = new NodeParser();
            _htmlDocument = new HtmlDocument();
            _htmlDocument.LoadHtml(_htmlMarkup);           
        }
        
        [Test]
        public void NodeParser__ParseGLTF__ShouldHandleLanternCase()
        {
            // arrange
            var node = _htmlDocument.DocumentNode.SelectSingleNode("//a-gltf-model");

            // act
            var model = _nodeParser.ParseGltfModel(node);

            // assert
            Assert.AreEqual(0, model.Position.X);
            Assert.AreEqual(0, model.Position.Y);
            Assert.AreEqual(0, model.Position.Z);      
            Assert.AreEqual("Lantern.gltf", model.Source);     
        }          
    }
}