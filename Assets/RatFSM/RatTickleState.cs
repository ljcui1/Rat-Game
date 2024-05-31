using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatTickleState : RatBaseState
{
    private Vector3 mousePos;
    private int height;
    private int width;
    private Vector2 pos;
    private int time;
    public override void EnterState(RatFSM rat)
    {
        Debug.Log("tickle tickle");
        height = 48;
        width = 144;
        pos = new Vector2(width, height);
        time = 0;
    }

    public override void UpdateState(RatFSM rat)
    {
        time++;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if ((mousePos.x >= rat.transform.position.x - 10 || mousePos.x <= rat.transform.position.x + 10) && ((mousePos.y >= rat.transform.position.y + 10 || mousePos.y <= rat.transform.position.y - 10))){
            if(time % 10 == 0)
            {
                rat.happiness++;
            }
            
            
        }
        else
        {
            rat.SwitchState(rat.roamState);
        }

    }
}
