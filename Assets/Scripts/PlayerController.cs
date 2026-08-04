using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftBoundary = -2.5f;
    public float rightBoundary = 2.5f;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletCooldown = 0.2f;
    private float fireTimer = 0f;

    void Update()
    {
        //manage movement
        //float movingInput = Input.GetAxisRaw("Horizontal");
        float movingInput = 0f;
        if (Keyboard.current != null)
        {
            if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
            {
                movingInput = -1f;
            }
            else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
            {
                movingInput = 1f;
            }
        }
        
        Vector3 pos = transform.position;
        pos.x += movingInput * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, leftBoundary, rightBoundary);
        transform.position = pos;

        //manage bullet
        fireTimer += Time.deltaTime;

        bool isSpacePressed = Keyboard.current != null && Keyboard.current.spaceKey.isPressed;
        //if(Input.GetKey(KeyCode.Space) && fireTimer >= bulletCooldown)
        if (isSpacePressed && fireTimer >= bulletCooldown)
        {
            ShootBullet();
            fireTimer = 0f;
        }
    }

    void ShootBullet()
    {
        if(bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Bullet prefab or spawn point is not assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /**if (collision.CompareTag("Enemy"))
        {
            //collision with enemy, remove one life
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RemoveLife();
            }
        }
        else **/if (collision.CompareTag("ItemHeal"))
        {
            //collision with item, add one life
            if (GameManager.Instance != null)
            {
                GameManager.Instance.Addhealth();
            }
            Destroy(collision.gameObject);
        }
    }
}
