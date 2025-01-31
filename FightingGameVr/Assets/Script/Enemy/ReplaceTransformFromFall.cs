using UnityEngine;

public class ReplaceTransformFromFall : MonoBehaviour
{
    [SerializeField] private float yMin = -0.5f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
    }
}
