using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Range(0f, 5f)]
    public float bulletVelocity;
    public float lifeTime;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, transform.right, bulletVelocity);
    }
}
