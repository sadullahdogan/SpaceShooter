using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidController : MonoBehaviour
{
    // Start is called before the first frame update
    private int enemyHealt = 2;
    public ParticleSystem particle;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire")) {
            enemyHealt--;
            GameController.gameController.AddBulletPrefabToList(collision.gameObject);
            collision.gameObject.SetActive(false);
            if (enemyHealt <= 0) {

                GameController.gameController.IncreaseScore(10);
                particle = Instantiate(particle, transform.position, Quaternion.identity);
                particle.Play();
                Debug.Log("Geldiiii");

                Destroy(gameObject);
            }
        
        }
    }
}
