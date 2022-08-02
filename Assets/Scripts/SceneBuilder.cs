using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBuilder : MonoBehaviour
{
    [SerializeField] private IntegrationStorage integrationStorage;
    
    void Awake()
    {
        integrationStorage.sceneBuilder = this.gameObject;
    }

}
