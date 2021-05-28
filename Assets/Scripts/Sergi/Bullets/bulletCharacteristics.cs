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

    private void OnTriggerEnter(Collider collision)
    {

        foreach (string tag in tagsThatDestroy)
        {
            Debug.Log(collision.gameObject.tag);

            if (collision.gameObject.tag == tag)
            {



                //Particle System
                Destroy(gameObject);

            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyController zombie = collision.gameObject.GetComponent<EnemyController>();
            TurretController turret = collision.gameObject.GetComponent<TurretController>();
            if(zombie != null)
            {
                zombie.damageEnemy(bulletDamage);
            }
            else if(turret != null)
            {
                Debug.Log("turret hited");
                turret.damageEnemy(bulletDamage);
            }
        }

    }

}
