using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropsType{
    Boom,Rocket
}
public class Props : MonoBehaviour
{
    [SerializeField]private PropsType type;
    //Boom
    [SerializeField]private float bounceSpeed = 20;
    //Rocket
    [SerializeField]private float forceMagnitude = 20;
    [SerializeField]private float forceTime = 1.0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal == Vector2.down)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            GetSuperPower(rb,type);
        }
    }
    private void GetSuperPower(Rigidbody2D rb, PropsType type){
        if(rb == null) return ;

        if(type == PropsType.Boom){
            rb.velocity = Vector2.up * bounceSpeed;
            //audio
        }else if(type == PropsType.Rocket){
            rb.GetComponent<Doodler>().SetterRocketState();
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MainCamera"))
        {
            gameObject.SetActive(false);
        }
    }

}
