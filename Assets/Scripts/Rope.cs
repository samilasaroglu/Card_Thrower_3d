using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class Rope : MonoBehaviour
{
    private ObiRope rope;

    private void Awake()
    {
        rope = GetComponent<ObiRope>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Card"))
        {
            rope.Tear(rope.elements[rope.elements.Count / 2]);
            rope.RebuildConstraintsFromElements();

            gameObject.GetComponent<Collider>().enabled = false;

            other.gameObject.SetActive(false);
        }

    }

}
