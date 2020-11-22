using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera Cam;
    public float CamSize;
    public float zoomDelta;
    float minZoom = 2f;
    float maxZoom = 10f;
    void Start()
    {
        
    }
    void Awake()
    {
        // find camera and starting size
        Cam = Camera.main;
        CamSize = Cam.orthographicSize;
    }
    // Update is called once per frame
    void Update()
    {
        // get the current size + the scrollwheel change
        zoomDelta = CamSize + Input.mouseScrollDelta.y;
        // constrain zoom
        CamSize = Mathf.Clamp(zoomDelta, minZoom, maxZoom);
        // apply zoom to field of view
        Cam.orthographicSize = CamSize;
    }
}
