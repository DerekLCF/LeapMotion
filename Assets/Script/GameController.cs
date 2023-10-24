using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    //abcdefghijklmnopqrstuvwxyz,./1234567890_+:"
    public enum GameState { S0,S1, S2, S3,S4,S5,S6,S7,S8,S9,S10,S11,S12 }
    [Header("----------------------Status----------------------")]
    public int count;
    GameState _GameState;
     bool  Placed=false;
    public GameObject Anchorable_Object_Magenta;
    public GameObject Slot;
    public float BigWarning_BackMenuTime;
    public float PlayTime;
    public float PressCount;
    public float PressCountWait;
    public bool CanPress;
    [Header("----------------------UI----------------------")]
    public TextMeshProUGUI TestText;
    public string[] Machine_String;


    public GameObject GameHint_Gameobject;
    public string[] GameHint_String;

    public TextMeshProUGUI GameHint_Text;

    public GameObject GameTimer_Gameobject;
    public TextMeshProUGUI GameTimer_Text;

    public GameObject BigWarning_Gameobject;
    public TextMeshProUGUI BigWarning_Title;
    public TextMeshProUGUI BigWarning_Note;
    public TextMeshProUGUI BigWarning_Timer;
    public string[] BigWarning_Note_String;

    public GameObject SmallWarning_Gameobject;
    public TextMeshProUGUI SmallWarning_Text;





    private void Start()
    {
        Slot.SetActive(false);
        _GameState = (GameState)0;

        BigWarning_Gameobject.SetActive(false);
        SmallWarning_Gameobject.SetActive(false);
        TestText.text = Machine_String[count];
        GameHint_Text.text = GameHint_String[count];


        //Anchorable_Object_Magenta.GetComponent<Leap.Unity.Interaction.AnchorableBehaviour>().enabled = false; 
    }

    void Update()
    {
        if (count >1) {
            PlayTime += Time.deltaTime;
            GameHint_Text.text = PlayTime.ToString("00:00");
        }
        if (CanPress == false && PressCount > 0)
        {
            PressCount -= Time.deltaTime;

        }
        else {
            CanPress = true;
            PressCount = PressCountWait;
        }
        switch (_GameState)
        {
            case GameState.S0:
                ChangeText(0,0);
                break;
            case GameState.S1:
                ChangeText(0, 1);
                break;
            case GameState.S2:
                ChangeText(1, 2);
                Slot.SetActive(true);
                break;
            case GameState.S3:
                ChangeText(0, 3);
                break;
            case GameState.S4:
                ChangeText(0, 4);
                break;
            case GameState.S5:
                ChangeText(0, 5);
                break;
            case GameState.S6:
                ChangeText(0, 6);
                break;
            case GameState.S7:
                ChangeText(0, 7);
                break;
            case GameState.S8:
                ChangeText(0, 8);
                break;
            case GameState.S9:
                ChangeText(0, 9);
                break;
            case GameState.S10:
                ChangeText(0, 10);
                break;
            case GameState.S11:
                ChangeText(0, 11);
                break;
            case GameState.S12:
                ChangeText(0, 12);
                break;
        }
    }

    public void ChangeText(int x, int y)
    {
        TestText.text = Machine_String[x];
        GameHint_Text.text = GameHint_String[y];
    }

    public void WhileAttached()
    {
        Debug.Log("WhileAttached");
        Anchorable_Object_Magenta.SetActive(false);
        Placed = true;
    }

    public void Green()
    {

        if (CanPress) {
            Debug.Log("Touch Green");
            count += 1;
            TestText.text = Machine_String[count];
            GameHint_Text.text = GameHint_String[count];
            _GameState = (GameState)count;
            CanPress = false;
        }

    }

    public void Red()
    {
        Debug.Log("Touch Red");
    }

    public void Up()
    {
        Debug.Log("Touch Up");
    }
    public void Down()
    {
        Debug.Log("Touch Down");
    }
    public void Enter()
    {
        Debug.Log("Touch Enter");
    }
    #region Win/Lose
    public void Win() {
        CallBigWarning("Win","");
        Invoke(nameof(CallBigWarning_Exit), BigWarning_BackMenuTime);
    }

    public void Lose()
    {
        CallBigWarning("Lose", "");
        Invoke(nameof(CallBigWarning_Exit), BigWarning_BackMenuTime);
    }
    #endregion

    #region Warning
    public void CallBigWarning(string Title_Text, string Note_Text)
    {
        GameHint_Gameobject.SetActive(false);
        GameTimer_Gameobject.SetActive(false);
        BigWarning_Title.text = Title_Text;
        BigWarning_Note.text = Note_Text;
        BigWarning_Timer.text = BigWarning_BackMenuTime+ "s Back Menu...";
        BigWarning_Gameobject.SetActive(true);
    }

    public void CallBigWarning_Exit()
    {
        SceneManager.LoadScene(0);
    }


    public void CallSmallWarning(string Text)
    {
        SmallWarning_Gameobject.SetActive(false);
        SmallWarning_Text.text = Text;
        SmallWarning_Gameobject.SetActive(true);
    }
    #endregion
}
