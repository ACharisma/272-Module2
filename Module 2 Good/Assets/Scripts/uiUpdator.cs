using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class uiUpdator : MonoBehaviour {
	public Text score;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		score.text = StatsManager.collectable.ToString ();

	}
}
