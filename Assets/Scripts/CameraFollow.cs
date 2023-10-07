using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;
    public Camera cam;
    private Vector3 velocity;
    public bool isFollowingCharachter ;
    public Vector3 manuelOffset,isFollowingOffset;
    public float targetSizeisFollowing,targetSize;
    public float zoomSpeed;


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
