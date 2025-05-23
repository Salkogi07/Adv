using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    public float moveInputX;
    public float moveInputY;

    bool isFacingRightX;
    bool isFacingRightY;

    public Transform attackPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInputX = 0f;
        moveInputY = 0f;
        //MoveInput();
        // W, S 키로 이동 처리
        if (Input.GetKey(KeyCode.W))
        {
            moveInputY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveInputY = -1f;
        }

        // A, D 키로 이동 처리
        if (Input.GetKey(KeyCode.A))
        {
            moveInputX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveInputX = 1f;
        }
        Flip();

        Vector3 movement = new Vector3(moveInputX, moveInputY, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void Flip()
    {
        if (isFacingRightX && moveInputX < 0f || !isFacingRightX && moveInputX > 0f)
        {
            isFacingRightX = !isFacingRightX;
            attackPos.localPosition = new Vector3(isFacingRightX ? 1f : -1f, 0f, 0f);
        }
        if ((isFacingRightY && moveInputY < 0f) || (!isFacingRightY && moveInputY > 0f))
        {
            isFacingRightY = !isFacingRightY;
            attackPos.localPosition = new Vector3(0f, isFacingRightY ? 1f : -1f, 0f);
        }
    }

}