
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
            var sceneImplementation = Substitute.For<IAFrameSceneBehavior>();
            var box = new Box();
            _scene.DocumentElements.Add(box);

            var presenter = new AFrameScenePresenter(sceneImplementation);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneImplementation.Received().MakeBox(box);
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleSphereCase()
        {
            // arrange
            var sceneImplementation = Substitute.For<IAFrameSceneBehavior>();
            var sphere = new Sphere();
            _scene.DocumentElements.Add(sphere);

            var presenter = new AFrameScenePresenter(sceneImplementation);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneImplementation.Received().MakeSphere(sphere);
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleCylinderCase()
        {
            // arrange
            var sceneImplementation = Substitute.For<IAFrameSceneBehavior>();
            var gameObject = new Cylinder();
            _scene.DocumentElements.Add(gameObject);

            var presenter = new AFrameScenePresenter(sceneImplementation);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneImplementation.Received().MakeCylinder(gameObject);
        }
        
        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandlePlaneCase()
        {
            // arrange
            var sceneImplementation = Substitute.For<IAFrameSceneBehavior>();
            var gameObject = new Plane();
            _scene.DocumentElements.Add(gameObject);

            var presenter = new AFrameScenePresenter(sceneImplementation);

            // act
            presenter.MakeScene(_scene);

            // assert
            sceneImplementation.Received().MakePlane(gameObject);
        }        
    }
}
