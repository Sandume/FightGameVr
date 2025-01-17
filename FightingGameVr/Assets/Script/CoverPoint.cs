using System.Collections.Generic;
using UnityEngine;

public class CoverPoint : MonoBehaviour
{
    void Start()
    {
        GameManager.CoverPoint coverPoint = new GameManager.CoverPoint();
        coverPoint.position = transform.position;
        coverPoint.isOccupied = false;
        GameManager.Instance.coverPoint.Add(coverPoint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position,0.5f);
    }
}
