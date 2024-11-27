using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPlaPlatformtform : Platform
{
    private  void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.contacts[0].normal == Vector2.down)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = Vector2.up * bounceSpeed;
            }

            if(GetComponent<Animator>() != null)
            {
                GetComponent<Animator>().SetTrigger("Trigger");
                //audio
                Invoke("HideGameObject", 0.4f);
            }
        }
    }
}
