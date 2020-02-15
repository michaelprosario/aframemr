
using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;
using AFrameMR.Core.Presenters;
using NSubstitute;
using NUnit.Framework;

namespace AFrameMR.Core.Tests
{
    public class AFrameScenePresenterTests
    {
        AFrameScene scene;

        [SetUp]
        public void TestSetup()
        {
            scene = new AFrameScene();
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleBoxCase()
        {
            // arrange
            var sceneImplementation = Substitute.For<IAFrameSceneImplementation>();
            var box = new Box();
            scene.DocumentElements.Add(box);

            var presenter = new AFrameScenePresenter(sceneImplementation);

            // act
            presenter.MakeScene(scene);

            // assert
            sceneImplementation.Received().MakeBox(box);
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleSphereCase()
        {
            // arrange
            var sceneImplementation = Substitute.For<IAFrameSceneImplementation>();
            var sphere = new Sphere();
            scene.DocumentElements.Add(sphere);

            var presenter = new AFrameScenePresenter(sceneImplementation);

            // act
            presenter.MakeScene(scene);

            // assert
            sceneImplementation.Received().MakeSphere(sphere);
        }

        [Test]
        public void AFrameScenePresenter__MakeScene__ShouldHandleCylinderCase()
        {
            // arrange
            var sceneImplementation = Substitute.For<IAFrameSceneImplementation>();
            var gameObject = new Cylinder();
            scene.DocumentElements.Add(gameObject);

            var presenter = new AFrameScenePresenter(sceneImplementation);

            // act
            presenter.MakeScene(scene);

            // assert
            sceneImplementation.Received().MakeCylinder(gameObject);
        }
    }
}
