using UnityEngine;

public class CharacterController3D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 90f;
    public float scaleSpeed = 0.3f;

    public Transform meshGroup; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; 
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(h, 0, v).normalized;

        if (moveDir.magnitude >= 0.1f)
        {
            Vector3 nextPos = rb.position + moveDir * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(nextPos);

            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, 0.2f));
        }
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.X))
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        
        if (Input.GetKey(KeyCode.Y))
            meshGroup.localScale += Vector3.one * scaleSpeed * Time.deltaTime;
    }
}
