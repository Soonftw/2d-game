using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;
    private float xShift = 0f;
    private float yShift = 0f;


    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x+xShift, playerTransform.position.y+yShift, transform.position.z);
    }
}
