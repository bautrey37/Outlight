using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ResourceData res;
    public bool Clickable = false;

    private void Update()
    {
        if (GetComponent<SpriteRenderer>().isVisible && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log(hit.collider.name);
            
            if (hit.collider.gameObject == gameObject && Clickable)
            {
                onClick();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<LightSourceBehavior>() != null)
        {
            Clickable = true;
        }
    }

    private void onClick()
    {
        Debug.Log("Gathered" + res.Income);
        Destroy(gameObject);
    }
}
