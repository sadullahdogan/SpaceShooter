using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] astroids;

    

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameController.enemy1IsClear) {
            StartCoroutine(ThrowAstroid());
            GameController.gameController.enemy1IsClear = false;

        }
    }
    
    IEnumerator ThrowAstroid() {
        //-18 45
        if (GameController.gameController.astroidCount > 0)
        {
            yield return new WaitForSeconds(0.6f);
            float x = Random.Range(-28f, 35f);
            int i = Random.Range(0, 2);
            Vector2 pos = new Vector2(transform.position.x + x, transform.position.y);
            GameObject astroid = Instantiate(astroids[i], pos, Quaternion.identity);
            astroid.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -10);
            GameController.gameController.DecreaseAstroidCount();
        }
        else {
            StopAllCoroutines();
            GameController.gameController.isAstroidsIsClear = true;
            
        }

        yield return ThrowAstroid();
    }

}
