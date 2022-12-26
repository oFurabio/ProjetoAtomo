using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour {
    public TextMeshProUGUI FpsText;

    private float poolingTime = 0.1f;
    private float time;
    private int frameCount;

    void Update() {
        time += Time.deltaTime;

        frameCount++;

        if(time >= poolingTime) {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + " FPS";

            time -= poolingTime;
            frameCount = 0;
        }
    }
}
