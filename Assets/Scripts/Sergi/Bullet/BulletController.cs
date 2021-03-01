using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Range(0f, 5f)]
    public float lifeTime;
    Vector3 newPosition;
    [Range(10f, 100f)]
    public float bulletVelocity;
    Rigidbody rb;
    public int bulletDamage = 25;

    private void Start()
    {
        transform.parent = GameObject.Find("BulletContainer").transform;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Player")
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().damageEnemy(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}
