using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PickupInfoImage : MonoBehaviour
{
    private float _amount = 0;
    private float _timer = 0;
    private Image _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _amount = (float) GameManager.Pickups / (float) GameManager.MaxPickups;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * _amount / 3f;
        _image.fillAmount = Mathf.Lerp(0, _amount, _timer);
    }
}
