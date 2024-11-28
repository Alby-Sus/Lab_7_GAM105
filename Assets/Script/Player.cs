using UnityEngine;
using UnityEngine.UI;

public class PlayerBasket : MonoBehaviour
{
    [Header("Điểm số")]
    public Text scoreText; // Text UI để hiển thị điểm
    private int score = 0;

    [Header("Di chuyển nhân vật")]
    public float moveSpeed = 5f;
    private float moveInput;

    private Rigidbody2D rb;

    [Header("Xoay nhân vật")]
    public float flipSpeed = 10f;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreUI(); 
    }

    void Update()
    {
        // Di chuyển nhân vật
        moveInput = Input.GetAxisRaw("Horizontal"); 
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0 && !isFacingRight) 
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }
    }
    private void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score; // Cập nhật điểm số vào Text
    }

    // Hàm lật nhân vật
    private void Flip()
    {
        isFacingRight = !isFacingRight; // Đổi hướng
        Vector3 localScale = transform.localScale; // Lấy kích thước hiện tại của nhân vật
        localScale.x *= -1; // Lật hướng theo trục X
        transform.localScale = localScale; // Áp dụng kích thước mới
    }

    // Hàm xử lý va chạm với trứng và bom
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg")) // Hứng trứng
        {
            score += 10; // Cộng 10 điểm
            Destroy(collision.gameObject); // Xóa trứng khỏi Scene
            UpdateScoreUI(); // Cập nhật UI
        }
        else if (collision.CompareTag("Bomb")) // Hứng bom
        {
            score -= 5; // Trừ 5 điểm
            Destroy(collision.gameObject); // Xóa bom khỏi Scene
            UpdateScoreUI(); // Cập nhật UI
        }
    }
}



