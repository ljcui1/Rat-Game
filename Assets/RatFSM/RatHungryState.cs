using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatHungryState : RatBaseState
{
    bool start = false;
    bool finished = false;
    float time_passed = 0;
    Vector2 foodPosition;
    public override void EnterState(RatFSM rat)
    {
        if (start == false)
        {
            GameObject temp = GameObject.Find("bottle_0");
            Transform foodTransform = temp.GetComponent<Transform>();
            foodPosition = new Vector2(foodTransform.position.x, foodTransform.position.y);
            rat.transform.position = Vector2.MoveTowards(rat.transform.position, foodPosition, 5f);
            //start the drinking animation
            start = true;
            finished = false;
        }
        time_passed += Time.deltaTime;
        if (time_passed >= 10)
        {
            //stop the drinking animation
            rat.hunger += 50;
            finished = true;
            start = false;
        }
    }

    public override void UpdateState(RatFSM rat)
    {
        if (finished == false)
        {
            rat.SwitchState(rat.hungryState);
        }

        if (rat.manager.heldTreat == true)
        {
            rat.SwitchState(rat.treatState);
        }

        if (rat.thirst <= 50)
        {
            rat.SwitchState(rat.thirstyState);
        }

        //The default
        rat.SwitchState(rat.roamState);
    }
}
