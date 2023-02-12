using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace TileMap
{
    public class TileView: MonoBehaviour
    {
        public bool isClick;

        private void OnMouseDown()
        {
            print("Clicked");
            isClick = true;
        }
    }
}