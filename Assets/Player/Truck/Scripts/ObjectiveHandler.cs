using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float dist = ObjectiveLocation.Instance.Distance(transform.position);
        Debug.Log($"dist: {dist}");
    }
}
