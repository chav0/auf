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
        var angle = GyroToUnity(Input.gyro.attitude).eulerAngles;
        var offsetX = Input.gyro.rotationRate.y * Time.deltaTime * offset.x;
        var offsetY = Input.gyro.rotationRate.x * Time.deltaTime * offset.y;

        transform.localPosition += new Vector3(offsetX , offsetY) ; 
    }
    
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}