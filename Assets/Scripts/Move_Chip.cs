using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Chip : MonoBehaviour {

    public bool over_square;
    public string square_touching_name;
    public GameObject origin;

	// Use this for initialization
	void Start () {
        over_square = true;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseUp()
    {
        gameObject.transform.localScale -= new Vector3(0.04f, 0.04f);
        if(over_square == true)
        {
            GameObject square = GameObject.Find(square_touching_name);
            if (square.GetComponent<Square_Script>().occupied == false)
            {
                gameObject.transform.position = new Vector3(square.transform.position.x + 2f, square.transform.position.y - .5f, square.transform.position.z);
                origin = square;
                //square.GetComponent<Square_Script>().occupied = true;
            }else
            {
                gameObject.transform.position = new Vector3(origin.transform.position.x + 2f, origin.transform.position.y - .5f, origin.transform.position.z);
            }
        }
    }

    void OnMouseDown()
    {
        gameObject.transform.localScale += new Vector3(0.04f, 0.04f);
    }


    void OnClick()
    {
        print("Clicked Chip");
    }

    private void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        gameObject.transform.position = new Vector3(pos_move.x, pos_move.y, pos_move.z);
    }
}
