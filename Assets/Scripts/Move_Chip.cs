using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Chip : MonoBehaviour {

    public bool over_square;
    public string square_touching_name;
    public GameObject origin;
    private Rule_Enforcer enforce;

    // Use this for initialization
    void Start () {
        over_square = true;
        enforce = GetComponent<Rule_Enforcer>();
        

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
            int modulo_check = origin.GetComponent<Square_Script>().row_number;
            if (modulo_check % 2 == 0)
                modulo_check = 1;
            else
                modulo_check = 0;


            if (square.GetComponent<Square_Script>().occupied == false && square.GetComponent<Square_Script>().square_number > 
                origin.GetComponent<Square_Script>().square_number)
                {
                gameObject.transform.position = new Vector3(square.transform.position.x + 1.8f, square.transform.position.y - .5f, -1f);
                origin.GetComponent<Square_Script>().occupied = false;
                origin = square;
                origin.GetComponent<Square_Script>().occupied = true;
                //square.GetComponent<Square_Script>().occupied = true;
            }else
            {
                //return to original position
                gameObject.transform.position = new Vector3(origin.transform.position.x + 2f, origin.transform.position.y - .5f, -1f);
            }
        }else
        {
            //return to original postion
            gameObject.transform.position = new Vector3(origin.transform.position.x + 2f, origin.transform.position.y - .5f, -1f);
        }
    }

    void OnMouseDown()
    {
        print("mouse down");
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
