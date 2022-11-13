using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardThrower : MonoBehaviour
{
    public static CardThrower instance;
    public float cardSpeed,spawnTime,destroyTime;
    public bool dualShot, spreadShot,throwCard;

    [SerializeField] private GameData _gameData;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform cardSpawnPoint,cardSpawnPointRight,cardSpawnPointLeft;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        destroyTime = _gameData.Range;
        spawnTime = _gameData.ThrowRate;
        cardSpeed = _gameData.CardSpeed;
    }

    private void Start()
    {
        StartCoroutine(Throw());
    }

    IEnumerator Throw()
    {
        if (throwCard)
        {
            if (InputSystem.instance.GameStart)
            {
                if (!dualShot && !spreadShot)
                {
                    GameObject card = ObjectPool.instance.GetCardObjects();
                    card.transform.position = cardSpawnPoint.position;
                    card.transform.rotation = Quaternion.Euler(0, 0, 0);
                    card.GetComponent<Rigidbody>().velocity = card.transform.forward * cardSpeed;
                    StartCoroutine(DestroyCard(card));
                }
                else if (dualShot && !spreadShot)
                {
                    GameObject card = ObjectPool.instance.GetCardObjects();
                    card.transform.position = cardSpawnPointRight.position;
                    card.transform.rotation = Quaternion.Euler(0, 0, 0);
                    card.GetComponent<Rigidbody>().velocity = card.transform.forward * cardSpeed;
                    StartCoroutine(DestroyCard(card));

                    GameObject card1 = ObjectPool.instance.GetCardObjects();
                    card1.transform.position = cardSpawnPointLeft.position;
                    card1.transform.rotation = Quaternion.Euler(0, 0, 0);
                    card1.GetComponent<Rigidbody>().velocity = card1.transform.forward * cardSpeed;
                    StartCoroutine(DestroyCard(card1));
                }
                else if (!dualShot && spreadShot)
                {
                    GameObject card = ObjectPool.instance.GetCardObjects();
                    card.transform.position = cardSpawnPoint.position;
                    card.transform.rotation = Quaternion.Euler(0, 0, 0);
                    card.GetComponent<Rigidbody>().velocity = card.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card));

                    GameObject card1 = ObjectPool.instance.GetCardObjects();
                    card1.transform.position = cardSpawnPoint.position;
                    card1.transform.rotation = Quaternion.Euler(0, 10, 0);
                    card1.GetComponent<Rigidbody>().velocity = card1.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card1));

                    GameObject card2 = ObjectPool.instance.GetCardObjects();
                    card2.transform.position = cardSpawnPoint.position;
                    card2.transform.rotation = Quaternion.Euler(0, -10, 0);
                    card2.GetComponent<Rigidbody>().velocity = card2.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card2));

                }
                else
                {
                    GameObject card = ObjectPool.instance.GetCardObjects();
                    card.transform.position = cardSpawnPointRight.position;
                    card.transform.rotation = Quaternion.Euler(0, 0, 0);
                    card.GetComponent<Rigidbody>().velocity = card.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card));

                    GameObject card1 = ObjectPool.instance.GetCardObjects();
                    card1.transform.position = cardSpawnPointRight.position;
                    card1.transform.rotation = Quaternion.Euler(0, 10, 0);
                    card1.GetComponent<Rigidbody>().velocity = card1.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card1));

                    GameObject card2 = ObjectPool.instance.GetCardObjects();
                    card2.transform.position = cardSpawnPointRight.position;
                    card2.transform.rotation = Quaternion.Euler(0, -10, 0);
                    card2.GetComponent<Rigidbody>().velocity = card2.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card2));

                    GameObject card3 = ObjectPool.instance.GetCardObjects();
                    card3.transform.position = cardSpawnPointLeft.position;
                    card3.transform.rotation = Quaternion.Euler(0, 0, 0);
                    card3.GetComponent<Rigidbody>().velocity = card3.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card3));

                    GameObject card4 = ObjectPool.instance.GetCardObjects();
                    card4.transform.position = cardSpawnPointLeft.position;
                    card4.transform.rotation = Quaternion.Euler(0, 10, 0);
                    card4.GetComponent<Rigidbody>().velocity = card4.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card4));

                    GameObject card5 = ObjectPool.instance.GetCardObjects();
                    card5.transform.position = cardSpawnPointLeft.position;
                    card5.transform.rotation = Quaternion.Euler(0, -10, 0);
                    card5.GetComponent<Rigidbody>().velocity = card5.transform.TransformDirection(transform.forward) * cardSpeed;
                    StartCoroutine(DestroyCard(card5));
                }
            }

        }



        yield return new WaitForSeconds(spawnTime);

        StartCoroutine(Throw());
    }

    IEnumerator DestroyCard(GameObject card)
    {
        yield return new WaitForSeconds(destroyTime);
        card.SetActive(false);

    }

}
