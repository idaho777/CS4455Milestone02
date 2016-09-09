using UnityEngine;
using System.Collections;

public class X_Bot_Controller : MonoBehaviour {

    private Animator animator;
    private AnimatorStateInfo currBaseState;

    private float currentSpeed;

    static int idleState = Animator.StringToHash("Base Layer.Idle");
    static int forwardState = Animator.StringToHash("Base Layer.Forward");
    static int forwardJumpState = Animator.StringToHash("Base Layer.ForwardJump");
    static int forwardFallingState = Animator.StringToHash("Base Layer.ForwardFalling");
    static int backState = Animator.StringToHash("Base Layer.Backward");
    static int idleJumpState = Animator.StringToHash("Base Layer.IdleJump");

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        currentSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 10; ++i)
        {
            if (Input.GetKey("" + i))
            {
                currentSpeed = i;
                print(currentSpeed);
            }
        }
        
        animator.SetFloat("forward", (currentSpeed == 0) ? Input.GetAxis("Vertical") : currentSpeed / 10f * Input.GetAxis("Vertical"));
        //animator.SetFloat("forward", Input.GetAxis("Vertical"));
        animator.SetFloat("left_right", Input.GetAxis("Horizontal"));
        animator.SetFloat("soft_left_right", Input.GetAxis("SoftHorizontal"));
        currBaseState = animator.GetCurrentAnimatorStateInfo(0);

        if (currBaseState.fullPathHash == idleState)
        {
            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("isJumping", true);
            }
        }
        else if (currBaseState.fullPathHash == idleJumpState)
        {
            if (!animator.IsInTransition(0))
            {
                animator.SetBool("isJumping", false);
            }
        }

        if (currBaseState.fullPathHash == forwardState)
        {
            if (Input.GetKeyDown("space"))
            {
                animator.SetBool("isJumping", true);
            }
        }
        else if (currBaseState.fullPathHash == forwardJumpState)
        {
            if (!animator.IsInTransition(0))
            {
                animator.SetBool("isJumping", false);
            }
        }

    }
}
