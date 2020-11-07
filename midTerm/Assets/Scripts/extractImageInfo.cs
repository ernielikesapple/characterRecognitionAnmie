using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extractImageInfo : MonoBehaviour
{
    public Texture2D CSImage;

    private void Awake()
    {
        GetRednBlueCoordinates();
    }

    public Dictionary<string, List<Vector3>> GetRednBlueCoordinates()
    {
        Dictionary<string, List<Vector3>> coordinatesDic = new Dictionary<string, List<Vector3>>();
        List<Vector3> blueDots = new List<Vector3>();
        List<Vector3> redDots = new List<Vector3>();

        for (int i = 0; i < CSImage.width; i++) 
        {
            for (int j = 0; j < CSImage.height; j++)
            {
                Color pixel = CSImage.GetPixel(i, j);

                if ((pixel.b) * 255f > 10 && (pixel.b) * 255f < 27) // blue dots feature
                {
                    blueDots.Add(new Vector3((float)i, 0.5f, (float)j));
                }
                else if (((pixel.r) * 255f > 20 && (pixel.r) * 255f < 50)) // red dots feature
                {
                    redDots.Add(new Vector3((float)i, 0.5f, (float)j));
                }
            }
        }
        coordinatesDic.Add("blue", blueDots);
        coordinatesDic.Add("red", redDots);

        return coordinatesDic;
    }





}