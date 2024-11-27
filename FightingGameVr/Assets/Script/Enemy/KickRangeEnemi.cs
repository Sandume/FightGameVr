using UnityEngine;

public class KickRangeEnemi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("OutchKick");
        }
    }
}
