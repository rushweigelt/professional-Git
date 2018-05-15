using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace map_v08
{
    public class ClickableTile_v3 : MonoBehaviour
    {
        public map_v8 map;
        public UnitMovement_v1 move;
        public GameObject SelectedUnit;
        public int tileX;
        public int tileY;
        public float xLoc;
        public float yLoc;

        // Use this for initialization
        void Start()
        {
           
        }
        void OnMouseUp()
        {
            //UnitMovement_v1 move = SelectedUnit.AddComponent<UnitMovement_v1>();
            Debug.Log("Click!");
            move.MoveUnitTo(xLoc, yLoc);
        }
    }
}
