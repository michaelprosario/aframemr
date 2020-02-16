using System.Collections;
using System.Collections.Generic;
using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;
using UnityEngine;
using Plane = AFrameMR.Core.Entities.Plane;

public class AFrameSceneBehavior : MonoBehaviour, IAFrameSceneBehavior
{
    public void MakeBox(Box box)
    {
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        gameObject.transform.position = new UnityEngine.Vector3(box.Position.X, box.Position.Y, box.Position.Z);
        gameObject.transform.rotation = Quaternion.Euler(box.Rotation.X, box.Rotation.Y, box.Rotation.Z);
    }

    public void MakeCylinder(Cylinder cylinder)
    {
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        gameObject.transform.position = new UnityEngine.Vector3(cylinder.Position.X, cylinder.Position.Y, cylinder.Position.Z);
        gameObject.transform.rotation = Quaternion.Euler(cylinder.Rotation.X, cylinder.Rotation.Y, cylinder.Rotation.Z);
        gameObject.transform.localScale = new UnityEngine.Vector3(1, cylinder.Height, 1);
    }

    public void MakePlane(Plane plane)
    {
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Plane);
        gameObject.transform.position = new UnityEngine.Vector3(plane.Position.X, plane.Position.Y, plane.Position.Z);
        //gameObject.transform.rotation = Quaternion.Euler(plane.Rotation.X, plane.Rotation.Y, plane.Rotation.Z);
    }

    public void MakeSphere(Sphere sphere)
    {
        var gameObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        gameObject.transform.position = new UnityEngine.Vector3(sphere.Position.X, sphere.Position.Y, sphere.Position.Z);
        gameObject.transform.rotation = Quaternion.Euler(sphere.Rotation.X, sphere.Rotation.Y, sphere.Rotation.Z);
    }
}
