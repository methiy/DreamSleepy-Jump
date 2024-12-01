using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private float bloodNumber;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.tag == "Bullet"){
            Hurt(other.gameObject.GetComponent<Bullet>().GetterDamage());
        }
    }

    private void Hurt(float hurtValue){
        bloodNumber -= hurtValue;
        if(bloodNumber <= 0){
            Dead();
        }else{
            //hurt animator
        }
    }

    private void Dead(){
        //dead animator 
        //0.4 is the animation time 
        Invoke("HideGameObject", 0.4f); 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("MainCamera"))
        {
            HideGameObject();
        }
    }

    void HideGameObject()
    {
        gameObject.SetActive(false);
    }
}
