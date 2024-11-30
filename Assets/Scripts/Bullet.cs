using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float damage;
    private void SetterDamage(float damage){
        this.damage = damage;
    }
    public float GetterDamage(){
        return damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

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
