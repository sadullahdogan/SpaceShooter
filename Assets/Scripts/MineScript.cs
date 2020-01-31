using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 2;
    public ParticleSystem particle;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameController.GetGameState())
            transform.position -= transform.up * 0.1f;
    }
    private void OnBecameInvisible()
    {
        GameController.gameController.Addmine(gameObject);
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Fire"))
        {
            GameController.gameController.IncreaseScore(score);
            GameController.gameController.AddBulletPrefabToList(collision.gameObject);
            collision.gameObject.SetActive(false);
            //GameController.gameController.Addmine(gameObject);
            //gameObject.SetActive(false);
           
            particle = Instantiate(particle, transform.position, Quaternion.identity);
            particle.Play();
            Destroy(gameObject);
        }
    }
}
