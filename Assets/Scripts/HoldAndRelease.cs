using UnityEngine;
using UnityEngine.UI;

public class HoldAndRelease : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float maxJumpForce = 20.0f;
    [SerializeField] private float jumpTime = 1.0f; //Time to reach max jump force
    [SerializeField] private Slider powerBar;

    private float currentJumpForce = 0.0f;
    [HideInInspector]
    public bool isJumping = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        powerBar.maxValue = maxJumpForce;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentJumpForce = 0;
            isJumping = true;
        }

        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            currentJumpForce += maxJumpForce * Time.deltaTime / jumpForce;
            currentJumpForce = Mathf.Min(currentJumpForce, maxJumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f,0f); // Reset vertical velocity
            rb.AddForce(Vector2.up * currentJumpForce, ForceMode.Impulse);
            isJumping = false;
        }
        powerBar.value = currentJumpForce;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("platform"))
        {
            transform.parent = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("platform"))
        {
            transform.parent = null;
        }
    }
}
