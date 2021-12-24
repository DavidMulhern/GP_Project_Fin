using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Transform object, will be used to track player with camera 
    [SerializeField] private Transform player;
    // Connected the two by dragging the player object in Unity, into the new player field

    private void Update()
    {
        // using vector3 here because the camera needs to have a z value
        // assinging positions relative to player Transform values
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
