using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject[] propsPrefabs;
    public GameObject[] bulletPrefabs;
    public GameObject[] enemyPrefabs;

    float currentYPos = 0f;
    public float cameraHeight = 5.5f;

    public Transform platformPool;
    public Transform propsPool;
    public Transform bulletPool;
    public Transform enemyPool;

    [SerializeField]private const float BOOMSIZE = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatformPool();
        SpawnPropsPool();
        SpawnBulletPool();
        SpawnEnemyPool();

        while(currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
            if(Random.Range(0,1000) <= 10)  CreateNewEnemy();
        }
    }

    private void SpawnPlatformPool()
    {
        int basicPlatformAmount = 20;
        int weakPlatformAmount = 10;
        int movePlatformAmount = 5;

        for (int i = 0; i < basicPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[0], platformPool);
            platform.SetActive(false);
        }

        for (int i = 0; i < weakPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[1], platformPool);
            platform.SetActive(false);
        }

        for (int i = 0; i < movePlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[2], platformPool);
            platform.SetActive(false);
        }
    }

    private void SpawnPropsPool()
    {
        int boomPropsAmount = 5;
        for (int i = 0; i < boomPropsAmount; i++)
        {
            GameObject platform = Instantiate(propsPrefabs[0], propsPool);
            platform.SetActive(false);
        }
        int rocketPropsAmount = 1;
        for (int i = 0; i < rocketPropsAmount; i++)
        {
            GameObject platform = Instantiate(propsPrefabs[1], propsPool);
            platform.SetActive(false);
        }
    }

    void SpawnBulletPool(){
        int bulletPropsAmount = 20;
        for (int i = 0; i < bulletPropsAmount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefabs[0], bulletPool);
            bullet.SetActive(false);
        }
    }
    public Transform GetBulletSpawn(){
        for(int i=0;i<bulletPool.childCount;i++){
            if(!bulletPool.GetChild(i).gameObject.activeInHierarchy){
                return bulletPool.GetChild(i);
            }
        }
        return null;;
    }

    private void PickNewPlatform()
    {
        currentYPos += Random.Range(0.6f, 1f);
        float xPos = Random.Range(-3.5f, 3.5f);

        int r = 0;
        do
        {
            r = Random.Range(0, platformPool.childCount);
        } while (platformPool.GetChild(r).gameObject.activeInHierarchy);

        platformPool.GetChild(r).position = new Vector2(xPos, currentYPos);
        platformPool.GetChild(r).gameObject.SetActive(true);

        if(platformPool.GetChild(r).gameObject.GetComponent<Platform>().platformType == PlatformType.normal){
            //create props
            if(Random.Range(0,100) <= 10){
                CreateNewProps(xPos,currentYPos + BOOMSIZE);
            }
        }
        
    }

    private void CreateNewProps(float xPos,float yPos){

        int r = 0;
        int chanceCount = 0;
        do
        {
            chanceCount++;
            r = Random.Range(0, propsPool.childCount);
        } while (chanceCount < 10&&propsPool.GetChild(r).gameObject.activeInHierarchy);

        if(chanceCount >=10 )   return ;
        propsPool.GetChild(r).position = new Vector2(xPos, yPos);
        propsPool.GetChild(r).gameObject.SetActive(true);

    }

    private void SpawnEnemyPool(){
        int movingEnemyAmount = 5;
        for (int i = 0; i < movingEnemyAmount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[0], enemyPool);
            enemy.SetActive(false);
        }
        int shadowEnemyAmount = 1;
        for (int i = 0; i < shadowEnemyAmount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefabs[1], enemyPool);
            enemy.SetActive(false);
        }
    }
    private void CreateNewEnemy(){

        currentYPos += Random.Range(0.6f, 1f);
        float xPos = Random.Range(-2f, 2f);

        int r = 0;
        do
        {
            r = Random.Range(0, enemyPool.childCount);
        } while (enemyPool.GetChild(r).gameObject.activeInHierarchy);

        enemyPool.GetChild(r).position = new Vector2(xPos, currentYPos);
        enemyPool.GetChild(r).gameObject.SetActive(true);

    }

    [SerializeField]private Score score;

    private void UpdateScore(float v){
        score.AddScore(v);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
            UpdateScore(Random.Range(1000,2000));
            if(Random.Range(0,1000) <= 10)  CreateNewEnemy();
        }
    }
}
