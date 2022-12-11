using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public partial class ScrollInfinity : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform content = null;
    [Range(0.001f, 2f)]
    [SerializeField] private float sensitivity = 0.01f;
    [SerializeField] private float spacing = 30f;
    [SerializeField] private bool horizontal = true;
    [HideInInspector]
    float spacingChecker = 0;
    private ScrollInfinityLimits scrollLimit = null;
    private ScrollInfinityElementQueue scrollQueue = null;
    private OrientationReader orientationReader;
    private void OnValidate()
    {
        ScrollInfinitySpacingEditor.ApplySpacingEditor(this);
    }

    IEnumerator Start()
    {
        scrollLimit = new ScrollInfinityLimits(this);
        scrollQueue = new ScrollInfinityElementQueue(content,scrollLimit);
        orientationReader = new OrientationReader(this);
        yield return new WaitForEndOfFrame();
        // use unity layout group for organize elements
        ScrollInfinitySpacingEditor.ActiveElementoLayout(this);
    }

    Vector2 initTouch;
    Vector2 currentTouch;

    public void OnBeginDrag(PointerEventData eventData) => initTouch = eventData.position;

    public void OnEndDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        currentTouch = eventData.position;
        if (orientationReader.IsGreaterZero())
            MovePositiveDirection();
        else
            MoveNegativeDirection();
        //continues updateing de position
        initTouch = eventData.position;
    }

    private void MoveNegativeDirection()
    {

        MoveElements();
        // arrived to limit last element
        if (scrollLimit.IsOnLimitUpper())
        {
            if (horizontal)
                scrollQueue.PutFisrtAsLast();
            else
                scrollQueue.PutLastAsFirst();
        }
    }

    private void MovePositiveDirection()
    {
        MoveElements();
        // arrived to limit first element
        if (scrollLimit.IsOnLimitLower())
        {
            if (horizontal)
                scrollQueue.PutLastAsFirst();
            else
                scrollQueue.PutFisrtAsLast();
        }
    }

    private void MoveElements()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            var rectTrans = (RectTransform)content.GetChild(i).transform;
            rectTrans.anchoredPosition += orientationReader.GetDragOrientation() * 0.25f;
        }
    }
}




