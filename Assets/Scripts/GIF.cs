using UnityEngine;
using UnityEngine.UI;

public class GIF : MonoBehaviour
{
    public Sprite[] Frames;
    public float FramesPerSecond = 1;

    private Image _image;
    private SpriteRenderer _spriteRenderer;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        index = (int)(Time.time * FramesPerSecond);
        index = index % Frames.Length;
        if (_image != null)
            _image.sprite = Frames[index];
        if (_spriteRenderer != null)
            _spriteRenderer.sprite = Frames[index];
    }
}
