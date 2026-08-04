using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(transform.position.y > 12f)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if(colision.CompareTag("Enemy"))
        {
            //ScoreManager.Instance.AddScore(10);
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(10);
            }

            EnemyController enemyCont = colision.GetComponent<EnemyController>();
            if (enemyCont != null)
            {
                enemyCont.Die();
            }
            else
            {
                Destroy(colision.gameObject);
            }

            Destroy(colision.gameObject);
            Destroy(gameObject);
        }
    }
}
