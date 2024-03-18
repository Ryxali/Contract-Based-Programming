using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class ClickSplitStep : MonoBehaviour, ISlideStep
{
    [SerializeField]
    private string regex;
    private readonly StringBuilder stringBuilder = new StringBuilder();

    private TMPro.TMP_Text text;
    private string[] splitString;
    private int index;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
        splitString = Regex.Matches(text.text, regex).Select(m => m.Value).ToArray();
        if (TryGetComponent<ContentSizeFitter>(out var fitter)) fitter.enabled = false;
    }

    public void Enter()
    {
        index = 0;
        stringBuilder.Clear();
        stringBuilder.Append(splitString[index]);
        text.text = stringBuilder.ToString();
    }

    public void Exit()
    {
    }

    public bool MoveNext(ref PlayerInput input)
    {
        if (input.anyKeyDown)
        {
            input.anyKeyDown = false;
            index++;
            if (index < splitString.Length)
            {
                stringBuilder.Append(splitString[index]);
                text.text = stringBuilder.ToString();
            }
        }
        return index >= splitString.Length;
    }
}