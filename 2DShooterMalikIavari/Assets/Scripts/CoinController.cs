using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour {

    #region
    // fields accessible from unity
    [SerializeField]
    private float speed = .1f; // coin object will move to the left with that speed
    [SerializeField]
    private float topY; // top position of Y 
    [SerializeField]
    private float downY; // down position of Y 
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
        _transform = gameObject.GetComponent<Transform>(); // getting transform component for coin object
        _currentPos = _transform.position; // current position of the coin object
        ResetPosition(); // reset coin object to the starting position
    }

    // Update is called once per frame
    void Update()
    {
        _currentPos = _transform.position;
        _currentPos -= new Vector2(speed, 0); // moving object to the left 
        _transform.position = _currentPos; // apply changes

        if (_currentPos.x < leftX) // if current position is less than left position of X, then reset position
            ResetPosition(); // reset coin object to the starting position
    }

    // Called when the reset for coin object is needed
    public void ResetPosition()
    {
        float y = Random.Range(topY, downY);
        float dx = Random.Range(0, 1);
        _transform.position = new Vector2(rightX - dx, y);
    }
}
