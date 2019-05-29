using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GIF : MonoBehaviour
{
    public Sprite[] Frames;
    public float FramesPerSecond = 1;

    private Image _image;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        index = (int)(Time.time * FramesPerSecond);
        index = index % Frames.Length;
        _image.sprite = Frames[index];
    }
}
