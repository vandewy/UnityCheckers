using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_Enforcer : MonoBehaviour {

    public int[,] moves;
	public int[,] jump_moves;
    private Dictionary<int, List<int>> dict_moves;
	private Dictionary<int, List<int>> dict_jump_moves;

    void Start()
	{
		moves = new int[33, 33];
		jump_moves = new int[33, 33];

		int right_edge = 4;
		int left_edge = 5;
        int row = 1; //if row is one then non-edge squares can move +4 or +5
        //if row is 0 then non-edge squares can move +3 or +5, alternates 1,0,1,0,1,0,1,0 for entire board
		//dictionary used to fill moves[,] with valid moves
        //Every 4th square row variable is changed for current movements
		dict_moves = new Dictionary<int, List<int>> ();
		dict_jump_moves = new Dictionary<int, List<int>> ();

		for (int i = 1; i < 29; i++) {
			if (i == right_edge) {
				dict_moves.Add (i, new List<int> { i + 4, 0});
				right_edge += 8;
                if (i % 4 == 0 || i == 4)
                {
                    if (row == 1)
                        row = 0;
                    else if (row == 0)
                        row = 1;
                }
            } else if (i == left_edge) {
				dict_moves.Add (i, new List<int> { i + 4, 0});
				left_edge += 8;
                if (i % 4 == 0 || i == 4)
                {
                    if (row == 1)
                        row = 0;
                    else if (row == 0)
                        row = 1;
                }
            } else if(row == 1) {
				dict_moves.Add (i, new List<int> { i + 4, i + 5 });
                if(i % 4 == 0 || i == 4)
                {
                    row = 0;
                }
			}else if(row == 0) {
                dict_moves.Add(i, new List<int> { i + 3, i + 4 });
                if(i % 4 == 0)
                {
                    row = 1;
                }
            }
		}

		//reset logic flags
		right_edge = 4;
		left_edge = 5;
		row = 1;
		//setup possible jump moves
		for (int i = 1; i < 24; i++) {
			if (i == right_edge) {
				dict_jump_moves.Add (i, new List<int> { i + 7, 0});
				right_edge += 4;
				if (i % 4 == 0 || i == 4)
				{
					if (row == 1)
						row = 0;
					else if (row == 0)
						row = 1;
				}
			} else if (i == left_edge || i == 1) {
				dict_jump_moves.Add (i, new List<int> { i + 9, 0});
				if (i != 1) {
					left_edge += 4;
					if (i % 4 == 0 || i == 4) {
						if (row == 1)
							row = 0;
						else if (row == 0)
							row = 1;
					}
				}
			} else if(row == 1 ) {
				dict_jump_moves.Add (i, new List<int> { i + 7, i + 9 });
				if(i % 4 == 0 || i == 4)
				{
					row = 0;
				}
			}else if(row == 0) {
				dict_jump_moves.Add(i, new List<int> { i + 7, i + 9 });
				if(i % 4 == 0)
				{
					row = 1;
				}
			}
			print (i + "  " + dict_jump_moves [i] [0] + " : " + dict_jump_moves [i] [1]);
		}
			
		int x = 1;
		//setup matrix rows and columns
		for (int i = 1; i < 33; i++) {
			moves[0,i] = x;
			moves[i,0]= x;

			jump_moves [0, i] = x;
			jump_moves [i, 0] = x;

			x += 1;
		}
			
		//build legal move matrix
		foreach (var item in dict_moves) {
			if (item.Value [1] == 0) {
				moves[item.Key, dict_moves[item.Key][0]] = 1;
				moves [dict_moves [item.Key][0], item.Key] = 1;
			} else if (item.Value [1] > 0) {
				moves [item.Key, dict_moves [item.Key] [0]] = 1;
				moves [dict_moves [item.Key] [0], item.Key] = 1;
				moves [item.Key, dict_moves [item.Key] [1]] = 1;
				moves [dict_moves [item.Key] [1], item.Key] = 1;
			}
		}
	}
}
