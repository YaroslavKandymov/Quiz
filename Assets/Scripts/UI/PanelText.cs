using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class PanelText : MonoBehaviour
{
    private const string _findText = "Find ";

    [SerializeField] private BarView _barView;

    private TMP_Text _text;

    private void OnEnable()
    {
        _barView.PurposeCellChanged += OnPurposeCellChanged;
    }

    private void OnDisable()
    {
        _barView.PurposeCellChanged -= OnPurposeCellChanged;
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.text = _findText + _barView.PurposeCellName;
    }

    private void OnPurposeCellChanged(string cellName)
    {
        _text.text = _findText + cellName;
    }
}
