using System.Runtime.CompilerServices;
using UnityEngine;

public class Sword : MonoBehaviour
{
    Vector3 lastFramePosition = Vector3.zero;
    Vector3 distanceBeetwenFrame = Vector3.zero;
    Vector3 velocity = Vector3.zero;
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
       velocity = (transform.position - lastFramePosition) / Time.deltaTime;
       lastFramePosition = transform.position;
    }
    private void OnCollisionStay(Collision collision)
    {
        //if(collision.transform.GetComponent<IDamageble>() != null)
        //{
        Debug.Log(collision.gameObject);
        //    collision.transform.GetComponent<IDamageble>().Hit(50000);
        //}

    }
}
