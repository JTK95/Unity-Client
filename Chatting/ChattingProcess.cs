using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

namespace Client
{
	public class ChattingProcess : MonoBehaviour
	{
		public InputField _inputText;
		public Text _outputText;
        public ScrollRect _scrollView;

        void FixedUpdate()
        {
            if(AllScene._textQueue.Count != 0)
            {
                this.PrintText();
            }
        }

		public void EnterClick()
		{
			// 채팅 데이터 송신
			Client.PK_C_REQ_CHAT_INPUT packet = new Client.PK_C_REQ_CHAT_INPUT();
			packet._roomNumber = AllScene._roomNuber;
			packet._charName = AllScene._name;
			packet._text = _inputText.text;
			Client.NetworkManager.GetInstance.sendPacket(packet);

            // inputfield 비우기
            _inputText.text = string.Empty;
		}

		public void PrintText()
		{
            _outputText.text += AllScene._textQueue.Dequeue() + "\n";
            _scrollView.verticalNormalizedPosition = 0.0f;
		}
	}
}