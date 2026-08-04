using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float dropSpeed = 5f;

    private bool hasCollided = false;

    public GameObject itemPrefab;

    [Range(0f, 1f)] public float itemDropChance = 0.2f;

    void Update()
    {
        float speedMultiplier = 1f;
        if (GameManager.Instance != null && CompareTag("Enemy"))
        {
            speedMultiplier = 1f + (GameManager.Instance.currentLevel - 1) * 0.2f;
        }
        
        transform.Translate(Vector3.down * (dropSpeed * speedMultiplier) * Time.deltaTime);
        
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollided)
        {
            return;
        }
        
        if(collision.CompareTag("Player") && CompareTag("Enemy"))
        {//collision with player, remove one life and destroy enemy
            hasCollided = true;
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RemoveLife();
            }
            //GameManager.Instance.RemoveLife();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("ItemHeal"))
        {
            //collision with item, add one life
            if (GameManager.Instance != null)
            {
                GameManager.Instance.Addhealth();
            }
            Destroy(collision.gameObject);
        }
    }

    public void Die()
    {
        if (hasCollided)
        {
            return;
        }

        if (itemPrefab != null && Random.value < itemDropChance)
        {
            Instantiate(itemPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

