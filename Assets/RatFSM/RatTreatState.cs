using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RatTreatState : RatBaseState
{

    [SerializeField] private Texture2D treathand;
    
    private Vector3 mousePos;
    public float moveSpeed = 1.5f;
    public override void EnterState(RatFSM rat)
    {
        Debug.Log("Rat want Treat");
    }

    public override void UpdateState(RatFSM rat)
    {
        if(rat.manager.heldTreat == true)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            if (mousePos.x > rat.transform.position.x)
            {
                rat.ratSprite.flipX = true;
            }
            else
            {
                rat.ratSprite.flipX = false;
            }
            rat.transform.position = Vector2.MoveTowards(rat.transform.position, mousePos, moveSpeed);
        }
        else
        {
            //switch state to roam
            rat.SwitchState(rat.roamState);
        }
    }
}
