using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameController : MonoBehaviour
{

    public enum GameState { S1, S2, S3,S4,S5,S6,S7,S8 }
    [Header("----------------------Status----------------------")]
    public int count;
    GameState _GameState;
     bool  Placed=false;
    public GameObject Anchorable_Object_Magenta;
    public GameObject Slot;


    [Header("----------------------UI----------------------")]
    public TextMeshProUGUI TestText;

    public GameObject BigWarning_Gameobject;
    public TextMeshProUGUI BigWarning_Text;
    public string CallBigWarning_Enter_Function;

    public GameObject SmallWarning_Gameobject;
    public TextMeshProUGUI SmallWarning_Text;





    private void Start()
    {
        Slot.SetActive(false);
        _GameState = (GameState)0;
        //Anchorable_Object_Magenta.GetComponent<Leap.Unity.Interaction.AnchorableBehaviour>().enabled = false; 
    }

    void Update()
    {

        switch (_GameState)
        {
            case GameState.S1:
                TestText.text = "按綠色鍵開始執行";
                break;
            case GameState.S2:
                TestText.text = "裝置管組";
                Slot.SetActive(true);
                break;
            case GameState.S3:
                TestText.text = "機器自我測試";
                break;
            case GameState.S4:
                TestText.text = "連接透式液袋打開管夾";
                break;
            case GameState.S5:
                TestText.text = "排氣";
                break;
            case GameState.S6:
                TestText.text = "連接你自己\n檢查病人端管路";
                break;
            case GameState.S7:
                TestText.text = "確認0週期引流量";
                break;
            case GameState.S8:
                TestText.text = "0週期引流";
                break;
        }
    }

    public void WhileAttached()
    {
        Debug.Log("WhileAttached");
        Anchorable_Object_Magenta.SetActive(false);
        Placed = true;
    }

    public void Green()
    {
        Debug.Log("Touch Green");
        count += 1;
        _GameState = (GameState)count;
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
    #region Warning
    public void CallBigWarning(string Text, string function)
    {
        BigWarning_Text.text = Text;
        CallBigWarning_Enter_Function = function;
        BigWarning_Gameobject.SetActive(true);
    }

    public void CallBigWarning_Enter()
    {
        Invoke(CallBigWarning_Enter_Function, 0f);
    }


    public void CallSmallWarning(string Text)
    {
        SmallWarning_Gameobject.SetActive(false);
        SmallWarning_Text.text = Text;
        SmallWarning_Gameobject.SetActive(true);
    }
    #endregion
}
