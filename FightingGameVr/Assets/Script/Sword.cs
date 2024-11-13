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
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject);
    //    if (collision.transform.GetComponent<IDamageble>() != null)
    //    {

    //        collision.transform.GetComponent<IDamageble>().Hit(50000);
    //    }

    //}
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.transform.GetComponent<IDamageble>() != null)
        {

            other.transform.GetComponent<IDamageble>().Hit(50000);
        }
    }
}
