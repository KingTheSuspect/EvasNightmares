using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseFollow : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private float followSpeed = 5.0f;
    [SerializeField] private float maxX = 5.0f;
    [SerializeField] private float maxY = 5.0f;

    private Vector3 targetPosition;

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        float clampedX = Mathf.Clamp(mousePosition.x, -maxX, maxX);
        float clampedY = Mathf.Clamp(mousePosition.y, -maxY, maxY);
        targetPosition = new Vector3(clampedX, clampedY, rawImage.rectTransform.position.z);
        rawImage.rectTransform.position = Vector3.Lerp(rawImage.rectTransform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
