using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fitCameraHeight();
        fitCameraWidth();
    }
    void fitCameraWidth()
    {
        SpriteRenderer sr = (SpriteRenderer)GetComponent("Renderer");
        if (sr == null)
            return;

        // Set filterMode
        sr.sprite.texture.filterMode = FilterMode.Point;

        // Get stuff
        double width = sr.sprite.bounds.size.x;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;
        double worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Resize
        transform.localScale = new Vector2(1, 1) * (float)(worldScreenWidth / width);
    }
    void fitCameraHeight()
    {
        SpriteRenderer sr = (SpriteRenderer)GetComponent("Renderer");
        if (sr == null)
            return;

        // Set filterMode
        sr.sprite.texture.filterMode = FilterMode.Point;

        // Get stuff
        double height = sr.sprite.bounds.size.x;
        double worldScreenHeight = Camera.main.orthographicSize * 2.0;

        // Resize
        transform.localScale = new Vector2(1, 1) * (float)(worldScreenHeight / height);
    }
}
