using Unity.VisualScripting;
using UnityEngine;

public class Doodler : MonoBehaviour
{

    [SerializeField]private float bulletDamage;
    public void SetterBulletDamage(){
        bulletDamage *= 2;
    }
    public float moveSpeed;
    private Rigidbody2D rb;
    [SerializeField]private LevelGenerator pool;

    [SerializeField]private float rocketPropsTime = 0.5f;
    [SerializeField]private float rocketPropsLeftTime = 0.5f;
    [SerializeField]private float rocketPropsForce = 20f;
    [SerializeField]private bool hasRocket;

    public void SetterRocketState(){
        hasRocket = true;
    }
    [SerializeField]private float shieldPropsTime = 3f;
    [SerializeField]private float shieldPropsLeftTime = 3f;
    [SerializeField]private bool hasShield;
    public void SetterShieldState(){
        hasShield = true;
    }
    public bool GetterShieldState(){
        return hasShield;
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rocketPropsLeftTime = rocketPropsTime;
    }
    private void Update(){

        if (hasRocket){
            if(rocketPropsLeftTime>0){
                rocketPropsLeftTime -= Time.deltaTime;
            }else{
                rocketPropsLeftTime = rocketPropsTime;
                hasRocket = false;
            }
        }

        if(hasShield){
            if(shieldPropsLeftTime>0){
                shieldPropsLeftTime -= Time.deltaTime;
            }else{
                shieldPropsLeftTime = shieldPropsTime;
                hasShield = false;
            }
        }

        if (Input.GetMouseButtonDown(0)) // 检测鼠标左键按下
        {
            ShootBullet();
        }

        UpdateScore(Time.deltaTime * 1000);
    }

    [SerializeField]private Score score;

    private void UpdateScore(float v){
        score.AddScore(v);
    }

    public GameObject bulletPrefab; // 弹丸预制体
    [SerializeField]private float shootSpeed = 10f;

    private void ShootBullet()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0); // 确定子弹生成的位置
        GameObject newBullet = pool.GetBulletSpawn().gameObject;
        if(newBullet != null){
            //shooter audio 
            newBullet.transform.position = spawnPosition;
            newBullet.SetActive(true);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if(rb != null)  rb.velocity = new Vector2(0,shootSpeed);
        }
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if (h != 0)
        {
            transform.localScale = new Vector3(-h, 1, 1);
        }

        if(hasRocket){
            rb.AddForce(new Vector2(0,rocketPropsForce), ForceMode2D.Force);
            //audio
        }
        
    }
    private void GameOver()
    {
        Debug.Log("GameOver");
        // 重置游戏状态
        gameObject.SetActive(false);
    }


    public void PortalPosition(){
        
    }

}