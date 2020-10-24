using UnityEngine;

public static class Util
{
    public static Vector2 vector2(this Vector3 vec)
    {
        return new Vector2(vec.x, vec.z);
    }
}
