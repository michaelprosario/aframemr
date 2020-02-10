﻿
using AFrameMR.Core.Interfaces;

namespace AFrameMR.Core.Entities
{
    public class Box : DocumentElement, ITransform
    {
        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public float Depth { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public string Color { get; set; }
        public Box()
        {
            Position = new Vector3();
            Rotation = new Vector3();
            Color = "";
            Width = 1;
            Height = 1;
            Depth = 1;
        }

    }
}