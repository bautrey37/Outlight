using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceBehavior : MonoBehaviour
{
    private bool _On;
    public bool On { get { return _On; } set { Toggle(value); _On = value; } }

    private void Toggle(bool toVal)
    {

    }

}
