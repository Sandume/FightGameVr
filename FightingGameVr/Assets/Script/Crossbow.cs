using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Crossbow : MonoBehaviour
{
    public GameObject boltPrefab;
    public Transform muzzlePoint;
    public InputActionReference fireAction; // Bind trigger
    private bool isReloaded = false;
    private bool startTimer = false;
    private float timer = 0;
    private float maxTimer = 0.3f;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject arrow;

    private void Start()
    {
        arrow.SetActive(false);
    }

    private void OnEnable()
    {
        fireAction.action.performed += OnFire;
        fireAction.action.Enable();
    }

    private void OnDisable()
    {
        fireAction.action.performed -= OnFire;
        fireAction.action.Disable();
    }

    private void OnFire(InputAction.CallbackContext ctx)
    {
        if (boltPrefab == null || muzzlePoint == null) return;

        if (isReloaded)
        {
            animator.SetBool("Fire", true);
            animator.SetBool("Reload",false);
            GameObject bolt = Instantiate(boltPrefab, muzzlePoint.position, muzzlePoint.rotation);
            isReloaded = false;
            arrow.SetActive(false);
        }
        else
        {
            animator.SetBool("Fire", false);
            animator.SetBool("Reload", true);
            isReloaded = true;
            startTimer = true;
        }
       
    }

    private void Update()
    {

        if (startTimer)
        {
  
            timer += Time.deltaTime;
            if (timer > maxTimer)
            {
                startTimer = false;
                timer = 0;
                arrow.SetActive(true);
            }
        }
    }
}