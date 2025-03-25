using System;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FormulaBlock : MonoBehaviour
{
    // Общее поле для всех формул
    public TMP_Text formulaText;
    public TMP_InputField[] inputFields;
    public Button calculateButton;
    public TMP_Text resultText;

    // Константы
    public PhysicsConstants constants;
    
    public FormulaTextData formulaTextData;

    // Перечисление для выбора формулы
    public enum FormulaType
    {
        Force,                  // F = ma
        Impulse,                // p = mv
        Pressure,               // P = ρgh
        GravitationalForce,     // F = G(m1 * m2) / r^2
        FinalVelocity           // v = u + at
    }

    public FormulaType formulaType;

    private void Start()
    {
        SetFormulaText();
        
        calculateButton.onClick.AddListener(Calculate);
        calculateButton.interactable = false;

        foreach (var field in inputFields)
        {
            field.onValueChanged.AddListener(CheckInputFields);
        }
    }
    
    private void SetFormulaText()
    {
        // Получаем текст формулы из FormulaTextData
        formulaText.text = formulaType switch
        {
            FormulaType.Force => formulaTextData.formula1,
            FormulaType.Impulse => formulaTextData.formula5,
            FormulaType.Pressure => formulaTextData.formula2,
            FormulaType.GravitationalForce => formulaTextData.formula3,
            FormulaType.FinalVelocity => formulaTextData.formula4,
            _ => formulaText.text
        };
    }

    private void CheckInputFields(string input)
    {
        calculateButton.interactable = AreAllFieldsFilled();
    }

    private bool AreAllFieldsFilled()
    {
        return inputFields.All(field => !string.IsNullOrEmpty(field.text));
    }

    private void Calculate()
    {
        var result = 0f;

        try
        {
            switch (formulaType)
            {
                case FormulaType.Force:
                    var mass = float.Parse(inputFields[0].text);
                    var acceleration = float.Parse(inputFields[1].text);
                    result = PhysicsCalculator.CalculateForce(mass, acceleration);
                    break;

                case FormulaType.Impulse:
                    var energyMass = float.Parse(inputFields[0].text);
                    var speed = float.Parse(inputFields[1].text);
                    result = PhysicsCalculator.CalculateImpulse(energyMass, speed);
                    break;

                case FormulaType.Pressure:
                    var density = float.Parse(inputFields[0].text);
                    var gravity = constants.universalGravitationalConstant;
                    var height = float.Parse(inputFields[1].text);
                    result = PhysicsCalculator.CalculatePressure(density, gravity, height);
                    break;

                case FormulaType.GravitationalForce:
                    var mass1 = float.Parse(inputFields[0].text);
                    var mass2 = float.Parse(inputFields[1].text);
                    var distance = float.Parse(inputFields[2].text);
                    var gravitationalConstant = constants.gravitationalConstant;
                    result = PhysicsCalculator.CalculateGravitationalForce(mass1, mass2, distance, gravitationalConstant);
                    break;

                case FormulaType.FinalVelocity:
                    var initialVelocity = float.Parse(inputFields[0].text);
                    var accel = float.Parse(inputFields[1].text);
                    var time = float.Parse(inputFields[2].text);
                    result = PhysicsCalculator.CalculateFinalVelocity(initialVelocity, accel, time);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            resultText.text = $"Result: {result}";
        }
        catch
        {
            resultText.text = "Error: Invalid input!";
        }
    }
}
