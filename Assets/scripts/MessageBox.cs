using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    [SerializeField]
    [Header("Message to be displayed")]
    private string m_Message;

    public string getMessage ()
    {
        return m_Message;
    }

    public void setMessage (string message)
    {
        m_Message = message;
    }
}
