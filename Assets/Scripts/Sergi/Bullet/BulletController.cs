using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Range(0f, 5f)]
    public float lifeTime;
    Vector3 newPosition;
    [Range(10f, 100f)]
    public float bulletVelocity;
    Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
        transform.parent = GameObject.Find("BulletContainer").transform;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);

    }
}
