using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float EdgeSpeed = 10;



    void Start()
    {

    }



    void Update()
    {
        transform.position +=
            new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * MoveSpeed;
        Vector3 mousepos = Input.mousePosition;
        //if (mousepos.x <= 0)
        //{
        //    transform.position += new Vector3(-1, 0) * Time.deltaTime * EdgeSpeed;
        //} else if (mousepos.x >= Screen.width)
        //{
        //    transform.position += new Vector3(1, 0) * Time.deltaTime * EdgeSpeed;
        //}
        //if (mousepos.y <= 0)
        //{
        //    transform.position += new Vector3(0, -1) * Time.deltaTime * EdgeSpeed;
        //}
        //else if (mousepos.y >= Screen.height)
        //{
        //    transform.position += new Vector3(0, 1) * Time.deltaTime * EdgeSpeed;
        //}
    }
}