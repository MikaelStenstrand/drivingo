using UnityEngine;

public class TriggerAmountTextCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject textPrefab;
    [SerializeField]
    private float destroyTime = 2f;

    [SerializeField]
    private Vector3 offset = new Vector3(0 , 2, 0);
    private Vector3 randomIntensity = new Vector3(1f, 0, 0);

    public void InstantiateTriggerAmountText()
    {
        GameObject GO = Instantiate(textPrefab, transform.position, Quaternion.identity, transform);
        GO.transform.localPosition += offset;
        GO.transform.localPosition += new Vector3(
            Random.Range(-randomIntensity.x, randomIntensity.x),
            Random.Range(-randomIntensity.y, randomIntensity.y),
            Random.Range(-randomIntensity.z, randomIntensity.z)
            );
        TriggerAmountTextUpdaterUI ui = GO.GetComponent<TriggerAmountTextUpdaterUI>();
        ui.DestroyOnTime(destroyTime);
    }
}
