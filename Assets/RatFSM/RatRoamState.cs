using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatRoamState : RatBaseState
{
    private float x;
    private float y;
    private float minX = 222;
    private float maxY = 1357;
    private float maxX = 2339;
    private float minY = 428;

    private IEnumerator wait;

    private bool reached;

    private Vector3 mousePos;
    [SerializeField] private Animation walk;

    public override void EnterState(RatFSM rat)
    {
        x = Random.Range(minX, maxX);
        y = Random.Range(minY, maxY);

        wait = WaitToMove(rat);
        reached = true;
    }

    public override void UpdateState(RatFSM rat)
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (rat.manager.heldTreat == true)
        {
            rat.SwitchState(rat.treatState);
        }else if(rat.manager.heldTreat == false && mousePos == rat.transform.position)
        {
            rat.SwitchState(rat.tickleState);
        }

        if(rat.hunger > 50 && rat.thirst > 50)
        {
            if(rat.happiness > 50)
            {
                x = Random.Range(minX, maxX);
                y = Random.Range(minY, maxY);
                Vector2 pos = new Vector2(x, y);

                reached = false;
                while (reached == false)
                {
                    if(rat.transform.position.x == x && rat.transform.position.y == y)
                    {
                        reached = true;
                    }

                    if (pos.x > rat.transform.position.x)
                    {
                        rat.ratSprite.flipX = true;
                    }
                    else
                    {
                        rat.ratSprite.flipX = false;
                    }
                    rat.transform.position = Vector2.MoveTowards(rat.transform.position, pos, 0.5f);
                }
                
                
            }
            else
            {
                rat.SwitchState(rat.wantState);
            }
            
        }
        else
        {
            if (rat.hunger <= rat.thirst)
            {
                rat.SwitchState(rat.hungryState);
            }
            else
            {
                rat.SwitchState(rat.thirstyState);
            }
        }
    }

    private IEnumerator WaitToMove(RatFSM rat)
    {
        
        

        int secs = Random.Range(3, 10);
        yield return new WaitForSeconds(secs);
    }
}
