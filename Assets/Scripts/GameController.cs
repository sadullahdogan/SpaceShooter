using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameController gameController;
    private bool gameState;//Oyunun devam edip etmedğini belli edecek olan değişken 
    private int numberOfLifes = 3;//palyerin can sayısı
    private int score;//puan 
    private List<string> killedEnemies;
    private GameObject enemies1Level1;
    public bool enemy1IsClear;
    public bool isAstroidsIsClear;
    private int level1Enemycount;
    public int astroidCount=100;
    public void DecreaseAstroidCount() {
        astroidCount--;
    }



    private List<GameObject> bulletList = new List<GameObject>();
    private List<GameObject> mineList = new List<GameObject>();
    private List<GameObject> redBulletList = new List<GameObject>();

    public void AddRedBulletPrefabToList(GameObject aBullet)
    {
        redBulletList.Add(aBullet);
    }
    public GameObject GetRedBulletFromBulletList()
    {
        GameObject temp = redBulletList[0];
        redBulletList.RemoveAt(0);
        return temp;
    }
    public int GetCountRedBulletList()
    {
        return redBulletList.Count;
    }

    public void Addmine(GameObject aMine)
    {
        mineList.Add(aMine);
    }

    public void AddBulletPrefabToList(GameObject aBullet) {
        bulletList.Add(aBullet);
    }
    public GameObject GetMineFromList()
    {
        GameObject temp = mineList[0];
        mineList.RemoveAt(0);
            return temp;
    }
    public int GetMineListCount()
    {
        return mineList.Count;
    }
    public GameObject GetBulletFromBulletList() {
        GameObject temp = bulletList[0];
        bulletList.RemoveAt(0);
        return temp;
    }
    public int GetCountBulletList() {
        return bulletList.Count;
    }
    public void SetScore(int aScore)
    {
        score = aScore;
    }
    public int GetScore()
    {
        return score;
    }
    public void IncreaseScore(int aValue)
    {
        score += aValue;
        GameObject UI = GameObject.FindGameObjectWithTag("UserInterface");
        UI.GetComponent<UIController>().SetMainPanelScoreText(score);
    }
    public int GetNumberOfLifes()
    {

        return numberOfLifes;
    }
    public void SetNumberOfLifes(int aLife)
    {

        numberOfLifes = aLife;
       
    }
    public void IncreaseNumberOfLifes()
    {
        if (numberOfLifes < 3)
            numberOfLifes++;
        GameObject UI = GameObject.FindGameObjectWithTag("UserInterface");
        UI.GetComponent<UIController>().SetNumberOfLifeVisual(numberOfLifes);
    }
    public void DecreaseNumberOfLifes()
    {
        if (numberOfLifes > 0)
            numberOfLifes--;
        GameObject UI = GameObject.FindGameObjectWithTag("UserInterface");
        UI.GetComponent<UIController>().SetNumberOfLifeVisual(numberOfLifes);

    }
    public void RestartScene()
    {
        SetGameState(true);
        
        bulletList.Clear();
        mineList.Clear();
        
        GameObject UI = GameObject.FindGameObjectWithTag("UserInterface");
        UI.GetComponent<UIController>().RestartCurrentScene();

    }
     public IEnumerator RestartScene(float time)
    {
        SetGameState(true);
        yield return new WaitForSeconds(time);
        
        bulletList.Clear();
        mineList.Clear();
        GameObject UI = GameObject.FindGameObjectWithTag("UserInterface");
        UI.GetComponent<UIController>().RestartCurrentScene();
        Debug.Log("MErhaba Sadullah");

        // Code to execute after the delay
    }
    void Start()
    {
        killedEnemies = new List<string>();
        gameState = true;
        enemies1Level1 = GameObject.FindGameObjectWithTag("Enemies1Level1");
        level1Enemycount = enemies1Level1.transform.childCount;




    }
    public bool CheckId(string aId)
    {
        if (killedEnemies == null)
            killedEnemies = new List<string>();
        return killedEnemies.Contains(aId);
    }
    public void AddIdToKilledEnemies(string aId)
    {
        killedEnemies.Add(aId);
        
        if (level1Enemycount== killedEnemies.Count) {
            enemy1IsClear = true;
            
        }
       
    }
    private void Awake()
    {
        if (GameController.gameController == null)
        {
            GameController.gameController = this;
        }
        else
        {
            if (this != GameController.gameController)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(GameController.gameController.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGameState(bool aState)
    {
        gameState = aState;
    }
    public bool GetGameState()
    {
        return gameState;
    }
}
