using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ResourceData res;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Resources"));
            Debug.Log(hit.collider.name);
            
            if (hit.collider.gameObject == gameObject)
            {
                onClick();
            }
        }
    }

    private void onClick()
    {
        Debug.Log("Gathered" + res.Income);
        Destroy(gameObject);
    }
}
