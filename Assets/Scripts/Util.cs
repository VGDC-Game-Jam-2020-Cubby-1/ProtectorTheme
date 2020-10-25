using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static Vector2 vector2(this Vector3 vec)
    {
        return new Vector2(vec.x, vec.z);
    }

    public static T[] GetComponentsInDirectChildren<T>(this Component parent) where T : Component
    {
        List<T> tmpList = new List<T>();

        foreach (Transform transform in parent.transform)
        {
            T component;
            if ((component = transform.GetComponent<T>()) != null)
            {
                tmpList.Add(component);
            }
        }

        return tmpList.ToArray();
    }
}
