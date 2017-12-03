using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private Vector2 touchDown = new Vector2();
    private Vector2 touchUp = new Vector2();
    private bool touched = false;

	void Update () {
        bool lastFrameTouched = touched;

		if (Input.GetMouseButtonDown(0))
        {
            touchDown = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touched = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            touchUp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touched = false;
        }

        if (lastFrameTouched && !touched)
        {
            Shoot();
        } else if (touched)
        {
            Vector2 currentTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameController.DrawForceVectors(-(currentTouch - touchDown) / 2);
        }
	}

    private void Shoot()
    {
        Vector2 shootVector = touchUp - touchDown;
        GameController.Shoot(-shootVector);
    }
}
