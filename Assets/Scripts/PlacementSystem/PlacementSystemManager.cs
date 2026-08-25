using UnityEngine;

public class PlacementSystemManager : MonoBehaviour
{
    [SerializeField] private PlayerInputReader inputReader;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SpriteRenderer indicatorRenderer;
    [SerializeField] private LayerMask obstacleLayerMask;
    [SerializeField] private float placementCheckRadius = 0.5f;
    [SerializeField] private Color validColor = Color.green;
    [SerializeField] private Color invalidColor = Color.red;

    [Header("Turret Managers")]
    [SerializeField] private CannonManager cannonManager;
    [SerializeField] private ShotgunManager shotgunManager;
    [SerializeField] private PylonManager pylonManager;
    [SerializeField] private AegisManager aegisManager;

    private bool isActive;
    private bool isValidPlacement;
    private Vector3 currentWorldPosition;
    private ITurretSpawner currentManager;

    private void Awake()
    {
        mainCamera = Camera.main;

        inputReader.SelectCannonPressed += HandleSelectCannonPressed;
        inputReader.SelectShotgunPressed += HandleSelectShotgunPressed;
        inputReader.SelectPylonPressed += HandleSelectPylonPressed;
        inputReader.SelectAegisPressed += HandleSelectAegisPressed;
        inputReader.ConfirmPlacementPressed += HandleConfirmPlacementPressed;
        inputReader.CancelPlacementPressed += HandleCancelPlacementPressed;

        indicatorRenderer.enabled = false;
    }

    private void OnDestroy()
    {
        inputReader.SelectCannonPressed -= HandleSelectCannonPressed;
        inputReader.SelectShotgunPressed -= HandleSelectShotgunPressed;
        inputReader.SelectPylonPressed -= HandleSelectPylonPressed;
        inputReader.SelectAegisPressed -= HandleSelectAegisPressed;
        inputReader.ConfirmPlacementPressed -= HandleConfirmPlacementPressed;
        inputReader.CancelPlacementPressed -= HandleCancelPlacementPressed;
    }

    private void Update()
    {
        if (!isActive) return;

        currentWorldPosition = GetMouseWorldPosition();
        isValidPlacement = CheckPlacementValidity(currentWorldPosition);

        indicatorRenderer.transform.position = currentWorldPosition;
        indicatorRenderer.color = isValidPlacement ? validColor : invalidColor;
    }

    private void HandleSelectCannonPressed()
    {
        Activate(cannonManager);
    }

    private void HandleSelectShotgunPressed()
    {
        Activate(shotgunManager);
    }

    private void HandleSelectPylonPressed()
    {
        Activate(pylonManager);
    }

    private void HandleSelectAegisPressed()
    {
        Activate(aegisManager);
    }

    private void HandleConfirmPlacementPressed()
    {
        if (!isActive || !isValidPlacement) return;

        currentManager.SpawnTurretAt(currentWorldPosition, Quaternion.identity);
        Deactivate();
    }

    private void HandleCancelPlacementPressed()
    {
        if (!isActive) return;

        Deactivate();
    }

    private void Activate(ITurretSpawner manager)
    {
        currentManager = manager;
        isActive = true;
        indicatorRenderer.enabled = true;
    }

    private void Deactivate()
    {
        isActive = false;
        currentManager = null;
        indicatorRenderer.enabled = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector2 screenPos = inputReader.MousePosition;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, -mainCamera.transform.position.z));
        worldPos.z = 0f;
        return worldPos;
    }

    private bool CheckPlacementValidity(Vector3 position)
    {
        return Physics2D.OverlapCircle(position, placementCheckRadius, obstacleLayerMask) == null;
    }
}