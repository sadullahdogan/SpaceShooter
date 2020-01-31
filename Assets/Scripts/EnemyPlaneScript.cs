using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneScript : MonoBehaviour
{
    public GameObject mine,upgradeBullet,shield;
    private GameObject player;
    public int score;
    private string id;
    bool isBombDrop;
    public ParticleSystem particle;



    private void Start()
    {
        
        id = CreateId();
        if (GameController.gameController.CheckId(id))
            Destroy(gameObject);
        score = 10;
        player = GameObject.FindGameObjectWithTag("Player");
        isBombDrop= true;
        


        
    }
    private string CreateId()
    {

        string value = gameObject.name + transform.position.ToString();//Objenin adına ve bulunduğu konumdan oluşan bir id atadık
        //böyle yapmamzın sebebi idyi başka bi obje tarafından oluşturulmasını engellemek 
        return value;
    }
    private void Update()
    {
        if (GameController.gameController.GetGameState())
        {
            if (Mathf.Abs(player.transform.position.x - transform.position.x) < 3)
            {
                if (isBombDrop)
                {
                    
                        Instantiate(mine, transform.position, Quaternion.identity);
                        StartCoroutine(SetBomb());
                        isBombDrop = false;
                    
                   
                }
            }
        }
        else {
            GetComponent<Animator>().enabled = false;
        }
    }
    IEnumerator SetBomb()
    {
        isBombDrop = true;
        yield return new WaitForSeconds(5);
        yield return SetBomb();
    }
    private void OnCollisionEnter2D(Collision2D collision)//Merminin çarpışma eventi
    {
       
        if (collision.gameObject.CompareTag("Fire"))
        {
            


            GameController.gameController.AddBulletPrefabToList(collision.gameObject);
            collision.gameObject.SetActive(false);
            GameController.gameController.AddIdToKilledEnemies(id);
            GameController.gameController.IncreaseScore(score);
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<AudioSource>().Play();
            particle = Instantiate(particle, transform.position, Quaternion.identity);
            particle.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            
            Destroy(this.gameObject,1f);
            int sayi = Random.Range(0, 10);
            if (sayi == 2) {

                Instantiate(upgradeBullet,transform.position,Quaternion.identity);
            }
            
            
            

        }
    }
}
