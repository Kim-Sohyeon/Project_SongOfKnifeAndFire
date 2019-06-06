using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Texture2D map;


    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }
    
    void GenerateMap()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            // The pixel is transparent. Let's ignore it!
            return;
        }

        Debug.Log(pixelColor);
    }
}
