using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class mouseOverTile : MonoBehaviour {

    public Camera camera;
    public Color highlightColor;
    Color normalColor;

	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        //Collider collider = collider.Raycast(ray, out hit, 100.0);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Spectacular");
            rend.material.SetColor("_SpecColor", highlightColor);

        }
        else
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Spectacular");
            rend.material.SetColor("_SpecColor", normalColor);
        }

    }
}
*/