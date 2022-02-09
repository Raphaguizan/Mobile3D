using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemCollectableBase : MonoBehaviour
{
    [Header("Collectable")]
    public string playerTag = "Player";
    public float timeToDestroy = 3f;
    public GameObject Image;

    private Collider _collisionBox;
    private void Awake()
    {
        _collisionBox = GetComponent<Collider>();
        _collisionBox.enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag(playerTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollet();
        Image.SetActive(false);
        _collisionBox.enabled = false;
        Destroy(gameObject, timeToDestroy);
    }


    protected virtual void OnCollet(){}
}
