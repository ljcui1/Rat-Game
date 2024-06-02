using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessCounter : MonoBehaviour
{
    public RatFSM fsm;
    // Update is called once per frame
    void Update()
    {
        Slider slider = GetComponent<Slider>();
        slider.value = fsm.happiness;
        if (fsm.happiness > 100)
        {
            fsm.happiness = 100;
        }
        if(fsm.happiness < 0)
        {
            fsm.happiness = 0;
        }
    }
}
