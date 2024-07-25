using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MoreMountains.Feedbacks;

public class ItemBase : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public MMF_Player feedbacks { get; private set; }

    public string tagPlayer = "Player";
    public string tagBat = "Bat";

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        feedbacks = GetComponentInChildren<MMF_Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag(tagPlayer))
        {
            Collected();
        }

        else if (other.transform.CompareTag(tagBat))
        {
            Consumed();
        }
    }

    protected virtual void Collected()
    {
        //Debug.Log("Collected");
        MMF_ParticlesInstantiation collected = feedbacks.GetFeedbackOfType<MMF_ParticlesInstantiation>();
        spriteRenderer.enabled = false;
        collected.Play(transform.position, 1);

        ItemManager.instance.CollectOnion();

        Destroy(gameObject);
    }

    protected virtual void Consumed()
    {
        //Debug.Log("Consumed");
        MMF_ParticlesInstantiation collected = feedbacks.GetFeedbackOfType<MMF_ParticlesInstantiation>();
        spriteRenderer.enabled = false;
        collected.Play(transform.position, 1);

        ItemManager.instance.ConsumeOnion();

        Destroy(gameObject);
    }
}
