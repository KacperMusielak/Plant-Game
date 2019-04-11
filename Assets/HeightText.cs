using UnityEngine;
using UnityEngine.UI;

public class HeightText : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = FindObjectOfType<LineRenderer>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = lineRenderer.GetPosition(lineRenderer.positionCount - 1).y.ToString("0.0");
    }
}
