﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class StructureBuilder : MonoBehaviour
{
    public Color AllowColor;
    public Color BlockColor;

    private StructureData currentStructureData;

    private void Awake()
    {
        Events.OnStructureSelected += OnStructureSelected;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Events.OnStructureSelected -= OnStructureSelected;
    }

    private void OnStructureSelected(StructureData obj)
    {
        currentStructureData = obj;
        for (int i = transform.childCount-1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        Structure shadow = Instantiate(obj.StructurePrefab, transform.position, Quaternion.identity, transform);
        foreach (var comp in shadow.GetComponents<Component>())
        {
            if (!(comp is Transform) && !(comp is Renderer))
            {
                Destroy(comp);
            }
            if (comp is Renderer)
            {
                ((Renderer)comp).sortingLayerName = "Darkness";
            }
        }
        gameObject.SetActive(true);
    }

    void Update()
    {
        //Reposition the gameobject to mouse coordinates. 
        //Round the coordinates to make it snap to a grid.

        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos = new Vector3(
            Mathf.Round(mousepos.x - 0.5f) + 0.5f, Mathf.Round(mousepos.y - 0.5f) + 0.5f, 0);

        transform.position = mousepos;

        //Verify that building area is free of other Structures. 
        //By using a static overlap method from Physics2D class we can make this work without collider and a 2d rigidbody.

        if (isFree(transform.position))
        {
            TintSprite(AllowColor);
        } else
        {
            TintSprite(BlockColor);
        }

        //Tint the sprite to green or red accordingly.
        //Call the build method when the player presses left mouse button

        if (Input.GetMouseButtonDown(0))
        {
            Build();
        }
    }

    void TintSprite (Color c)
    {
        foreach (SpriteRenderer spr in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            spr.color = c;
        }

    }

    bool isFree(Vector3 pos)
    {
        Collider2D[] overlaps = Physics2D.OverlapCircleAll(pos, 0.2f);
        bool IsLightNearby = false;
        foreach (Collider2D overlap in overlaps)
        {
            Debug.Log(overlap.gameObject.name);
            if (overlap.gameObject.GetComponentInParent<LightSourceBehavior>() != null || overlap.gameObject.GetComponent<LightSourceBehavior>() != null)
            {
                IsLightNearby = true;
            }
        }
        Debug.Log("Light: " + IsLightNearby);
        return IsLightNearby;
    }

    void Build()
    {
        if (!isFree(transform.position)) return;
        // remove gold

        if (EventSystem.current.IsPointerOverGameObject()) return;

        Structure structure = Instantiate(currentStructureData.StructurePrefab, transform.position, Quaternion.identity, null);
        LightSourceBehavior light = structure.gameObject.GetComponent<LightSourceBehavior>();
        gameObject.SetActive(false);
    }
}
