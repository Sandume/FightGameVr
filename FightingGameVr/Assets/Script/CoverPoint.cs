using System.Collections.Generic;
using UnityEngine;

public class CoverPoint : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.coverPoint.Add(transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.5f);
    }
}
