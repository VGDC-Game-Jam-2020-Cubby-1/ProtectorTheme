using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class PoiManager : MonoBehaviour
{
    private POI[] _POIs;
    private POI[] POIs
    {
        get
        {
            if (_POIs == null)
            {
                _POIs = GetComponentsInChildren<POI>();
            }
            return _POIs;
        }
    }

    public POI[] GenerateRandom(int len)
    {
        IEnumerable<POI> generated = new List<POI>();

        for (int generated_len = 0; generated_len < len; generated_len += len)
        {
            generated = generated.Union(POIs.OrderBy(_ => UnityEngine.Random.value));
        }

        return generated.Take(len).ToArray();
    }
}
