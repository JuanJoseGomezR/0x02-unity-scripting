using System;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float coin;
    public Vector3 rotation;
    public float rotateSpeed = 45;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float angle = rotateSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(angle, Vector3.right);
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
