using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    public RectTransform[] panels;  // Array of panels to scroll
    public float scrollSpeed = 50f;  // Speed of the scroll

    private float panelWidth;  // Width of one panel

    void Start()
    {
        // Assuming all panels are the same width
        panelWidth = panels[0].rect.width;
    }

    void Update()
    {
        foreach (RectTransform panel in panels)
        {
            // Move each panel to the left
            panel.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;

            // Check if the panel has moved out of the view on the left side
            if (panel.anchoredPosition.x <= -panelWidth)
            {
                // Move the panel to the right of the last panel
                float newXPosition = panel.anchoredPosition.x + 2 * panelWidth;
                panel.anchoredPosition = new Vector2(newXPosition, panel.anchoredPosition.y);
            }
        }
    }
}




