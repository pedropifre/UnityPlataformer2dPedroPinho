using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public HealthBase healthBase;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f,0);   
    public float speed = 7;
    public float speedRun = 12;
    public float forceJump = 5;

    [Header("Aniamtion setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = 0.5f;
    public Ease ease = Ease.OutBack;


    [Header("Player Animation")]
    public string boolRun = "Run";
    public string triggerDeath = "Death";
    public Animator animator;
    public float playerSwypeDuration = .1f;

    private float _curentSpeed;


    private void Awake()
    {
        if(healthBase!=null)
        {
            healthBase.onKill += OnPlayerKill;
        }
    }

    private void OnPlayerKill()
    {
        healthBase.onKill -= OnPlayerKill;

        animator.SetTrigger(triggerDeath);
    }
    public void Update()
    {
        HandleMoviment();
        HandleJump();
    }

    private void HandleMoviment()
    {
        //verificar corrida
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _curentSpeed = speedRun;
            animator.speed = 2;
        }
        else
        {
            _curentSpeed = speed;
            animator.speed = 1;
        }
            

        //movimento
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.velocity = new Vector2(-_curentSpeed, myRigidBody.velocity.y);
            if(myRigidBody.transform.localScale.x != -1)
            {
                myRigidBody.transform.DOScaleX(-1, playerSwypeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.velocity = new Vector2(_curentSpeed, myRigidBody.velocity.y);
            if (myRigidBody.transform.localScale.x != 1)
            {
                myRigidBody.transform.DOScaleX(1, playerSwypeDuration);
            }
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
        }

        //eliminar fricção
        if(myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= friction; 
        }

        if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * forceJump;
            myRigidBody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidBody.transform);

            HandleScaleJump();
        }
    }

    private void HandleScaleJump()
    {
        myRigidBody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        myRigidBody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2,LoopType.Yoyo).SetEase(ease);
        //fazer a animação de queda com a função do DoTween para esperar a anterior acabar
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
