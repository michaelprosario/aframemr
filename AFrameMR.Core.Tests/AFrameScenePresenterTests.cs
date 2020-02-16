
using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;
using AFrameMR.Core.Presenters;
using NSubstitute;
using NUnit.Framework;

namespace AFrameMR.Core.Tests
{
    public class AFrameScenePresenterTests
    {
        AFrameScene _scene;

        [SetUp]
        public void TestSetup()
        {
            _scene = new AFrameScene();
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleBoxCase()
        {
            // arrange
            var sceneBehavior = Substitute.For<IAFrameSceneBehavior>();
            var box = new Box();
            _scene.DocumentElements.Add(box);

            var presenter = new AFrameScenePresenter(sceneBehavior);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneBehavior.Received().MakeBox(box);
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleSphereCase()
        {
            // arrange
            var sceneBehavior = Substitute.For<IAFrameSceneBehavior>();
            var sphere = new Sphere();
            _scene.DocumentElements.Add(sphere);

            var presenter = new AFrameScenePresenter(sceneBehavior);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneBehavior.Received().MakeSphere(sphere);
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleCylinderCase()
        {
            // arrange
            var sceneBehavior = Substitute.For<IAFrameSceneBehavior>();
            var gameObject = new Cylinder();
            _scene.DocumentElements.Add(gameObject);

            var presenter = new AFrameScenePresenter(sceneBehavior);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneBehavior.Received().MakeCylinder(gameObject);
        }
        
        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandlePlaneCase()
        {
            // arrange
            var sceneBehavior = Substitute.For<IAFrameSceneBehavior>();
            var gameObject = new Plane();
            _scene.DocumentElements.Add(gameObject);

            var presenter = new AFrameScenePresenter(sceneBehavior);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneBehavior.Received().MakePlane(gameObject);
        }     
        
        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleGltfModel()
        {
            // arrange
            var aFrameSceneBehavior = Substitute.For<IAFrameSceneBehavior>();
            var gameObject = new GLTFModel();
            _scene.DocumentElements.Add(gameObject);

            var presenter = new AFrameScenePresenter(aFrameSceneBehavior);

            // act
            presenter.MakeScene(_scene);

            // assert
            aFrameSceneBehavior.Received().MakeGltfModel(gameObject);
        }          
    }
}
