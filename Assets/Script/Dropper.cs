using System.Collections;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameObject[] prefabBalls; // Mảng chứa prefab trứng và bom
    public float delay = 1.0f;       // Thời gian giữa mỗi lần spawn

    private int minX = -7;           // Giới hạn tọa độ X bên trái
    private int maxX = 7;            // Giới hạn tọa độ X bên phải
    private float spawnY = 7.0f;     // Vị trí Y để spawn các vật thể

    void Start()
    {
        StartCoroutine(SpawnBalls());
    }

    IEnumerator SpawnBalls()
    {
        while (true)
        {
            // Chọn vị trí ngẫu nhiên trong khoảng minX và maxX
            float randomX = Random.Range(minX, maxX);
            Vector2 spawnPosition = new Vector2(randomX, spawnY);

            // Chọn một prefab ngẫu nhiên từ mảng prefabBalls
            int randomIndex = Random.Range(0, prefabBalls.Length);
            GameObject selectedPrefab = prefabBalls[randomIndex];

            // Kiểm tra nếu prefab hợp lệ
            if (selectedPrefab != null)
            {
                Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Prefab tại vị trí " + randomIndex + " bị null!");
            }

            // Chờ trước khi spawn tiếp
            yield return new WaitForSeconds(delay);
        }
    }
}
