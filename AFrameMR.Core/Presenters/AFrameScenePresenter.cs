using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;

namespace AFrameMR.Core.Presenters
{
    public class AFrameScenePresenter
    {
        private readonly IAFrameSceneBehavior _implementation;

        public AFrameScenePresenter(IAFrameSceneBehavior implementation)
        {
            this._implementation = implementation;
        }

        public void MakeScene(AFrameScene scene)
        {
            foreach (var documentElement in scene.DocumentElements)
            {
                switch (documentElement)
                {
                    case Box box:
                        _implementation.MakeBox(box);
                        break;
                    case Cylinder element:
                        _implementation.MakeCylinder(element);
                        break;
                    case Sphere sphere:
                        _implementation.MakeSphere(sphere);
                        break;
                    case Plane plane:
                        _implementation.MakePlane(plane);
                        break;
                }
            }
        }
    }
}
