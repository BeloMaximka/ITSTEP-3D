using Assets.Scripts;
using Assets.Scripts.Models;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToastScript : MonoBehaviour
{
    private GameObject content;
    private TextMeshProUGUI message;

    void Start()
    {
        content = transform.Find("Content").gameObject;
        message = content.transform.Find("Message").GetComponent<TextMeshProUGUI>();

        GameState.KeyPicked += ShowKeyToast;
        content.SetActive(false);
    }

    private void ShowKeyToast(KeyInteractionPayload payload)
    {
        StringBuilder stringBuilder = new($"Key {payload.Name} has been picked up.\n");
        stringBuilder.Append(GameState.CollectedKeys[payload.Name].IsStale ? "Key is stale" : "Key is fresh");
        StartCoroutine(ShowToast(3f, stringBuilder.ToString()));
    }

    private IEnumerator ShowToast(float delay, string message)
    {
        content.SetActive(true);
        this.message.text = message;
        yield return new WaitForSeconds(delay);
        content.SetActive(false);
    }
}
