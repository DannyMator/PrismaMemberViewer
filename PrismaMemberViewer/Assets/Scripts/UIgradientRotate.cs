using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIgradientRotate : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    void Update()
    {
        transform.Rotate(0,0,rotationSpeed);
    }
}
