using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointFlag : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private GameObject particleEffect;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == Constants.Layers.Player)
        {
            AudioManager.Instance.PlaySound((int)AudioManager.AudioClipsEnum.FlagPop);
            boxCollider.enabled = false;
            anim.SetTrigger(Constants.FlagAnimator.Pop);
            particleEffect.SetActive(true);
        }
    }
}
