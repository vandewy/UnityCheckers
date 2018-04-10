using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule_Enforcer : MonoBehaviour {

    public int[,] moves;
    private Dictionary<int, List<int>> dict_moves;

    void Start()
	{
		moves = new int[33, 33];

		int right_edge = 4;
		int left_edge = 5;
		//dictionary used to fill moves[,] with valid moves
		dict_moves = new Dictionary<int, List<int>> ();

		for (int i = 1; i < 29; i++) {
			if (i == right_edge) {
				dict_moves.Add (i, new List<int> { i + 4, 0});
				right_edge += 4;
			} else if (i == left_edge) {
				dict_moves.Add (i, new List<int> { i + 4, 0});
				left_edge += 4;
			} else {
				dict_moves.Add (i, new List<int> { i + 4, i + 5 });
			}
		}
			
		int x = 1;
		//setup matrix rows and columns
		for (int i = 1; i < 33; i++) {
			moves[0,i] = x;
			moves[i,0]= x;
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
