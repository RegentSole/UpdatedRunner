using UnityEngine;
using UnityEngine.UI;

public class PopupManager : MonoBehaviour
{
    public GameObject defeatPanel; // Ссылка на панель попапа

    public void ShowDefeatPopup()
    {
        defeatPanel.SetActive(true); // Показать панель попапа
    }

    public void HideDefeatPopup()
    {
        defeatPanel.SetActive(false); // Скрыть панель попапа
    }
}