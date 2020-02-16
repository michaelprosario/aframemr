
using AFrameMR.Core.Interfaces;

namespace AFrameMR.Core.Entities
{
    public class GLTFModel : DocumentElement, ITransform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public string Source { get; set; }
        public GLTFModel()
        {
            Position = new Vector3();
            Rotation = new Vector3();
            Source = "";
        }
    }
}
