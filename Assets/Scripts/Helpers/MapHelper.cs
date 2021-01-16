using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHelper : MonoBehaviour
{
    public static Vector3 GetMapProjectionForGameObject(GameObject gObject)
    {
        RaycastHit hit;
        Ray ray = new Ray(gObject.transform.position, Vector3.down);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        Debug.LogWarning("GetMapProyectionForGameObject called but coudn't find a proper projection in the map");
        return Vector3.positiveInfinity;
    }
}
