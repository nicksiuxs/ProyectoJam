using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public float speedPlatform = 2f;
    public Transform pointA;
    public Transform pointB;
    public Transform platform;
    public bool statePlatform = false;

    // Start is called before the first frame update
    void Start()
    {
        platform.localPosition = pointA.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        movePlatforms();
    }

    void movePlatforms()
    {
        if(statePlatform)
        {
            platform.localPosition = Vector2.MoveTowards(platform.localPosition, pointB.localPosition, speedPlatform * Time.deltaTime);
        }
        else
        {
            platform.localPosition = Vector2.MoveTowards(platform.localPosition, pointA.localPosition, speedPlatform * Time.deltaTime);
        }
        
    }
}
