using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour
{
    [SerializeField] private GameObject smokePrefab;
    public void _smokeDisactivate()
    {
        smokePrefab.SetActive(false);
    }
}
