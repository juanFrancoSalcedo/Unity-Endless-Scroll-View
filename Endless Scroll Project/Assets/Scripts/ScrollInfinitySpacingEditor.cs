using UnityEngine.UI;


public partial class ScrollInfinity
{
    public class ScrollInfinitySpacingEditor
    {
        internal static void ApplySpacingEditor(ScrollInfinity scroll)
        {
            if (scroll.spacing != scroll.spacingChecker)
                SetComponent(scroll);
            else
                ActiveElementoLayout(scroll);
            scroll.spacingChecker = scroll.spacing;
        }

        private static void SetComponent(ScrollInfinity scroll)
        {
            if (scroll.horizontal)
            {
                if (!scroll.content.gameObject.GetComponent<HorizontalLayoutGroup>())
                    scroll.content.gameObject.AddComponent<HorizontalLayoutGroup>();

                var handler = scroll.content.gameObject.GetComponent<HorizontalLayoutGroup>();
                handler.spacing = scroll.spacing;
                handler.padding.left = (int)scroll.spacing;
                handler.enabled = true;
            }
            else
            {
                if (!scroll.content.gameObject.GetComponent<VerticalLayoutGroup>())
                    scroll.content.gameObject.AddComponent<VerticalLayoutGroup>();

                var handler = scroll.content.gameObject.GetComponent<VerticalLayoutGroup>();
                handler.spacing = scroll.spacing;
                handler.padding.top = (int)scroll.spacing;
                handler.enabled = true;
            }
        }

        internal static void ActiveElementoLayout(ScrollInfinity scroll)
        {
            if (scroll.horizontal)
            {
                if (scroll.content.gameObject.GetComponent<HorizontalLayoutGroup>())
                    scroll.content.gameObject.GetComponent<HorizontalLayoutGroup>().enabled = false;
            }
            else
            {
                if (scroll.content.gameObject.GetComponent<VerticalLayoutGroup>())
                    scroll.content.gameObject.GetComponent<VerticalLayoutGroup>().enabled = false;
            }
        }
    }
}


