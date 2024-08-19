using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRectLimiter : MonoBehaviour
{
    public RectTransform content; 

    void Update()
    {
        // Получаем RectTransform Scroll Rect
        RectTransform scrollRectTransform = GetComponent<RectTransform>();

        // Получаем размер Viewport
        Vector2 viewportSize = scrollRectTransform.rect.size;

        // Получаем позицию Content относительно Viewport
        Vector2 contentPosition = content.anchoredPosition - scrollRectTransform.anchoredPosition;

        // Ограничение по оси X
        if (contentPosition.x < 0)
        {
            contentPosition.x = 0;
        }
        if (contentPosition.x > viewportSize.x - content.rect.width)
        {
            contentPosition.x = viewportSize.x - content.rect.width;
        }

        // Ограничение по оси Y
        if (contentPosition.y < 0)
        {
            contentPosition.y = 0;
        }
        if (contentPosition.y > viewportSize.y - content.rect.height)
        {
            contentPosition.y = viewportSize.y - content.rect.height;
        }

        // Установка новой позиции Content относительно Viewport
        content.anchoredPosition = scrollRectTransform.anchoredPosition + contentPosition;
    }
}
