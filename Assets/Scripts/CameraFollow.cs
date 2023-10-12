using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private Camera cam;
    private Vector3 velocity;
    public bool isFollowingCharachter;
    public Vector3 manuelOffset, isFollowingOffset;
    [SerializeField] private float targetSizeisFollowing,targetSize;
    [SerializeField] private float zoomSpeed;


    private void Start()
    {
        target = GameObject.Find("eva").transform;
    }
    private void LateUpdate()
    {
        if (!isFollowingCharachter)
        {
            transform.position = Vector3.SmoothDamp(transform.position, offset, ref velocity, smoothTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSpeed * Time.deltaTime);
            offset = manuelOffset;

        }

        if (isFollowingCharachter)
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, smoothTime);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSizeisFollowing, zoomSpeed * Time.deltaTime);
            offset = isFollowingOffset;
        }
     


        

    }
}
