using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RatThirstyState : RatBaseState
{
    float time_passed = 0;
    bool finished = false;
    bool start = false;
    public override void EnterState(RatFSM rat)
    {
        if (start == false)
        {
            //pos = position of the water
            //rat.transform.position = Vector2.MoveTowards(rat.transform.position, pos, 5f);
            //Rotate rat to drink
        }
        time_passed += Time.deltaTime;
        if (time_passed >= 10)
        {
            //Rotate rat back
            finished = true;
        }
    }

    public override void UpdateState(RatFSM rat)
    {
        if (finished == false)
        {
            rat.SwitchState(rat.thirstyState);
        }

        if (rat.manager.heldTreat == true)
        {
            rat.SwitchState(rat.treatState);
        }

        if (rat.hunger <= 50)
        {
            rat.SwitchState(rat.hungryState);
        }

        //The default
        rat.SwitchState(rat.roamState);
    }
}
