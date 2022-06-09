using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
    public Animator player;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
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
    public float playerSwypeDuration = .1f;
}