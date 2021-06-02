﻿using UnityEngine;
using UnityEngine.UI;

namespace Aya.DataBinding
{
    [AddComponentMenu("Data Binding/Dropdown Binder")]
    public class DropdownBinder : ComponentBinder<Dropdown, int, RuntimeDropdownBinder>
    {
       
    }

    public class RuntimeDropdownBinder : DataBinder<Dropdown, int>
    {
        public override void AddListener() => Target.onValueChanged.AddListener(OnValueChangedCallback);
        public override void RemoveListener() => Target.onValueChanged.RemoveListener(OnValueChangedCallback);

        public override void SetData(int data)
        {
            Target.value = data;
        }

        public override int GetData()
        {
            return Target.value;
        }
    }

#if UNITY_EDITOR

    [UnityEditor.CustomEditor(typeof(DropdownBinder)), UnityEditor.CanEditMultipleObjects]
    public class DropdownBinderEditor : ComponentBinderEditor<Dropdown, int, RuntimeDropdownBinder>
    {
    }

#endif
}