using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapImageController : MonoBehaviour {
    public int largeMapSize = 250;
    
    public int mediumMapSize = 200;

    public int smallMapSize = 150;

    public RectTransform rect;

    // Start is called before the first frame update
    void Start() {
        rect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
    }

    public void setLargeMap() {
        rect.sizeDelta = new Vector2(largeMapSize, largeMapSize);
        rect.anchoredPosition = calculatePositionFromSize(rect.sizeDelta);
    }

    public void setMediumMap() {
        rect.sizeDelta = new Vector2(mediumMapSize, mediumMapSize);
        rect.anchoredPosition = calculatePositionFromSize(rect.sizeDelta);
    }

    public void setSmallMap() {
        rect.sizeDelta = new Vector2(smallMapSize, smallMapSize);
        rect.anchoredPosition = calculatePositionFromSize(rect.sizeDelta);
    }

    private Vector2 calculatePositionFromSize(Vector2 size) {
        return new Vector2(-size.x / 2 - 20, -size.y / 2 - 20);
    }
}
