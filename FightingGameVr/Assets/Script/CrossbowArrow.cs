using UnityEngine;

public class CrossbowArrow : MonoBehaviour
{
    float speed = 15f;

    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
  
        if (collision.transform.GetComponentInParent<IDamageble>() != null)
        {

            collision.transform.GetComponentInParent<IDamageble>().Hit(50);
        }
        if (collision.transform.tag != "Player" && collision.transform.tag != "Crossbow")
        {
            Destroy(gameObject);
        }
    }
}
