using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScalingAnimation : MonoBehaviour
{
    public AnimationCurve Curve;
    public float Speed = 0.5f;
    public Vector3 StartScale = Vector3.zero;
    public Vector3 TargetScale = Vector3.one;

    private float timeAggregate;

    public UnityEvent AnimationFinishEvent;

    void OnEnable()
    {
        timeAggregate = 0;
        transform.localScale = StartScale;
    }

    void Update()
    {
        timeAggregate += Time.deltaTime * Speed;
        float value = Curve.Evaluate(timeAggregate);
        transform.localScale = Vector3.LerpUnclamped(StartScale, TargetScale, value);
        if (timeAggregate >= 1)
        {
            transform.localScale = TargetScale;
            enabled = false;
            AnimationFinishEvent.Invoke();
        }
    }
}
