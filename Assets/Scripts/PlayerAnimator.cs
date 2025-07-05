using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator animator;
    PlayerMovement playerMovement;
    SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.moveDir.x !=0)
        {
            animator.SetBool("Move", true);

            SpriteDirectionChecker();
        }
        else
        {
            animator.SetBool("Move", false);
        }
        if (playerMovement.moveDir.y < 0)
        {
            animator.SetBool("MoveX", true);
            animator.SetBool("MoveXUp", false);

        }
        else if(playerMovement.moveDir.y > 0)
        {
            animator.SetBool("MoveXUp", true);
            animator.SetBool("MoveX", false);

        }
        else
        {
            animator.SetBool("MoveXUp", false);
            animator.SetBool("MoveX", false);
        }
    }
    void SpriteDirectionChecker()
    {
        if(playerMovement.lastHorizontalVector < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX= false;
        }
    }
}
