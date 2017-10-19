using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Source file name: GameData.cs
    Author's name: Malik Iavari - 101043865
    Last modified by: Malik Iavari
    Date last modified: Oct 19, 2017
    Program description: This class is for storing the player's
                        results. We use a singleton pattern here
                        in order to have only one instance of that class
                        which provides us consistency of the data.
    Revision history: Updated Life property
*/

public class GameData {

    #region
    // fields only accessible in this class
    private static GameData _instance; 
    private UIController uiCtrl;
    private int _score = 0;
    private int _life = 3;
    #endregion

    #region
    // properties for private variables
    public static GameData Instance{
        get{
            if (_instance == null)
                _instance = new GameData();
            return _instance;
        }
    }

    public UIController UICtrl{
        get{
            return uiCtrl;
        }

        set{
            uiCtrl = value;
        }
    }

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            uiCtrl.UpdateUI();
        }
    }

    public int Life
    {
        get { return _life; }
        set
        {
            _life = value;

            if (_life <= 0)
            {
                uiCtrl.ShowGameOver();
            }
            else
            {
                uiCtrl.UpdateUI();
            }

        }
    }
    #endregion

    private GameData(){}
}
