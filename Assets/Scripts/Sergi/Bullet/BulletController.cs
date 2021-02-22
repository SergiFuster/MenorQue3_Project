using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Range(0f, 5f)]
    public float bulletVelocity;


    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, transform.right, bulletVelocity);
    }
}
