using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
    Source file name: UIController.cs
    Author's name: Malik Iavari - 101043865
    Last modified by: Malik Iavari
    Date last modified: Oct 19, 2017
    Program description: This script is basically controls UI of 
                        the game. On the start up some labels
                        are shown to user, some of them are hidden.
                        When the game over action occurs, it changes
                        the state of the labels and button.
    Revision history: ResetBtnClick was added for restarting the game
*/

public class UIController : MonoBehaviour {

    #region
    // fields accessible from unity
    [SerializeField]
    Text scoreLabel; // label for displaying the score
    [SerializeField]
    Text lifeLabel; // label for displaying the life counter
    [SerializeField]
    Text gameOverLabel; // label for displaying the "Game Over!" text
    [SerializeField]
    Text highScoreLabel; // label for displaying the high score
    [SerializeField]
    Button restartBtn; // button for starting a new game
    [SerializeField]
    GameObject bird; // bird object 
    [SerializeField]
    GameObject coin; // coin object
    #endregion

    // Use this for initialization
    void Start () {
        GameData.Instance.UICtrl = this; // initialize our static variable
        ShowStartScreen(); // show start screen on start up
	}
	
    // Called when the game starts
    private void ShowStartScreen(){
        GameData.Instance.Score = 0;
        GameData.Instance.Life = 3;

        gameOverLabel.gameObject.SetActive(false);
        highScoreLabel.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);

        lifeLabel.gameObject.SetActive(true);
        scoreLabel.gameObject.SetActive(true);
    }

    // Called when the game is over
    public void ShowGameOver(){
        gameOverLabel.gameObject.SetActive(true);
        highScoreLabel.text = "High Score: " + GameData.Instance.Score;
        highScoreLabel.gameObject.SetActive(true);
        restartBtn.gameObject.SetActive(true);

        lifeLabel.gameObject.SetActive(false);
        scoreLabel.gameObject.SetActive(false);

        bird.SetActive(false);
        coin.SetActive(false);
        gameObject.GetComponent<AudioSource>().Pause();
    }

    // Called when UI update is needed
    public void UpdateUI()
    {
        scoreLabel.text = "Score: " + GameData.Instance.Score;
        lifeLabel.text = "Life: " + GameData.Instance.Life;
    }

    // Start new game
    public void ResetBtnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
