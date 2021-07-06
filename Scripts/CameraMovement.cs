using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed, speedup, maxSpeed; // essential variables
    bool isMove; // camera isnt moving as default

    // Start is called before the first frame update
    void Start()
    {
        isMove = true;
        speed = 0.7f; // beginning speed of the camera
        speedup = 0.05f; // acceleration per time unit
        maxSpeed = 2.1f; // top speed of the camera
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove) // check the camera state
        {
            moveCamera(); // if camera is moving, go to moving method
        }
    }

    void moveCamera()
    {
        // update position of the camera
        transform.position += transform.up * speed * Time.deltaTime;
        speed += speedup * Time.deltaTime; // calculate acceleration

        if (speed > maxSpeed) // camera speed cant surpass max speed
        {
            speed = maxSpeed;
        }
    }

    public void finishGame()
    {
        isMove = false;
    }
}
