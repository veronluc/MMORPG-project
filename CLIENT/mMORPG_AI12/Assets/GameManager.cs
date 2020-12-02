using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AI12_DataObjects;

public class GameManager : MonoBehaviour
{
    public DataInterfaceForIHMGame dataInterface { get; set; }

    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    public Color playerMessage, info;

    [SerializeField]
    List<ChatMessage> messageList = new List<ChatMessage>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chatBox.text != "")
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToServer(chatBox.text);
                chatBox.text = "";
                chatBox.DeactivateInputField();
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }        
    }

    /// <summary>
    /// Encapsulates chat message into Message object and sends it to the DataInterfaceForIHMGame
    /// </summary>
    public void SendMessageToServer(string text)
    {
        //Message message = new Message(dataInterface.GetCurrentWorld().id, dataInterface.GetCurrentUser().id, text, System.DateTime.Now);
        Message message = new Message("testWorld", "testUser", text, System.DateTime.Now);
        //dataInterface.SendMessage(message);
        SendMessageToChat(message, ChatMessage.MessageType.playerMessage);
    }

    /// <summary>
    /// Extracts message creator and text and prints it into the chatbox
    /// </summary>
    public void SendMessageToChat(Message message, ChatMessage.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);

        }
        ChatMessage newMessage = new ChatMessage();

        newMessage.text = "[" + message.creatorId + "] " + message.text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    /// <summary>
    /// Defines chat message colors
    /// </summary>
    Color MessageTypeColor(ChatMessage.MessageType messageType)
    {
        Color color = info;
        switch (messageType)
        {
            case ChatMessage.MessageType.playerMessage:
                color = playerMessage;
                break;
        }
        return color;
    }
}


/// <summary>
/// Object used to display messages into the chatbox
/// </summary>
[System.Serializable]
public class ChatMessage
{
    public string text;
    public Text textObject;
    public MessageType messageType;
    
    public enum MessageType
    {
        playerMessage, 
        info
    }
}