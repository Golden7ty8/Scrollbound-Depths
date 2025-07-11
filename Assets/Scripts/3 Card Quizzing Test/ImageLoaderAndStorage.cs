using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageLoaderAndStorage : MonoBehaviour
{

    Dictionary<string, Texture2D> loadedImages = new Dictionary<string, Texture2D>();

    void Awake()
    {
        //string imageFolderPath = Application.streamingAssetsPath;CONTINUE FROM HERE
        Debug.LogError("CONTINUE FROM HERE");
    }

    void LoadImageIntoDictionary(string filePath)
    {
        if(File.Exists(filePath))
        {
            byte[] imageAsbytes = File.ReadAllBytes(filePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageAsbytes);
            loadedImages.Add(filePath, texture);
        }
    }

    /// <summary>
    /// imageFileName includes extention.
    /// </summary>
    /// <param name="imageFileName"></param>
    /// <returns></returns>
    //public Texture2D GetTexture(string imageFileName)
    //{

    //}
}
