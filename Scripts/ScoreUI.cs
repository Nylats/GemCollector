using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text label;

    private void Awake()
    {
        if (label == null)
            label = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (label == null) return;

        var vars = Variables.ActiveScene;
        if (vars == null) return;

        if (vars.IsDefined("Score"))
            label.text = "Puntaje: " + vars.Get<int>("Score");
    }
}