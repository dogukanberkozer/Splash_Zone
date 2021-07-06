using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCalculator : MonoBehaviour
{
    public static ScreenCalculator instance; // for singleton
    float width, height; // screen variables

    public float Width{ // there is no need sets
        get{
            return width;
        }
    }
    public float Height{
        get{
            return height;
        }
    }

    void Awake() // Awake() is called before Start()
    {
        if(instance == null){ // if instance is null, instance will be this pbject
            instance = this;
        }else if(instance != this){ // if instance is not this object, destroy it
            Destroy(gameObject);
        }

        height = Camera.main.orthographicSize; // orthographicsize is equals to screen height
        width = height * Camera.main.aspect; // width is equals to height * aspect
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
