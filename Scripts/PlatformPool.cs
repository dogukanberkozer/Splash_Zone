using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] // to control platforms from Unity interface
    GameObject platformPrefab = default;
    [SerializeField] // to control small platforms from Unity interface
    GameObject platform2Prefab = default;
    [SerializeField] // to control platforms from Unity interface
    GameObject spikePrefab = default;
    [SerializeField] // to control distance between platforms from Unity
    float platformDistance = default; // distance between platforms

    List<GameObject> platforms = new List<GameObject>(); // platform list for reusing
    Vector2 platformPosition; // to keep position of the platform

    void Start()
    {
        CreatePlatform();
    }

    void Update()
    {   // if top point of the camera is higher than the last platform in the list
        if(Camera.main.transform.position.y + ScreenCalculator.instance.Height > 
        platforms[platforms.Count - 1].transform.position.y)
        {
            TransportPlatform();
        }
    }

    void CreatePlatform()
    {
        platformPosition = new Vector2(1.56f,0); // middle point of the screen

        for(int i = 0; i < 7; i++)
        {
            GameObject platform;
            if(i == 2 || i == 5){
                platform = Instantiate(platform2Prefab, platformPosition, Quaternion.identity); // creating the small platform
            }else{
                platform = Instantiate(platformPrefab, platformPosition, Quaternion.identity); // creating the platform
            }

            platforms.Add(platform);
            if(i == 0)
            {
                platform.GetComponent<Platform>().isMove = false; // 1st platform doesnt start movement 
            }else
            {
                platform.GetComponent<Platform>().isMove = true; // platform starts movement 
            }    
            platformPosition.y += platformDistance;
        }

        GameObject spikePlatform = Instantiate(spikePrefab, platformPosition, Quaternion.identity);
        platforms.Add(spikePlatform);
        spikePlatform.GetComponent<Spike>().isMove = true;
        platformPosition.y += platformDistance;
    }

    void TransportPlatform(){
        for(int i = 0; i < 4; i++)
        {
            GameObject temp;
            temp = platforms[i + 4];
            platforms[i + 4] = platforms[i];
            platforms[i] = temp;
            platforms[i + 4].transform.position = platformPosition;
            platformPosition.y += platformDistance;
        }
    }
}
