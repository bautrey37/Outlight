using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceBehavior : MonoBehaviour
{
    public bool On;
    public SpriteMask LightMask;
    private SpriteMask instance;

    void Start()
    {
        if (On)
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        if (instance == null)
        {
            instance = Instantiate(LightMask, transform.position, Quaternion.identity, transform);
        }
    }

    public void TurnOff()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
    }
}
