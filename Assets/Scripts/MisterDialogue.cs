using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.Collections.LowLevel.Unsafe;

[System.Serializable]
public class MisterDialogue : MonoBehaviour
{
    int i = 0;
    [Header("Scene references")]
    [SerializeField] private GameObject dialogObj;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogueTextComponent;
    [SerializeField] private TextMeshProUGUI nameTextComponent;
    [SerializeField] private TextMeshProUGUI guideTextComponent;
    [SerializeField] private PlayerInputHandler playerInputHandler;

    //[SerializeField] private GameObject choicesObj;

    //[Header("Prefab references")]
    //[SerializeField] private GameObject choiceButtonPrefab;

    [Header("General")]

    [Header("Dialogue")]
    public Line[] lines;
    private float textSpeed = 0.05f;

    [Header("Extra settings")]
    public string guideText;

    [Header("Debug (if turned on)")]
    private int index;
    private bool isTyping;
    public bool choicesOn;
    bool active;
    public Speaker currentSender;

    void Start()
    {
        dialogueTextComponent.text = string.Empty;
        guideTextComponent.text = string.Empty;

        //StartDialogue();
    }
    void Update()
    {
        if (active)
        {
            if (!choicesOn)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    Debug.Log("Click detected");
                    NextLine();
                }
            }
        }
    }


    // The auto start method used on the beggining of this scene
    public void StartDialogue(Line[] newLines = null, Speaker sender = null)
    {
        index = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerInputHandler.enabled = false;
        dialogObj.SetActive(true);
        dialogBox.SetActive(true);
        active = true;
        if (newLines != null)
        {
            lines = newLines;
        }
        if (sender != null)
        {
            currentSender = sender;
        }
        StartCoroutine(TypeLine());
    }

    // The coroutine responsible for typing out text, can be interrupted
    IEnumerator TypeLine(Line line = null)
    {
        isTyping = true;
        if (line == null)
        {
            if (lines[index].activeSpeaker != null)
            {
                nameTextComponent.text = lines[index].activeSpeaker.name;
            }
            else
            {
                nameTextComponent.text = string.Empty;
            }

            dialogueTextComponent.text = string.Empty;

            foreach (char c in lines[index].text.ToCharArray())
            {
                dialogueTextComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            i++;
            isTyping = false;

            StartCoroutine(TypeGuideLine());
        }
        else
        {
            if (line.activeSpeaker != null)
            {
                nameTextComponent.text = line.activeSpeaker.name;
            }
            else
            {
                nameTextComponent.text = string.Empty;
            }

            dialogueTextComponent.text = string.Empty;

            foreach (char c in line.text.ToCharArray())
            {
                dialogueTextComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }

            isTyping = false;

            StartCoroutine(TypeGuideLine());
        }
    }

    // The method responsible for deciding what to do on click
    public void NextLine(bool isReply = false, Line reply = null, bool badChoice = false)
    {
        guideTextComponent.text = string.Empty;

        if (!isReply)
        {
            Debug.Log($"Not a reply, the text is:{lines[index].text}");
            
            StopAllCoroutines();

            if (lines[index].type == Line.Type.Line)
            {
                if (isTyping)
                {
                    dialogueTextComponent.text = lines[index].text;
                    isTyping = false;
                    
                    StartCoroutine(TypeGuideLine());
                    i++;
                }
                else
                {
                    StopCoroutine(TypeGuideLine());
                    guideTextComponent.text = string.Empty;
                    if (index < lines.Length - 1)
                    {
                        index++;
                        dialogueTextComponent.text = string.Empty;
                        StartCoroutine(TypeLine());
                    }
                    else
                    {
                        dialogBox.SetActive(false);
                        Cursor.visible = false;
                        Cursor.lockState = CursorLockMode.Locked;
                        playerInputHandler.enabled = true;
                        dialogObj.SetActive(false);
                        active = false;
                        if (currentSender != null)
                        {
                            currentSender.reaction.Invoke();
                            currentSender = null;
                        }
                        //dialogueTextComponent.text = string.Empty;
                    }
                }
            }
            else
            {
                dialogBox.SetActive(false);
                choicesOn = true;

                foreach (Choice choice in lines[index].choices)
                {
                    //GameObject instButton = Instantiate(choiceButtonPrefab);
                    //instButton.GetComponent<Button>().transform.SetParent(choicesObj.transform, false);
                    //instButton.GetComponent<Button>().onClick.AddListener( () => { ChoiceSelected(choice); });
                    //instButton.GetComponentInChildren<TextMeshProUGUI>().text = choice.name;
                }
            }
        }
        else
        {
            dialogBox.SetActive(true);
            /*
            foreach (Transform child in choicesObj.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            */
            //choicesObj.SetActive(false);
            
            //StopAllCoroutines();
            guideTextComponent.text = string.Empty;
            dialogueTextComponent.text = string.Empty;
            StartCoroutine(TypeLine(reply));
            choicesOn = false;
            index++;
        }
    }

    // The coroutine responsible for typing out the guide text after a while, but really is just half-working, no idea why the hell it does not still work
    IEnumerator TypeGuideLine()
    {
        guideTextComponent.text = string.Empty;
        yield return new WaitForSeconds(2);

        foreach (char c in guideText.ToCharArray())
        {
            guideTextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void ChoiceSelected(Choice choice = null)
    {
        if (choice.isBad)
        {
            NextLine(true, choice.reply, true);
        }
        else
        {
            NextLine(true, choice.reply);
        }
    }
}

[System.Serializable]
public class Line
{
    [Header("General settings")]
    public Type type;

    [Header("Line type settings")]
    public string text;
    public Speaker activeSpeaker;
    public float textSpeed = 0.05f;

    [Header("Choice type settings")]
    public List<Choice> choices = new();

    public enum Type
    {
        Line,
        Choices
    }
}

[System.Serializable]
public class Choice
{
    public string name;
    public Line reply;
    public bool isBad;
}