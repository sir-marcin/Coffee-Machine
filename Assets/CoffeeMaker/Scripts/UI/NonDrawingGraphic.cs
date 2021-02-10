using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoffeeMaker.UI
{
    public class NonDrawingGraphic : Image
    {
        protected override void OnFillVBO(List<UIVertex> vbo)
        {
        }

        protected override void OnPopulateMesh(Mesh m)
        {
        }

        protected override void OnPopulateMesh(VertexHelper toFill)
        {
            toFill.Clear();
        }
    }
}