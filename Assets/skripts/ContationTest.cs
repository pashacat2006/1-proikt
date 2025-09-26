using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContationTest : MonoBehaviour
{
    [SerializeField] private NPCConversation MyCorvation;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                print("cat");
                ConversationManager.Instance.StartConversation(MyCorvation);
            }
        }
    }
}
