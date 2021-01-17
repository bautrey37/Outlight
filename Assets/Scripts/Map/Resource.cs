using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ResourceData res;
    public AudioClipGroup CoinDropAudio;

    private void Update()
    {
        if (GetComponent<SpriteRenderer>().isVisible && Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
            foreach(RaycastHit2D hit in hits)
            {
                // This is spamming the console
                Debug.Log(hit.collider.name);
            }

            if (hits.Any((RaycastHit2D hit) => (hit.collider.gameObject == gameObject)) &&
                hits.Any((RaycastHit2D hit) => (hit.collider.gameObject.GetComponent<LightSourceBehavior>() != null)))
            {
                onClick();
            }
        }
    }

    private void onClick()
    {
        //Debug.Log("Gathered" + res.Income);
        CoinDropAudio.Play();
        Events.AddMoney(res.Income);
        Destroy(gameObject);
    }
}
