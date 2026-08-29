using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public class ButtonSfxPlayer : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Button button;
    [SerializeField] private PlayableSfxSettings clickSfx;
    [SerializeField] private PlayableSfxSettings hoverSfx;



    private void OnEnable()
    {
        button.onClick.AddListener(PlayClickSound);

    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(PlayClickSound);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.Play2DClip(hoverSfx);
    }

    private void PlayClickSound()
    {
        AudioManager.Instance.Play2DClip(clickSfx);
    }
}