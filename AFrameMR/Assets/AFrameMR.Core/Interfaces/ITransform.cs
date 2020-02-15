using AFrameMR.Core.Entities;

namespace AFrameMR.Core.Interfaces
{
    public interface ITransform
    {
        Vector3 Position { get; set; }
        Vector3 Rotation { get; set; }
    }
}