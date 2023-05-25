using UnityEngine;

namespace SOLib.Variables
{
    [CreateAssetMenu(menuName = "SOLib/Variables/Boolean", fileName = "BooleanVariable.asset")]
    public class BooleanVariable : ScriptableVariable<bool>
        // , ISerializable
    {

        // [SerializeField] private EditorGuidProperty saveId; 
        //
        // public Guid GetId()
        // {
        //     return new Guid(saveId.customGuidId);
        // }
        //
        // public string Serialize()
        // {
        //     return value.ToString();
        // }
        //
        // public void Deserialize(string value)
        // {
        //     this.value = bool.Parse(value);
        // }
    }
}
