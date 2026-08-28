using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretLoadoutUIManager : MonoBehaviour
{
    [SerializeField] private PlacementSystemManager placementSystemManager;

    [Header("Highlight Colors")]
    [SerializeField] private Color normalColor = new Color32(140, 140, 140, 255);
    [SerializeField] private Color highlightColor = new Color32(88, 127, 180, 255);

    [Header("Cannon")]
    [SerializeField] private CannonManager cannonManager;
    [SerializeField] private TMP_Text cannonCountText;
    [SerializeField] private Image cannonSlotImage;

    [Header("Shotgun")]
    [SerializeField] private ShotgunManager shotgunManager;
    [SerializeField] private TMP_Text shotgunCountText;
    [SerializeField] private Image shotgunSlotImage;

    [Header("Pylon")]
    [SerializeField] private PylonManager pylonManager;
    [SerializeField] private TMP_Text pylonCountText;
    [SerializeField] private Image pylonSlotImage;

    [Header("Aegis")]
    [SerializeField] private AegisManager aegisManager;
    [SerializeField] private TMP_Text aegisCountText;
    [SerializeField] private Image aegisSlotImage;

    private void Awake()
    {
        cannonManager.OnDeployedCountChanged += HandleCannonCountChanged;
        shotgunManager.OnDeployedCountChanged += HandleShotgunCountChanged;
        pylonManager.OnDeployedCountChanged += HandlePylonCountChanged;
        aegisManager.OnDeployedCountChanged += HandleAegisCountChanged;

        HandleCannonCountChanged(cannonManager.CurrentDeployedCount, cannonManager.CurrentCap);
        HandleShotgunCountChanged(shotgunManager.CurrentDeployedCount, shotgunManager.CurrentCap);
        HandlePylonCountChanged(pylonManager.CurrentDeployedCount, pylonManager.CurrentCap);
        HandleAegisCountChanged(aegisManager.CurrentDeployedCount, aegisManager.CurrentCap);

        placementSystemManager.OnCannonPlacementActivated += HandleCannonPlacementActivated;
        placementSystemManager.OnShotgunPlacementActivated += HandleShotgunPlacementActivated;
        placementSystemManager.OnPylonPlacementActivated += HandlePylonPlacementActivated;
        placementSystemManager.OnAegisPlacementActivated += HandleAegisPlacementActivated;
        placementSystemManager.OnPlacementDeactivated += HandlePlacementDeactivated;
    }

    private void OnDestroy()
    {
        cannonManager.OnDeployedCountChanged -= HandleCannonCountChanged;
        shotgunManager.OnDeployedCountChanged -= HandleShotgunCountChanged;
        pylonManager.OnDeployedCountChanged -= HandlePylonCountChanged;
        aegisManager.OnDeployedCountChanged -= HandleAegisCountChanged;

        placementSystemManager.OnCannonPlacementActivated -= HandleCannonPlacementActivated;
        placementSystemManager.OnShotgunPlacementActivated -= HandleShotgunPlacementActivated;
        placementSystemManager.OnPylonPlacementActivated -= HandlePylonPlacementActivated;
        placementSystemManager.OnAegisPlacementActivated -= HandleAegisPlacementActivated;
        placementSystemManager.OnPlacementDeactivated -= HandlePlacementDeactivated;
    }

    private void HandleCannonCountChanged(int current, int cap)
    {
        cannonCountText.text = $"{current}/{cap}";
    }

    private void HandleShotgunCountChanged(int current, int cap)
    {
        shotgunCountText.text = $"{current}/{cap}";
    }

    private void HandlePylonCountChanged(int current, int cap)
    {
        pylonCountText.text = $"{current}/{cap}";
    }

    private void HandleAegisCountChanged(int current, int cap)
    {
        aegisCountText.text = $"{current}/{cap}";
    }

    private void HandleCannonPlacementActivated()
    {
        SetHighlight(cannonSlotImage);
    }

    private void HandleShotgunPlacementActivated()
    {
        SetHighlight(shotgunSlotImage);
    }

    private void HandlePylonPlacementActivated()
    {
        SetHighlight(pylonSlotImage);
    }

    private void HandleAegisPlacementActivated()
    {
        SetHighlight(aegisSlotImage);
    }

    private void HandlePlacementDeactivated()
    {
        SetHighlight(null);
    }

    private void SetHighlight(Image activeSlotImage)
    {
        cannonSlotImage.color = activeSlotImage == cannonSlotImage ? highlightColor : normalColor;
        shotgunSlotImage.color = activeSlotImage == shotgunSlotImage ? highlightColor : normalColor;
        pylonSlotImage.color = activeSlotImage == pylonSlotImage ? highlightColor : normalColor;
        aegisSlotImage.color = activeSlotImage == aegisSlotImage ? highlightColor : normalColor;
    }
}