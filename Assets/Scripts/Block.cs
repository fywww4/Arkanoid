using UnityEngine;

public class Block : MonoBehaviour
{
    public int scoreValue = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
