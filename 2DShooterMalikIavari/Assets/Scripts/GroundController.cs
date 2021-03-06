﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Source file name: GroundController.cs
    Author's name: Malik Iavari - 101043865
    Last modified by: Malik Iavari
    Date last modified: Oct 19, 2017
    Program description: This script is basically controls the 
                        ground object. It is moving to the 
                        left to make a sense of moving our character.
                        When the ground position is less than the 
                        left X coordinate, then reset the position of the
                        ground object.
    Revision history: Y coordinate in ResetPosition method was updated
*/

public class GroundController : MonoBehaviour {

    #region
    // fields accessible from unity
    [SerializeField]
    private float speed = .1f; // ground object will move to the left with that speed
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
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>(); // getting transform component for ground object
        _currentPos = _transform.position; // current position of the ground object
        ResetPosition(); // reset ground object to the starting position
    }

    // Update is called once per frame
    void Update()
    {
        _currentPos = _transform.position;
        _currentPos -= new Vector2(speed, 0); // moving object to the left 

        if (_currentPos.x < leftX) // if current position is less than left position of X, then reset position
            ResetPosition(); // reset ground object to the starting position

        _transform.position = _currentPos; // apply changes 
    }

    // Called when the reset for background object is needed
    private void ResetPosition()
    {
        _currentPos = new Vector2(rightX, -5.2f);
    }
}
