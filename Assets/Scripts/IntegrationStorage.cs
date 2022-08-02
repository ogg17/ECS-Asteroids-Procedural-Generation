using UnityEngine;

[CreateAssetMenu(menuName = CoreConstants.StoragesFolder + nameof(IntegrationStorage), fileName = nameof(IntegrationStorage))]
public class IntegrationStorage: ScriptableObject
{ 
    public GameObject sceneBuilder;
}