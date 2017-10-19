using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Source file name: WallController.cs
    Author's name: Malik Iavari - 101043865
    Last modified by: Malik Iavari
    Date last modified: Oct 19, 2017
    Program description: This script is basically controls the 
                        wall objects. It is moving them to the 
                        left to make a sense of moving our character.
                        When the wall position is less than the 
                        left X coordinate, then reset the position of the
                        wall object to the random position.
    Revision history: ChangeDirection was added to switch direction of the wall
*/

public class WallController : MonoBehaviour {

    #region
    // fields accessible from unity
    [SerializeField]
    private float speed = .1f; // wall object will move to the left with that speed
    [SerializeField]
    private GameObject point; // point object when the wall appears
    [SerializeField]
    private float changeDirectionTime = 2f; // time for switching direction of the wall
    #endregion

    #region
    // fields only accessible in this class
    private Transform _transform;
    private Transform _transformPoint; 
    private Vector2 _currentPos;
    private float dy;
    private string pointName;
    #endregion

	// Use this for initialization
	void Start () {
        _transformPoint = point.GetComponent<Transform>();
        pointName = point.name;
        _transform = gameObject.GetComponent<Transform>();
        gameObject.GetComponent<Rigidbody2D>().velocity =
                      Vector2.up * 1;

        // Repeat ChangeDirection function every changeDirectionTime  
        InvokeRepeating("ChangeDirection", 0, changeDirectionTime);
	}

    // Update is called once per frame
    void Update(){
        _currentPos = _transform.position;
        _currentPos -= new Vector2(speed, 0); // moving object to the left 
        _transform.position = _currentPos; //apply changes

        if (_transform.position.x < -13){ // if current position is less than left position of X, then reset position
            ResetPosition(); // reset wall object to the starting position
        }
    }

    // Called when switching direction is needed
    private void ChangeDirection(){
        gameObject.GetComponent<Rigidbody2D>().velocity *= -1;
    }

    // Called when the reset for wall object is needed
    public void ResetPosition()
    {
        float x = _transformPoint.position.x;
        if (pointName.Equals("point1"))
        {
            dy = Random.Range(-1f, 3f);
        }
        else if (pointName.Equals("point2"))
        {
            dy = Random.Range(-2f, 2f);
        }
        _transform.position = 
            new Vector2(x, _transformPoint.position.y + dy);
    }
}
