using System;
using System.Globalization;
using UnityEngine;

namespace SOLib.Variables
{
    [CreateAssetMenu(menuName = "SOLib/Variables/Float", fileName = "FloatVariable.asset")]
    public class FloatVariable : ScriptableVariable<float>
        // , ISerializable
    {
        // public EditorGuidProperty id;

        // public Guid GetId()
        // {
        //     return new Guid(id.customGuidId);
        // }

        // public string Serialize()
        // {
        //     return value.ToString(CultureInfo.InvariantCulture);
        // }
        //
        // public void Deserialize(string value)
        // {
        //     if (!string.IsNullOrWhiteSpace(value))
        //     {
        //         this.value = float.Parse(value, CultureInfo.InvariantCulture);
        //     }
        // }
    }
}