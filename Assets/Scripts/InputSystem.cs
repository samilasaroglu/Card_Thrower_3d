using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSystem : MonoBehaviour ,IDragHandler ,IPointerClickHandler
{
    public static InputSystem instance;
    public bool GameStart;
    public Animator _playerAnimator;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (!GameStart)
        {
            GameStart = true;
            _playerAnimator.SetBool("Run",true);
            CardThrower.instance.throwCard = true;
            UIManager.instance.OffMenu();


        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (GameStart)
        {
            PlayerMovement.instance.MoveHorizontal(data.delta);
        }
    }

}
