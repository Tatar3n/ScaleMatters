using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRectLimiter : MonoBehaviour
{
    public RectTransform content; 

    void Update()
    {
        // �������� RectTransform Scroll Rect
        RectTransform scrollRectTransform = GetComponent<RectTransform>();

        // �������� ������ Viewport
        Vector2 viewportSize = scrollRectTransform.rect.size;

        // �������� ������� Content ������������ Viewport
        Vector2 contentPosition = content.anchoredPosition - scrollRectTransform.anchoredPosition;

        // ����������� �� ��� X
        if (contentPosition.x < 0)
        {
            contentPosition.x = 0;
        }
        if (contentPosition.x > viewportSize.x - content.rect.width)
        {
            contentPosition.x = viewportSize.x - content.rect.width;
        }

        // ����������� �� ��� Y
        if (contentPosition.y < 0)
        {
            contentPosition.y = 0;
        }
        if (contentPosition.y > viewportSize.y - content.rect.height)
        {
            contentPosition.y = viewportSize.y - content.rect.height;
        }

        // ��������� ����� ������� Content ������������ Viewport
        content.anchoredPosition = scrollRectTransform.anchoredPosition + contentPosition;
    }
}
