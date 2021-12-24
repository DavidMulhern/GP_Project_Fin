using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // saw speed, [SerializeField] - edit in unity editor if you wish
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        // Only rotating on the Z axis. Time.deltaTime - consideration to frame rates on different devices
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
