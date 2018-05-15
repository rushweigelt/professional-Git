using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textControl : MonoBehaviour {

    public Text battleLog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void textUpdate(string newText)
    {
        string oldText = battleLog.text;
        battleLog.text = "-"+newText + "\n" + oldText;
    }
}
