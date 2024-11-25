using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject[] propsPrefabs;
    float currentYPos = 0f;
    public float cameraHeight = 5.5f;

    public Transform platformPool;
    public Transform propsPool;

    [SerializeField]private const float BOOMSIZE = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatformPool();
        SpawnProps();

        while(currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
        }
    }

    void SpawnPlatformPool()
    {
        int basicPlatformAmount = 30;
        int weakPlatformAmount = 15;

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
    }

    private void SpawnProps()
    {
        int boomPropsAmount = 5;
        for (int i = 0; i < boomPropsAmount; i++)
        {
            GameObject platform = Instantiate(propsPrefabs[0], propsPool);
            platform.SetActive(false);
        }
        int rocketPropsAmount = 5;
        for (int i = 0; i < rocketPropsAmount; i++)
        {
            GameObject platform = Instantiate(propsPrefabs[1], propsPool);
            platform.SetActive(false);
        }
    }

    void PickNewPlatform()
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

        //create props
        if(Random.Range(0,100) <= 10){
            CreateNewProps(xPos,currentYPos + BOOMSIZE);
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
    // Update is called once per frame
    void Update()
    {
        if(currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
        }
    }
}
