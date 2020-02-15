using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;

namespace AFrameMR.Core.Presenters
{
    public class AFrameScenePresenter : IAFrameScenePresenter
    {
        private readonly IAFrameSceneImplementation implementation;

        public AFrameScenePresenter(IAFrameSceneImplementation implementation)
        {
            this.implementation = implementation;
        }

        public void MakeScene(AFrameScene scene)
        {
            foreach (var documentElement in scene.DocumentElements)
            {
                switch (documentElement)
                {
                    case Box box:
                        implementation.MakeBox(box);
                        break;
                    case Cylinder element:
                        implementation.MakeCylinder(element);
                        break;
                    case Sphere sphere:
                        implementation.MakeSphere(sphere);
                        break;
                    case Plane plane:
                        implementation.MakePlane(plane);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
