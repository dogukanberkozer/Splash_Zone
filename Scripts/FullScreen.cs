using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // to get reference
        Vector2 tempScale = transform.localScale; // reference of scale value

        float spriteWidth = spriteRenderer.size.x; // length of the sprite on x axis
        float screenHeight = Camera.main.orthographicSize * 2.0f; // height of the screen
        float screenWidth = screenHeight / Screen.height * Screen.width; // width of the screen

        tempScale.x = screenWidth / spriteWidth; // to apply scaling process
        transform.localScale = tempScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
