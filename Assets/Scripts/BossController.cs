using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] spawnPoints;
    public int astcount;
    public GameObject enemy1;
    public int enemyCount = 30;
    bool state = true;
    private float maxHealt=25;
    private float healt = 25;
    public Image healtBar;
    public ParticleSystem particle;
    void Start()
    {
        GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state) { 
        if (GameController.gameController.isAstroidsIsClear) {
            GetComponent<Animator>().enabled = true;
            StartCoroutine(SpawnEnemy());
                state = false;
                healtBar.gameObject.SetActive(true);
                
        }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            GameController.gameController.AddBulletPrefabToList(collision.gameObject);
            collision.gameObject.SetActive(false);
            if (healt > 0)
            {
                healt--;
                healtBar.transform.localScale = new Vector3(healt/maxHealt,1,1);
            }
            else {
                particle = Instantiate(particle, transform.position, Quaternion.identity);
                particle.Play();
                Destroy(gameObject);
            }
        }
    }
    public IEnumerator SpawnEnemy() {

        
        if (enemyCount > 0)
        {
            yield return new WaitForSeconds(1f);
            GameObject gm= Instantiate(enemy1, spawnPoints[Random.Range(0, 3)]);
            gm.transform.SetParent(null);
            gm.GetComponent<Rigidbody2D>().gravityScale = 0.3f;

            enemyCount--;
            yield return SpawnEnemy();

        }
        else {
            StopCoroutine(SpawnEnemy());
        }
        
        
    }
}
