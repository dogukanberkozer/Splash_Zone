using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovementControl : MonoBehaviour
{
    float backgroundLocation, backgroundHeight = 10.00321f;

    // Start is called before the first frame update
    void Start()
    {
        backgroundLocation = transform.position.y; // to keep background position
    }

    // Update is called once per frame
    void Update()
    {
        if(backgroundLocation + backgroundHeight < Camera.main.transform.position.y)
        {
            moveBackground(); // if lower background isnt seen in camera
        }
    }

    void moveBackground() // make upper background to create infinite map
    {
        backgroundLocation += (backgroundHeight * 2); // transport to upper (x2 height)
        Vector2 newLocation = new Vector2(1.56f, backgroundLocation); // vector force to carry
        transform.position = newLocation; // set new location
    }
}
