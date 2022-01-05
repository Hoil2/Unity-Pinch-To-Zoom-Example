using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomInOut : MonoBehaviour
{
    Transform cameraTransform;
    float previousDistance = 0f, distance = 0f;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
        if(Input.touchCount == 2) {
            if(Input.GetTouch(0).phase == TouchPhase.Began || 
            Input.GetTouch(1).phase == TouchPhase.Began) {
                previousDistance = Vector2.Distance(Input.GetTouch(0).position, 
                                                    Input.GetTouch(1).position);
                
            }
            distance = Vector2.Distance(Input.GetTouch(0).position, 
                                        Input.GetTouch(1).position);
            Vector3 dir = cameraTransform.localRotation * Vector3.forward;
            // Zoom in
            //if(previousDistance < distance) {
            float speed = (distance - previousDistance) * 0.002f;
            cameraTransform.Translate(dir * speed);
            //}
            // // Zoom out
            // else if(previousDistance > distance) {
            //     cameraTransform.Translate(dir * (distance - previousDistance));
            // }

            previousDistance = distance;
        }
    }
}
