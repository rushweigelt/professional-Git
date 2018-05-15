using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace map_v08
{
    public class UnitMovement_v1 : MonoBehaviour
    {

        public map_v8 map;
        public ClickableTile_v3 click;
        private float charHeight;
        public GameObject SelectedUnit;

        // Use this for initialization
        void Start()
        {
            
        }
        public void MoveUnitTo(float x, float y)
        {
            charHeight = .5f;
            SelectedUnit.transform.position = new Vector3(x, charHeight, y);
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}