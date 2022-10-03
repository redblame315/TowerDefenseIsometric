using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class FlexibleUI : MonoBehaviour
{
    [SerializeField]
    protected FlexibleUIData skinData;

    protected virtual void OnSkinUI()
    {

    }

    public virtual void Awake()
    {
        OnSkinUI();
    }

    public virtual void Update()
    {
        #if UNITY_EDITOR
            if (Application.isEditor)
            {
                OnSkinUI();
            }
        #endif
    }
}
