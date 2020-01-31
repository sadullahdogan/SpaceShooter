using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEnter : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 3f;
    float timer1 = 1.2f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 0)
        {
            GetComponent<Animator>().enabled = true;
            if (timer1 < 0)
            {
                GetComponent<Animator>().enabled = false;
            }
            else
            {
                timer1 -= Time.deltaTime;
            }
        }
        else
        {
            timer -= Time.deltaTime;

        }
    }
}
