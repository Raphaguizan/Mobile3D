using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

[System.Serializable]
public class AnimationSetup
{
    public AnimationType type;
    public string trigger;
    public float speed = 1f;
}
