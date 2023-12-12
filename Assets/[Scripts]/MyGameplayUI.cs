using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyGameplayUI : MonoBehaviour
{
    public TextMeshProUGUI KeysState;
    public TextMeshProUGUI DiamondState;
    public TextMeshProUGUI EnemiesState;

    public GameObject LifeState;
    GameplayManager gameplayManager;


    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }


    private void Update()
    {
        KeysState.text = string.Format("{0}/{1}", gameplayManager.FoundKeys, gameplayManager.TotalKeys);
        DiamondState.text = string.Format("x{0}", gameplayManager.FoundDiamonds);
        EnemiesState.text = string.Format("x{0}", gameplayManager.EnemiesDefeated);

        int count = 0;
        int lives = gameplayManager.playerLives;

        foreach (Transform child in LifeState.transform)
        {
            child.gameObject.SetActive(count < lives);
            count++;
        }

    }

}
