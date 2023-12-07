using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : PickUpBehaviour
{
    GameplayManager gameplayManager;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
        gameplayManager.TotalKeys++;
    }
    protected override void OnPickUp()
    {
        gameplayManager.FoundKeys++;
    }
}
