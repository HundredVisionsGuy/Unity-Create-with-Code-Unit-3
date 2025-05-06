using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool canJump = true;
    int numJumps = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    } 

    // Update is called once per frame
    void Update()
    {
        canJump = numJumps < 2;
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            numJumps++;
        }
    }

    // Once we land, we can jump
    private void OnCollisionEnter(Collision collision)
    {
        numJumps = 0;
    }
}
