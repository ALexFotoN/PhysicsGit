using UnityEngine;

[CreateAssetMenu(fileName = "FormulaTextData", menuName = "ScriptableObjects/FormulaTextData")]
public class FormulaTextData : ScriptableObject
{
    [TextArea] public string formula1;
    [TextArea] public string formula2;
    [TextArea] public string formula3;
    [TextArea] public string formula4;
    [TextArea] public string formula5;
}