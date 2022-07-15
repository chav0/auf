using System;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public Background[] backgrounds; 
    
    private void Update()
    {
        var angle = Input.gyro.attitude.eulerAngles.x;
        var ratio = Mathf.Clamp(angle / 180, -1, 1); 
        foreach (var t in backgrounds)
        {
            Modify(t, ratio);
        }
    }

    private void Modify(Background background, float ratio)
    {
        background.transform.position = background.center + background.offset * ratio; 
    }
}

[Serializable]
public class Background
{
    public Transform transform;
    public Vector3 center;
    public Vector3 offset; 
}