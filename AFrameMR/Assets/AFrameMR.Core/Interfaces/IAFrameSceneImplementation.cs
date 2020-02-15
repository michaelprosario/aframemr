using AFrameMR.Core.Entities;

namespace AFrameMR.Core.Interfaces
{
    public interface IAFrameSceneImplementation
    {
        void MakeBox(Box box);
        void MakeCylinder(Cylinder cylinder);
        void MakePlane(Plane plane);
        void MakeSphere(Sphere sphere);
    }
}