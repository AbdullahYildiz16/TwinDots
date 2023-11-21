
using UnityEngine;
using UnityEngine.UI;

public class BackgroundCode : MonoBehaviour
{
    public RawImage img;
 
    private Texture2D backgroundTexture;
    int number;
    Color currentColor1, currentColor2, currentColor3, currentColor4;

    private void Awake()
    {
        number = Random.Range(0,5);
        if (number == 0)
        {
            currentColor1 = Color.green;
            currentColor2 = Color.white;
            currentColor3 = Color.green;
            currentColor4 = Color.blue;
        }
        else if (number == 1)
        {
            currentColor1 = Color.blue;
            currentColor2 = Color.cyan;
            currentColor3 = Color.blue;
            currentColor4 = Color.black;
        }
        else if (number == 2)
        {
            currentColor1 = Color.red;
            currentColor2 = Color.white;
            currentColor3 = Color.red;
            currentColor4 = Color.blue;
        }
        else if (number == 3)
        {
            currentColor1 = Color.yellow;
            currentColor2 = Color.white;
            currentColor3 = Color.yellow;
            currentColor4 = Color.red;
        }
        else if (number == 4)
        {
            currentColor1 = Color.magenta;
            currentColor2 = Color.white;
            currentColor3 = Color.magenta;
            currentColor4 = Color.blue;
        }
        backgroundTexture = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
        
        SetColor(Color.Lerp(currentColor1, currentColor2, 0.6f), Color.Lerp(currentColor3, currentColor4, 0.4f));
    }
    public void SetColor(Color color1, Color color2)
    {
        backgroundTexture.SetPixels(new Color[] { color1, color2, });
        backgroundTexture.Apply();
        img.texture = backgroundTexture;
    }
    
}
