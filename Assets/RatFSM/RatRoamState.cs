using System.Collections;
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
    private int timer = 0;
    private bool start = false;
    private Vector2 pos;

    private Vector3 mousePos;
    [SerializeField] private Animation walk;

    public override void EnterState(RatFSM rat)
    {
        if (rat.manager.heldTreat == true)
        {
            Debug.LogWarning("treats?");
            rat.SwitchState(rat.treatState);
        }

        //Debug.Log("plop");
        if (start == false) {
            x = Random.Range(minX, maxX);
            y = Random.Range(minY, maxY);
            pos = new Vector2(x, y);
            start = true;
            reached = false;
        }
        if (timer > 5)
        {
            rat.transform.position = Vector2.MoveTowards(rat.transform.position, pos, 12f);
            //Debug.Log("timer complete");
            timer = 0;
            if (rat.transform.position.x == x && rat.transform.position.y == y)
            {
                reached = true;
                start = false;
                rat.happiness--;
                //Debug.Log("MADE IT TO MY FINAL DESTINATION!");
            }
        }
        if (reached == false)
        { 
            if (pos.x > rat.transform.position.x)
            {
                rat.ratSprite.flipX = true;
            }
            else
            {
                rat.ratSprite.flipX = false;
            }
        }
        timer++;
    }

    public override void UpdateState(RatFSM rat)
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (rat.manager.heldTreat == true)
        {
            rat.SwitchState(rat.treatState);
        }

        if(rat.hunger <= 50 || rat.thirst <= 50)
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
        
        //This will be the default state if none of the conditions above work
        rat.SwitchState(rat.roamState);
    }

    private IEnumerator WaitToMove()
    {

        //Debug.Log("I was called!");

        int secs = Random.Range(3, 10);
        yield return new WaitForSeconds(secs);
    }
}
