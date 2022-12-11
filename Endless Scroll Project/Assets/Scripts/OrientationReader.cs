using UnityEngine;


public partial class ScrollInfinity
{
    public class OrientationReader
    {
        readonly ScrollInfinity controller = null;

        public OrientationReader(ScrollInfinity controller)
        {
            this.controller = controller;
        }

        internal Vector2 GetDragOrientation()
        {
            if (controller.horizontal)
            {
                // constraints de direction
                controller.currentTouch.y = 0;
                controller.initTouch.y = 0;
            }
            else
            {
                // constraints de direction
                controller.currentTouch.x = 0;
                controller.initTouch.x = 0;
            }
            return controller.currentTouch - controller.initTouch;
        }

        // depending the orientation, returns if is grater than zero in X or Y axis
        internal bool IsGreaterZero()
        {
            if (controller.horizontal)
                return GetDragOrientation().x > 0;
            else
                return GetDragOrientation().y > 0;
        }
    }
}


