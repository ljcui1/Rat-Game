using System.Collections;
using System.Collections.Generic;
using RenownedGames.AITree;
using UnityEngine;

public class Rat : MonoBehaviour
{
    [SerializeField] private UIManager manager;

    [SerializeField] private Cursor cursor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if(manager.heldTreat == true)
        {
            manager.dropTreat();
        }
        
    }
}
