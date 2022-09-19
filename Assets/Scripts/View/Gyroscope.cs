using System;
using UnityEngine;

public class Gyroscope : MonoBehaviour
{
    public Vector3 center;
    public Vector3 offset;

    private void OnValidate()
    {
        center = transform.localPosition; 
    }

    private void OnEnable()
    {
        Input.gyro.enabled = true; 
    }

    private void Update()
    {
        var offsetX = Input.gyro.rotationRate.y * Time.deltaTime * offset.x;
        var offsetY = Input.gyro.rotationRate.x * Time.deltaTime * offset.y;

        transform.localPosition += new Vector3(offsetX , offsetY);

        var pos = transform.localPosition;
        var x = Mathf.Clamp(pos.x, center.x - offset.x, center.x + offset.x);
        var y = Mathf.Clamp(pos.y, center.y - offset.y, center.y + offset.y);

        transform.localPosition = new Vector3(x, y); 
    }
    
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}