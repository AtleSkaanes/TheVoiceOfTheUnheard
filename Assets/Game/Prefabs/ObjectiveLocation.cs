using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveLocation : MonoBehaviour
{
    public static ObjectiveLocation Instance { get; private set; }

    [HideInInspector]
    public Vector3 position { get; private set; }

    [SerializeField] private float inBufferSize = 5f;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        Instance.position = transform.position;
    }

    public float Distance(Vector3 otherPosition)
    {
        return Vector3.Distance(position, otherPosition);
    }

    public bool AtLocation(Vector3 other)
    {
        return Distance(other) < inBufferSize;
    }
}
