
using AFrameMR.Core.Interfaces;

namespace AFrameMR.Core.Entities
{
    public class Cylinder : DocumentElement, ITransform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public float Radius { get; set; }
        public float Height { get; set; }
        public string Color { get; set; }
        public Cylinder()
        {
            Position = new Vector3();
            Rotation = new Vector3();
            Color = "";
            Radius = 1;
            Height = 1;
        }

    }
}
