using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingObject : MonoBehaviour
{
    public enum Scales
    {
        SMALL = 0,
        MIDDLE = 1,
        BIG = 2,
        LARGE = 3
    }

    public Scales scale = Scales.SMALL;
}
