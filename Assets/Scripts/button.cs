using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class button : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;
    private bool isPressed;
    private Vector3 startPosition;
    private ConfigurableJoint joint;
    public UnityEvent onPressed, onReleased;

    void Start()
    {
        startPosition = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;

        if (math.abs(value) < deadzone)
        {
            value = 0;
        }
        return Mathf.Clamp(value,-1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
    }

    private void Released()
    {
        isPressed = false;
        onReleased.Invoke();

    }
}
