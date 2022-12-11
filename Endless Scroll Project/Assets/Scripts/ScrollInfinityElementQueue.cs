using UnityEngine;


public partial class ScrollInfinity
{
    public class ScrollInfinityElementQueue
    {
        private RectTransform content = null;
        private ScrollInfinityLimits limits = null;
        public ScrollInfinityElementQueue(RectTransform content, ScrollInfinityLimits limits)
        {
            this.content = content;
            this.limits = limits;
        }

        internal void PutLastAsFirst()
        {
            var lat = content.transform.childCount - 1;
            content.GetChild(lat).GetComponent<RectTransform>().anchoredPosition = 
                limits.FirstLimit(content.GetChild(lat).GetComponent<RectTransform>());
            content.GetChild(lat).SetSiblingIndex(0);
        }

        internal void PutFisrtAsLast()
        {
            content.GetChild(0).GetComponent<RectTransform>().anchoredPosition =
                limits.EndLimit(content.GetChild(0).GetComponent<RectTransform>());
            content.GetChild(0).SetAsLastSibling();
        }
    }
}




