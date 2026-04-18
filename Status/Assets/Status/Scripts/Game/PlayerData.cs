using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public static PlayerData instance;

    [SerializeField] private TextMeshProUGUI PlayerName;
    [SerializeField] private TextMeshProUGUI PlayerPoints;
    [SerializeField] private TextMeshProUGUI PlayerStatus;
    [SerializeField] private TextMeshProUGUI AIName;
    [SerializeField] private TextMeshProUGUI AIPoints;
    [SerializeField] private TextMeshProUGUI AIStatus;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerName.text = GameManager.instance.Me.Name;
        PlayerPoints.text = GameManager.instance.Me.StatusPoints.ToString();
        PlayerStatus.text = GameManager.instance.Me.CurrentRole.ToString();
        AIName.text = GameManager.instance.AI.Name;
        AIPoints.text = GameManager.instance.AI.StatusPoints.ToString();
        AIStatus.text = GameManager.instance.AI.CurrentRole.ToString();
    }

    public void UpdateAmount(Player player,int Amount)
    {
        if (player == null)
        {
            Debug.LogError("Couldnt locate player");
            return;
        }
        if (player == GameManager.instance.Me)
        {
            PlayerPoints.text = Amount.ToString();
            return;
        }
        else if (player == GameManager.instance.AI)
        { 
            AIPoints.text = Amount.ToString();
        }
    }

    public void UpdateStatus(Player player,Role Status)
    {
        if (player == null)
        {
            Debug.LogError("Couldnt locate player");
            return;
        }
        if (player == GameManager.instance.Me)
        {
            PlayerStatus.text = Status.ToString();
            return;
        }
        else if (player == GameManager.instance.AI)
        {
            AIStatus.text = Status.ToString();
        }
    }
}
