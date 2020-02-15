using AFrameMR.Core.Requests;
using AFrameMR.Core.Services;
using NUnit.Framework;
using System.IO;
using System.Linq;
using AFrameMR.Core.Entities;

namespace AFrameMR.Core.Tests
{
    public class SceneParserServiceTests
    {
        private SceneParserService _service;
        private string _htmlMarkup;
        
        [SetUp]
        public void Setup()
        {
            var path = TestContext.CurrentContext.TestDirectory + "\\TestFiles\\easyScene1.html";
            _htmlMarkup = File.ReadAllText(path);
            _service = new SceneParserService();
        }

        [Test]
        public void SceneParser__ParseScene_ReturnFiveElementsInHappyCase()
        {
            // arrange 
            // act 
            var response = _service.ParseScene(new SceneParserRequest()
            {
                HtmlContent = _htmlMarkup
            });

            // assert
            Assert.IsTrue(response.Scene.DocumentElements.Count >= 1, "five elements should be returned");
        }
        
        [Test]
        public void SceneParser__ParseScene_FirstElementShouldBeABox()
        {
            // arrange 
            var response = _service.ParseScene(new SceneParserRequest()
            {
                HtmlContent = _htmlMarkup
            });

            // assert
            Assert.IsTrue(response.Scene.DocumentElements.First().GetType() == typeof(Box));
        }
    }
}