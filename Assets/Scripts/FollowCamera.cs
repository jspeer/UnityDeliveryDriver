using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [Header("Camera Movement")]
    [SerializeField] GameObject thingToFollow;
    [SerializeField] float cameraZOffset;

    void Awake()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, cameraZOffset);
    }

    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, cameraZOffset);
    }
}
