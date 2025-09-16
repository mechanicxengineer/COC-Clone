using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _goldText = null;
    [SerializeField] public TextMeshProUGUI _elixirText = null;
    [SerializeField] public TextMeshProUGUI _gemsText = null;
    [SerializeField] private Button _shopButton = null;

    private static MainUI _instance = null;
    public static MainUI instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _shopButton.onClick.AddListener(ShopButtonClicked);
    }

    private void ShopButtonClicked()
    {

    }
}
