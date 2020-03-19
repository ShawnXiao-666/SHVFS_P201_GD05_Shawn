using System;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 AsVector3(this IntVector2 intVector2)
    {
        return new Vector3(intVector2.x, intVector2.y);
    }

    public static IntVector2 AsIntVector2(this Vector3 vector3)
    {
        return new IntVector2(Convert.ToInt32(vector3.x), Convert.ToInt32(vector3.y));
    }
}


