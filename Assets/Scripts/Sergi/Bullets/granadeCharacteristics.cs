using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granadeCharacteristics : MonoBehaviour
{
    public float lifeTime;
    public float explosionRadius;
    public float damage;
    public ParticleSystem explosion;
    public float maxShakeMagnitude;
    public float shakeDuration;

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0)
        {
            explode();
        }
    }

    void explode()
    {
        Collider[] touched = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider touch in touched)
        {
            if(touch.gameObject.tag == "Enemy")
            {
                EnemyController zombie = touch.gameObject.GetComponent<EnemyController>();
                TurretController turret = touch.gameObject.GetComponent<TurretController>();
                if (zombie != null)
                {
                    zombie.damageEnemy(damage);
                }
                else if (turret != null)
                {
                    turret.damageEnemy(damage);
                }

            }
            foreach (Collider closeObjects in touched)
            {
                if (closeObjects.gameObject.tag != "Player")
                {
                    Rigidbody rigidbody = closeObjects.GetComponent<Rigidbody>();
                    if (rigidbody != null)
                    {
                        rigidbody.AddExplosionForce(50000f, transform.position, 0.5f);
                    }
                }
            }
        }

        //Partycle System
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity, GameObject.Find("Trash").transform);
        CameraShake.Camera.Explosion(this.transform, maxShakeMagnitude, shakeDuration);


        Destroy(gameObject);
    }
}
