using UnityEngine;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            GameManager.instance.LoseLife();

            if (GameManager.instance.lives > 0)
            {
                // 重置球位置
                col.transform.position = new Vector2(0, -3);
                // 重置速度
                Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.up * 100;
            }


        }
    }


}
