using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;

namespace AFrameMR.Core.Presenters
{
    public class AFrameScenePresenter
    {
        private readonly IAFrameSceneBehavior _sceneBehavior;

        public AFrameScenePresenter(IAFrameSceneBehavior sceneBehavior)
        {
            this._sceneBehavior = sceneBehavior;
        }

        public void MakeScene(AFrameScene scene)
        {
            foreach (var documentElement in scene.DocumentElements)
            {
                switch (documentElement)
                {
                    case Box box:
                        _sceneBehavior.MakeBox(box);
                        break;
                    case Cylinder element:
                        _sceneBehavior.MakeCylinder(element);
                        break;
                    case Sphere sphere:
                        _sceneBehavior.MakeSphere(sphere);
                        break;
                    case Plane plane:
                        _sceneBehavior.MakePlane(plane);
                        break;
                    case GLTFModel model:
                        _sceneBehavior.MakeGltfModel(model);                        
                        break;
                }
            }
        }
    }
}
