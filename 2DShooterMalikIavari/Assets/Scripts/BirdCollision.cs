using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCollision : MonoBehaviour {

    #region
    // fields only accessible in this class
    private AudioSource _coinSound; // sound for coin
    private AudioSource _wallSound; // sound for wall and ground
    #endregion

	// Use this for initialization
	void Start () {
        AudioSource[] audios = gameObject.GetComponents<AudioSource>(); // getting AudioSources from Unity for coin and wall
        _coinSound = audios[0];
        _wallSound = audios[1];
	}
	
    // Called when the bird object collides with the wall and ground
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("wall"))
        {
            StartCoroutine("Blink");
            gameObject.GetComponent<Transform>().position = 
                new Vector2(-7, 1.5f); // reset the position of the bird to the starting position

            // play music for wall collision
            if (_wallSound != null)
            {
                _wallSound.Play();
            }

            GameData.Instance.Life -= 1; // decrease the amount of lifes
        }
    }

    // Called when bird collides with coin
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("coin"))
        {
            // play music for coin collision
            if (_coinSound != null)
            {
                _coinSound.Play();
            }
            GameData.Instance.Score += 100; // inrease the amount of score by 100

            other.gameObject.GetComponent<CoinController>().ResetPosition(); // reset position of the coin
        }
    }

    // Called for blinking the bird when the collision with wall occurs 
    private IEnumerator Blink()
    {
        Color c;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        for (int i = 0; i < 3; i++)
        {
            for (float f = 1f; f >= 0; f -= 0.1f)
            {
                c = renderer.material.color;
                c.a = f;
                renderer.material.color = c;
                yield return null;
            }
            for (float f = 0; f <= 1f; f += 0.1f)
            {
                c = renderer.material.color;
                c.a = f;
                renderer.material.color = c;
                yield return null;
            }
        }
    }
}
