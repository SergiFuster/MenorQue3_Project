using UnityEngine;

public class turretBulletCharacteristics : MonoBehaviour
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

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().damaged(bulletDamage);
        }

    }

}