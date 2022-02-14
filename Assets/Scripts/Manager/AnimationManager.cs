using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum AnimationType
{
    IDLE,
    RUN,
    DIE,
    FLY
}

[RequireComponent(typeof(Animator))]
public class AnimationManager : MonoBehaviour
{
    public List<AnimationSetup> animations;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PowerUpBase.PowerUpCollected += PlayPowerUpTween;
    }

    private void OnDisable()
    {
        PowerUpBase.PowerUpCollected -= PlayPowerUpTween;
    }

    public void Play(AnimationType type, float speedFactor = 1f)
    {
        animations.ForEach(i => { 
            if (i.type == type) 
            {
                anim.SetTrigger(i.trigger);
                anim.speed = i.speed * speedFactor;
            } 
        });
    }
    #region tween
    [Header("Tween Animations")]
    public TweenAnimationSetup startTween;
    public TweenAnimationSetup PowerUpTween;

    public void PlayStartTween()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, startTween.duration).SetEase(startTween.ease);
    }

    [ContextMenu("Powerup Animation")]
    public void PlayPowerUpTween()
    {
        transform.DOScale( 1.1f, PowerUpTween.duration).SetEase(PowerUpTween.ease).SetLoops(2, LoopType.Yoyo);
    }
    #endregion
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationType type;
    public string trigger;
    public float speed = 1f;
}

[System.Serializable]
public class TweenAnimationSetup
{
    public float duration = 1f;
    public Ease ease = Ease.OutBack;
}
