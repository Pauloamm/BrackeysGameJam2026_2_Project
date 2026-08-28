using UnityEngine;
using System.Collections.Generic;

public class PlayerShieldUIManager : MonoBehaviour
{
    [SerializeField] private MonoBehaviour shieldableSource;
    [SerializeField] private GameObject pipPrefab;
    [SerializeField] private Transform pipContainer;

    private IShieldable shieldable;
    private readonly List<GameObject> pipInstances = new List<GameObject>();
    private readonly List<GameObject> shieldIcons = new List<GameObject>();

    private void Awake()
    {
        shieldable = (IShieldable)shieldableSource;

        RebuildPips(shieldable.MaxShields);
        RefreshFilledPips(shieldable.CurrentShields);

        shieldable.OnMaxShieldValueChanged += HandleMaxShieldValueChanged;
        shieldable.OnCurrentShieldValueChanged += HandleCurrentShieldValueChanged;
    }

    private void OnDestroy()
    {
        shieldable.OnMaxShieldValueChanged -= HandleMaxShieldValueChanged;
        shieldable.OnCurrentShieldValueChanged -= HandleCurrentShieldValueChanged;
    }

    private void HandleMaxShieldValueChanged(int newMax)
    {
        RebuildPips(newMax);
        RefreshFilledPips(shieldable.CurrentShields);
    }

    private void HandleCurrentShieldValueChanged(int newCurrent)
    {
        RefreshFilledPips(newCurrent);
    }

    private void RebuildPips(int newMax)
    {
        while (pipInstances.Count < newMax)
        {
            GameObject pipInstance = Instantiate(pipPrefab, pipContainer);
            pipInstances.Add(pipInstance);
            shieldIcons.Add(pipInstance.transform.GetChild(0).gameObject);
        }

        while (pipInstances.Count > newMax)
        {
            int lastIndex = pipInstances.Count - 1;
            Destroy(pipInstances[lastIndex]);
            pipInstances.RemoveAt(lastIndex);
            shieldIcons.RemoveAt(lastIndex);
        }
    }

    private void RefreshFilledPips(int currentShields)
    {
        for (int i = 0; i < shieldIcons.Count; i++)
        {
            shieldIcons[i].SetActive(i < currentShields);
        }
    }

    private void OnValidate()
    {
        if (shieldableSource != null && !(shieldableSource is IShieldable))
        {
            Debug.LogError($"{nameof(shieldableSource)} on {name} must implement IShieldable.", this);
        }
    }
}