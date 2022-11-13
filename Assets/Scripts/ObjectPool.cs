using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private Queue<GameObject> _pooledObjects = new Queue<GameObject>();
    [SerializeField] private int _poolSize;
    [SerializeField] private GameObject card;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        for(int i =0; i<_poolSize; i++)
        {
            GameObject cardObject = Instantiate(card);
            cardObject.transform.SetParent(transform);
            cardObject.SetActive(false);

            _pooledObjects.Enqueue(cardObject);
            
        }
    }

    public GameObject GetCardObjects()
    {
        GameObject cardObject = _pooledObjects.Dequeue();
        cardObject.SetActive(true);
        _pooledObjects.Enqueue(cardObject);

        return cardObject;
    }


}
