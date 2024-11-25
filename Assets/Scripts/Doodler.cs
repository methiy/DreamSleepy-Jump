using UnityEngine;

public class Doodler : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    [SerializeField]private float rocketPropsTime = 0.5f;
    [SerializeField]private float rocketPropsLeftTime = 0.5f;
    [SerializeField]private float rocketPropsForce = 20f;
    [SerializeField]private bool hasRocket;
    public void SetterRocketState(){
        hasRocket = true;
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

}