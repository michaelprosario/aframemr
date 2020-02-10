
using AFrameMR.Core.Interfaces;

namespace AFrameMR.Core.Entities
{
    public class Sphere : DocumentElement, ITransform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public string Color { get; set; }
        public float Radius { get; set; }
        public Sphere()
        {
            Position = new Vector3();
            Rotation = new Vector3();
            Color = "";
            Radius = 1;
        }
    }
}
