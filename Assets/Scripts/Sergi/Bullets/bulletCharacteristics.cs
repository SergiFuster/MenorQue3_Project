using UnityEngine;

public class bulletCharacteristics : MonoBehaviour
{
    public float bulletDamage;
    public float bulletVelocity;
    public float lifeTime;
    public string[] tagsThatDestroy;

    
   

    private void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);
        transform.parent = GameObject.Find("BulletContainer").transform;
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(string tag in tagsThatDestroy)
        {

            if (collision.gameObject.tag == tag)
            {

                if (collision.gameObject.tag == "Enemy")
                {
                    collision.gameObject.GetComponent<EnemyHealth>().damageEnemy(bulletDamage);
                }

                //Particle System

                Destroy(gameObject);

            }
        }
        

    }
}
