using UnityEngine;

public class Doodler : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if (h != 0)
        {
            transform.localScale = new Vector3(-h, 1, 1);
        }
        
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        // 重置游戏状态
        gameObject.SetActive(false);
    }

}