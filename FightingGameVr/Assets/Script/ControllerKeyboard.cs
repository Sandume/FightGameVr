using UnityEngine;

public class ControllerKeyboard : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position += transform.forward * speed*Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("attack");
            RaycastHit hit;
            if (Physics.SphereCast(transform.position + transform.up,5f, transform.forward, out hit, 15f))
            {
                if(hit.transform.GetComponentInParent<IDamageble>() != null)
                {
                    hit.transform.GetComponentInParent<IDamageble>().Hit(50);
                }
            }
        }
    }
}
