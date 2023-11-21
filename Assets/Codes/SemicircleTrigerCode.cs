using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SemicircleTrigerCode : MonoBehaviour
{
    public GameObject particle;
    
    public SpriteRenderer spriteRenderer;
    public SemicircleCode semicircleCode;
    public ObstacleCode obstacleCode;
    public MenuCode menuCode;
    int increaseSpeed;
    
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("obstacle"))
        {
            
            StartCoroutine(anim_and_go());
            
    
        }
        if (collision.gameObject.CompareTag("score"))
        {
            
            increaseSpeed++;
            menuCode.Increase_Score();
            
            menuCode.audioSource.volume = 1;
            menuCode.audioSource.PlayOneShot(menuCode.scoreSound);
            menuCode.audioSource.volume = 0.2f;
            if (increaseSpeed == 3)
            {
                semicircleCode.speed += 0.02f;
                obstacleCode.instantiate_speed -= 0.5f;
                increaseSpeed = 0;
            }
        }
    }

    IEnumerator anim_and_go()
    {
        Instantiate(particle.gameObject, gameObject.transform.position, Quaternion.identity);
        spriteRenderer.enabled = false;
        semicircleCode.canMove = false;
        menuCode.audioSource.Stop();
        menuCode.audioSource.PlayOneShot(menuCode.gameoverSound);
        yield return new WaitForSeconds(1.5f);
        menuCode.Set_BestandLastScore();
    }
    
}
