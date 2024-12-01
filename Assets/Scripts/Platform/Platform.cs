using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlatformType
{
    normal, weak, move
}

public class Platform : MonoBehaviour
{
    public PlatformType platformType;
    public float bounceSpeed = 4f;

    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal == Vector2.down)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = Vector2.up * bounceSpeed;
            }

            //Weak Platform
            if(platformType == PlatformType.weak)
            {
                if(GetComponent<Animator>() != null)
                {
                    GetComponent<Animator>().SetTrigger("Trigger");
                    //weakplatform audio
                    Invoke("HideGameObject", 0.4f);
                }
            }else{
                //otherplatform audio 
                
            }
        }
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
