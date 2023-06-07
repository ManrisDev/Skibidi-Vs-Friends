using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum DeformationType { 
    Width,
    Height
}

public class GateAppearaence : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Image _topImage;
    [SerializeField] private Image _glassImage;

    [SerializeField] private Color _colorPositive;
    [SerializeField] private Color _colorNegative;

    public void UpdateVisual(DeformationType deformationType, int value)
    {
        string prefix = "";

        if (value > 0)
        {
            prefix = "+";
            SetColor(_colorPositive);
        } else if (value == 0) {
            SetColor(Color.grey);
        } else
        {
            SetColor(_colorNegative);
        }

        _text.text = prefix + value.ToString();
    }

    private void SetColor(Color color) {
        _topImage.color = color;
        _glassImage.color = new Color(color.r, color.g, color.b, 0.5f);
    }

}


