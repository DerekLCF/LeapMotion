using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public enum GameState { S1, S2, S3 }
    public TextMeshProUGUI TestText;
    public int count;
    GameState _GameState;

    public GameObject Slot;
    private void Start()
    {
        Slot.SetActive(false);
        _GameState = (GameState)0;
    }

    void Update()
    {

        switch (_GameState)
        {
            case GameState.S1:
                TestText.text = "S1";
                break;
            case GameState.S2:
                TestText.text = "S2";
                Slot.SetActive(true);
                break;
            case GameState.S3:
                TestText.text = "S3";
                break;
        }
    }



    public void Green()
    {
        count += 1;
        _GameState = (GameState)count;
    }

    public void Red()
    {

    }
}
