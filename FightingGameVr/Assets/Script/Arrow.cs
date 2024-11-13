using UnityEngine;

public class Arrow : MonoBehaviour
{
    float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,5f);
    }

    // Update is called once per frame
    void Update()
    {
        //up vector because the transform of the fbx is fuck up
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Outch");
        }
        Destroy(gameObject);
    }
}
