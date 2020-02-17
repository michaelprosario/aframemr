using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using AFrameMR.Core.Entities;
using AFrameMR.Core.Interfaces;
using Siccity.GLTFUtility;
using UnityEngine;
using UnityEngine.Networking;
using Plane = AFrameMR.Core.Entities.Plane;

public class AFrameSceneBehavior : MonoBehaviour, IAFrameSceneBehavior
{
    public void MakeBox(Box box)
    {
        var primitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
        primitive.transform.position = new UnityEngine.Vector3(box.Position.X, box.Position.Y, box.Position.Z);
        primitive.transform.rotation = Quaternion.Euler(box.Rotation.X, box.Rotation.Y, box.Rotation.Z);
    }

    public void MakeCylinder(Cylinder cylinder)
    {
        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        primitive.transform.position = new UnityEngine.Vector3(cylinder.Position.X, cylinder.Position.Y, cylinder.Position.Z);
        primitive.transform.rotation = Quaternion.Euler(cylinder.Rotation.X, cylinder.Rotation.Y, cylinder.Rotation.Z);
        primitive.transform.localScale = new UnityEngine.Vector3(1, cylinder.Height, 1);
    }

    public void MakePlane(Plane plane)
    {
        var primitive = GameObject.CreatePrimitive(PrimitiveType.Plane);
        primitive.transform.position = new UnityEngine.Vector3(plane.Position.X, plane.Position.Y, plane.Position.Z);
    }

    public void MakeSphere(Sphere sphere)
    {
        var primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        primitive.transform.position = new UnityEngine.Vector3(sphere.Position.X, sphere.Position.Y, sphere.Position.Z);
        primitive.transform.rotation = Quaternion.Euler(sphere.Rotation.X, sphere.Rotation.Y, sphere.Rotation.Z);
    }
    
    IEnumerator LoadGLTFFromWeb(GLTFModel model)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(model.Source))
        {
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Guid guid = Guid.NewGuid();
                string fileName = guid.ToString();
                string savePath = string.Format("{0}/{1}.glb", Application.persistentDataPath, fileName);        
                File.WriteAllBytes(savePath, www.downloadHandler.data);
                GameObject newObject = Importer.LoadFromFile(savePath);
                if (newObject != null)
                {
                    newObject.transform.position = new UnityEngine.Vector3(model.Position.X, model.Position.Y, model.Position.Z);
                    newObject.transform.rotation = Quaternion.Euler(model.Rotation.X, model.Rotation.Y, model.Rotation.Z);
                }
                else
                {
                    Debug.Log("Error loading " + model.Source);
                }
            }
        }
    }    

    public void MakeGltfModel(GLTFModel model)
    {
        StartCoroutine(LoadGLTFFromWeb(model));
    }
}
