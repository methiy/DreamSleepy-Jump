using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PropsType{
    Boom,Rocket,Shield,ForceBullet,Portal
}
public class Props : MonoBehaviour
{
    [SerializeField]private PropsType type;
    //Boom
    [SerializeField]private float bounceSpeed = 20;
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
        }else if(type == PropsType.Shield){
            rb.GetComponent<Doodler>().SetterRocketState();
            gameObject.SetActive(false);
        }else if(type == PropsType.ForceBullet){
            rb.GetComponent<Doodler>().SetterBulletDamage();
            gameObject.SetActive(false);
        }else if(type == PropsType.Portal){
            rb.GetComponent<Doodler>().PortalPosition();
            gameObject.SetActive(false);
        }else{
            //todo
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
