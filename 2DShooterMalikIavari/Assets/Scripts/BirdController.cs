using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Source file name: BirdController.cs
    Author's name: Malik Iavari
    Last modified by: Malik Iavari
    Date last modified: Oct 18, 2017
    Program description: This script is basically controls the 
                        bird object. It is moving down by default
                        but moving up when the player presses
                        either up arrow or "W" key.
    Revision history:
*/

public class BirdController : MonoBehaviour {

    #region
    // fields accessible from unity
    [SerializeField]
    private float topY; // top position of Y 
    [SerializeField]
    private float downY; // down position of Y 
    [SerializeField]
    private float force = 1f; // the force the bird will be moved up
    #endregion

    #region
    // fields only accessible in this class
    private Transform _transform;
    private Vector2 _currentPos;
    #endregion

    // Use this for initialization
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>(); // getting transform component for bird object
        _currentPos = _transform.position; // current position of the bird object
    }

    // Update is called once per frame
    void Update()
    {
        _currentPos = _transform.position;
        // getting vertical user input
        float userInputVert = Input.GetAxis("Vertical");

        // if up arrow is pressed, move the bird up
        if (userInputVert > 0){
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
        }

        ControlBoundaries();
        _transform.position = _currentPos; // apply changes
    }

    // Called each frame to check that the bird doesn't fly over the boundaries
    private void ControlBoundaries()
    {
        if (_currentPos.y < downY)
            _currentPos.y = downY;

        if (_currentPos.y > topY)
            _currentPos.y = topY;
    }
}
