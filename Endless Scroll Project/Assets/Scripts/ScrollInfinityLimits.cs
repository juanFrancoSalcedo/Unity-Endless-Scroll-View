using UnityEngine;


public partial class ScrollInfinity
{
    //GUIStyle style = new GUIStyle();
    //private void OnGUI()
    //{
    //    style.fontSize = 30;
    //    GUI.Label(new Rect(20f, 20f, 30f, 30f), gg, style);
    //}

    public class ScrollInfinityLimits
    {
        readonly ScrollInfinity controller = null;

        public ScrollInfinityLimits(ScrollInfinity controller)
        {
            this.controller = controller;
        }

        internal Vector2 EndLimit(RectTransform element)
        {
            var last = (RectTransform)controller.content.transform.GetChild(controller.content.transform.childCount - 1).transform;
            var returnVector = Vector2.zero;
            if (controller.horizontal)
            {
                returnVector.y = element.anchoredPosition.y;
                returnVector.x =
                (last.anchoredPosition.x +
                (last.sizeDelta.x / 2) +
                (element.sizeDelta.x / 2) + controller.spacing);
            }
            else
            {
                returnVector.x = element.anchoredPosition.x;
                returnVector.y =
                (last.anchoredPosition.y -
                (last.sizeDelta.y / 2) -
                element.sizeDelta.y / 2 - controller.spacing);
            }

            return returnVector;
        }

        internal Vector2 FirstLimit(RectTransform element)
        {
            var first = (RectTransform)controller.content.transform.GetChild(0).transform;
            var returnVector = Vector2.zero;

            if (controller.horizontal)
            {
                returnVector.y = element.anchoredPosition.y;
                returnVector.x =
                    first.anchoredPosition.x -
                    first.sizeDelta.x / 2 -
                    element.sizeDelta.x / 2 - controller.spacing;

            }
            else
            {
                returnVector.x = element.anchoredPosition.x;
                returnVector.y =
                    (first.anchoredPosition.y +
                    (first.sizeDelta.y / 2) +
                    (element.sizeDelta.y / 2) + controller.spacing);
            }

            return returnVector;
        }

        internal bool IsOnLimitLower()
        {
            var first = (RectTransform)controller.content.transform.GetChild(0).transform;
            var last = (RectTransform)controller.content.transform.GetChild(controller.content.transform.childCount - 1).transform;
            if (controller.horizontal)
                return controller.content.anchoredPosition.x < (first.anchoredPosition.x) - (first.sizeDelta.x / 2) - controller.spacing;
            else
                return -last.anchoredPosition.y < (controller.content.sizeDelta.y - (last.sizeDelta.y / 2) - controller.spacing);
        }

        internal bool IsOnLimitUpper()
        {
            var first = (RectTransform)controller.content.transform.GetChild(0).transform;
            var last = (RectTransform)controller.content.transform.GetChild(controller.content.transform.childCount - 1).transform;
            if (controller.horizontal)
                return controller.content.sizeDelta.x > (last.anchoredPosition.x + (last.sizeDelta.x / 2) + controller.spacing);
            else
                return - ((first.sizeDelta.y/2) + controller.spacing) > first.anchoredPosition.y;
        }
    }
}


