using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoneyRope : MonoBehaviour
{
    [SerializeField] private GameObject moneyPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Card"))
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            RaiseTheRope();
            MoneyAddRigidbody();
        }
    }

    void RaiseTheRope()
    {
        transform.DOMoveY(transform.localPosition.y + 2f, 2).OnComplete(() => gameObject.SetActive(false));
    }

    void MoneyAddRigidbody()
    {
        moneyPrefab.AddComponent<Rigidbody>();
    }
}
