using UnityEngine;

public class bulletCharacteristics : MonoBehaviour
{
    public float bulletDamage;
    public float lifeTime;
    public string[] tagsThatDestroy;

    
   

    private void Awake()
    {
        transform.parent = GameObject.Find("BulletContainer").transform;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(string tag in tagsThatDestroy)
        {
            Debug.Log(collision.gameObject.tag);

            if (collision.gameObject.tag == tag)
            {

                if (collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<EnemyController>().damageEnemy(bulletDamage);
                    Collider[] colliders = Physics.OverlapSphere(transform.position, 50f);
                    foreach(Collider closeObjects in colliders)
                    {
                        Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();
                        if(rigidbody != null)
                        {
                            rigidbody.AddExplosionForce(500f, transform.position, 0.5f);
                        }
                    }
                }

                //Particle System

                Destroy(gameObject);

            }
        }
        

    }
}
