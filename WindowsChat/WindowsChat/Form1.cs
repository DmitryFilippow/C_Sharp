using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsChat
{
    public partial class LocalChatForm : Form
    {
        public LocalChatForm()
        {
            InitializeComponent();
            new Thread(new ThreadStart(Receiver)).Start();            
        }
        public Socket ReceiveSocket;
        public void Receiver()
        {
            TcpListener Listen=new TcpListener(7000);
            //TcpListener Listen=new TcpListener(IPAddress.Parse(IP.Text),7000);
            
            Listen.Start();
            
            
                while (true)
                {
                    try
                    {

                        ReceiveSocket = Listen.AcceptSocket();
                        
                            byte[] Receive = new byte[256];
                            using (MemoryStream MessageR = new MemoryStream())
                            {
                                Int32 ReceivedBytes;
                                do
                                {
                                    ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                                    MessageR.Write(Receive, 0, ReceivedBytes);
                                } while (ReceiveSocket.Available > 0);
                                ChatBox.BeginInvoke(AcceptDelegate,
                                                    new object[]
                                                        {
                                                            "Received " + Encoding.Default.GetString(MessageR.ToArray())
                                                            ,
                                                            ChatBox
                                                        });
                            }
                        
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            
        }
        public void SendMsgButton_Click(object sender, EventArgs e)
        {
            SendDatas();
        }

        public void SendDatas()
        {
            new Thread(new ParameterizedThreadStart(ThreadSend)).Start(Message.Text);
            Message.Clear();
        }

        public void ThreadSend(object Message)
        {
            try
            {
                String MessageText = "";
                if (Message is string)
                    MessageText = Message as string;
                else throw new Exception("Нужен текст, а не хрен знает что!");
                IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IP.Text), 7000);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                Byte[] SendBytes = Encoding.Default.GetBytes(MessageText);
                Connector.Send(SendBytes);
                Connector.Close();
                ChatBox.BeginInvoke(AcceptDelegate, new object[] {"Send " + MessageText, ChatBox});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        delegate void SendMsg(String Text, RichTextBox Rtb);

        SendMsg AcceptDelegate = (String Text, RichTextBox Rtb) => { Rtb.Text += Text+"\n"; };

        private void LocalChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ReceiveSocket!=null) ReceiveSocket.Close();
            Environment.Exit(0);
        }

        private void Message_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (decimal) (Keys.Enter))
            {
                SendDatas();
            }
            
        }

    }
}

