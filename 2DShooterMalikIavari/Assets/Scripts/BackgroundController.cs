using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Source file name: BackgroundController.cs
    Author's name: Malik Iavari - 101043865
    Last modified by: Malik Iavari
    Date last modified: Oct 19, 2017
    Program description: This script is basically controls the 
                        background object. It is moving to the 
                        left to make a sense of moving our character.
                        When the background position is less than the 
                        left X coordinate, then reset the position of the
                        background object.
    Revision history: Updated the part of the code where the position is reseted correctly
*/

public class BackgroundController : MonoBehaviour {

    #region
    // fields accessible from unity
    [SerializeField]
    private float speed = .1f; // background object will move to the left with that speed
    [SerializeField]
    private float leftX; // left position of X 
    [SerializeField]
    private float rightX; // right position of X 
    #endregion

    #region
    // fields only accessible in this class
    private Transform _transform;
    private Vector2 _currentPos;
    #endregion

    // Use this for initialization
    void Start () {
        _transform = gameObject.GetComponent<Transform>(); // getting transform component for background object
        _currentPos = _transform.position; // current position of the background object
        ResetPosition(); // reset background object to the starting position
	}
	
	// Update is called once per frame
	void Update () {
        _currentPos = _transform.position;
        _currentPos -= new Vector2(speed, 0); // moving object to the left 

        if (_currentPos.x < leftX) // if current position is less than left position of X, then reset position
            ResetPosition(); // reset background object to the starting position

        _transform.position = _currentPos; // apply changes 
	}

    // Called when the reset for background object is needed
    private void ResetPosition()
    {
        _currentPos = new Vector2(rightX, 0);
    }
}
