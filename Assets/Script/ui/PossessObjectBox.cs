using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PossessObjectBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private PlayerMovement player;
    void Start()
    {
        player = (PlayerMovement)FindObjectOfType(typeof(PlayerMovement));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        player.mouseOverSomeThing = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        player.mouseOverSomeThing = false;
    }
}
