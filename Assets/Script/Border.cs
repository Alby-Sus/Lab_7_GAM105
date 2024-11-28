using UnityEngine;

public class BorderDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra tag của vật thể
        if (collision.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
        }
    }
}
