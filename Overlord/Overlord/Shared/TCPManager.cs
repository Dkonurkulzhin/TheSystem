using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

namespace Overlord
{
    static class TCPManager
    {
        // State object for receiving data from remote device.  
        public class StateObject
        {
            // Client socket.  
            public Socket workSocket = null;
            // Size of receive buffer.  
            public const int BufferSize = 256;
            // Receive buffer.  
            public byte[] buffer = new byte[BufferSize];
            // Received data string.  
            public StringBuilder sb = new StringBuilder();
        }

        public class AsynchronousClient
        {
            // The port number for the remote device.  
            private const int port = 11000;

            // ManualResetEvent instances signal completion.  
            private static ManualResetEvent connectDone =
                new ManualResetEvent(false);
            private static ManualResetEvent sendDone =
                new ManualResetEvent(false);
            private static ManualResetEvent receiveDone =
                new ManualResetEvent(false);

            // The response from the remote device.  
            private static String response = String.Empty;

            private static void StartClient()
            {
                // Connect to a remote device.  
                try
                {
                    // Establish the remote endpoint for the socket.  
                    // The name of the   
                    // remote device is "host.contoso.com".  
                    IPHostEntry ipHostInfo = Dns.Resolve("host.contoso.com");
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                    // Create a TCP/IP socket.  
                    Socket client = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);

                    // Connect to the remote endpoint.  
                    client.BeginConnect(remoteEP,
                        new AsyncCallback(ConnectCallback), client);
                    connectDone.WaitOne();

                    // Send test data to the remote device.  
                    Send(client, "This is a test<EOF>");
                    sendDone.WaitOne();

                    // Receive the response from the remote device.  
                    Receive(client);
                    receiveDone.WaitOne();

                    // Write the response to the console.  
                    Console.WriteLine("Response received : {0}", response);

                    // Release the socket.  
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void ConnectCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;

                    // Complete the connection.  
                    client.EndConnect(ar);

                    Console.WriteLine("Socket connected to {0}",
                        client.RemoteEndPoint.ToString());

                    // Signal that the connection has been made.  
                    connectDone.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void Receive(Socket client)
            {
                try
                {
                    // Create the state object.  
                    StateObject state = new StateObject();
                    state.workSocket = client;

                    // Begin receiving the data from the remote device.  
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void ReceiveCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the state object and the client socket   
                    // from the asynchronous state object.  
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket client = state.workSocket;

                    // Read data from the remote device.  
                    int bytesRead = client.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.  
                        state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                        // Get the rest of the data.  
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    }
                    else
                    {
                        // All the data has arrived; put it in response.  
                        if (state.sb.Length > 1)
                        {
                            response = state.sb.ToString();
                        }
                        // Signal that all bytes have been received.  
                        receiveDone.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            private static void Send(Socket client, String data)
            {
                // Convert the string data to byte data using ASCII encoding.  
                byte[] byteData = Encoding.ASCII.GetBytes(data);

                // Begin sending the data to the remote device.  
                client.BeginSend(byteData, 0, byteData.Length, 0,
                    new AsyncCallback(SendCallback), client);
            }

            private static void SendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.  
                    Socket client = (Socket)ar.AsyncState;

                    // Complete sending the data to the remote device.  
                    int bytesSent = client.EndSend(ar);
                    Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                    // Signal that all bytes have been sent.  
                    sendDone.Set();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            
        }





        static void FileReceiver(string IP, int port)
        {
            IPAddress clientAddr = IPAddress.Parse(IP);
           // IPAddress localAddr = IPAddress.Parse(IP);
            //Создаем Listener на порт "по умолчанию"
            TcpListener Listen = new TcpListener(clientAddr, port);
            //Начинаем прослушку
            Listen.Start();
            //и заведем заранее сокет
            Socket ReceiveSocket;
            while (true)
            {
                try
                {
                    //Пришло сообщение
                    ReceiveSocket = Listen.AcceptSocket();
                    Byte[] Receive = new Byte[256];
                    //Читать сообщение будем в поток
                    using (MemoryStream MessageR = new MemoryStream())
                    {
                        //Количество считанных байт
                        Int32 ReceivedBytes;
                        Int32 Firest256Bytes = 0;
                        String FilePath = "";
                        do
                        {//Собственно читаем
                            ReceivedBytes = ReceiveSocket.Receive(Receive, Receive.Length, 0);
                            //Разбираем первые 256 байт
                            if (Firest256Bytes < 256)
                            {
                                Firest256Bytes += ReceivedBytes;
                                Byte[] ToStr = Receive;
                                //Учтем, что может возникнуть ситуация, когда они не могу передаться "сразу" все
                                if (Firest256Bytes > 256)
                                {
                                    Int32 Start = Firest256Bytes - ReceivedBytes;
                                    Int32 CountToGet = 256 - Start;
                                    Firest256Bytes = 256;
                                    //В случае если было принято >256 байт (двумя сообщениями к примеру)
                                    //Остаток (до 256 ) записываем в "путь файла"
                                    ToStr = Receive.Take(CountToGet).ToArray();
                                    //А остальную часть - в будующий файл
                                    Receive = Receive.Skip(CountToGet).ToArray();
                                    MessageR.Write(Receive, 0, ReceivedBytes);
                                }
                                //Накапливаем имя файла
                                FilePath += Encoding.Default.GetString(ToStr);
                            }
                            else
                                //и записываем в поток
                                MessageR.Write(Receive, 0, ReceivedBytes);
                            //Читаем до тех пор, пока в очереди не останется данных
                        } while (ReceivedBytes == Receive.Length);
                        //Убираем лишние байты
                        String resFilePath = FilePath.Substring(0, FilePath.IndexOf('\0'));
                        using (var File = new FileStream(resFilePath, FileMode.Create))
                        {//Записываем в файл
                            File.Write(MessageR.ToArray(), 0, MessageR.ToArray().Length);
                        }//Уведомим пользователя
                        
                    }
                }
                catch (System.Exception ex)
                {
                    
                }
            }
        }

        static void FileSender(string IP, int port, OpenFileDialog FileDialog)
        {
            IPAddress serverAddr = IPAddress.Parse(IP);
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                //Коннектимся
                IPEndPoint EndPoint = new IPEndPoint(serverAddr, port);
                Socket Connector = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                Connector.Connect(EndPoint);
                //Получаем имя из полного пути к файлу
                StringBuilder FileName = new StringBuilder(FileDialog.FileName);
                //Выделяем имя файла
                int index = FileName.Length - 1;
                while (FileName[index] != '\\' && FileName[index] != '/' )
                {
                    index--;
                }
                //Получаем имя файла
                String resFileName = "";
                for (int i = index + 1; i < FileName.Length; i++)
                    resFileName += FileName[i];
                //Записываем в лист 
                List<Byte> First256Bytes = Encoding.Default.GetBytes(resFileName).ToList();
                Int32 Diff = 256 - First256Bytes.Count;
                //Остаток заполняем нулями
                for (int i = 0; i < Diff; i++)
                    First256Bytes.Add(0);
                //Начинаем отправку данных
                Byte[] ReadedBytes = new Byte[256];
                using (var FileStream = new FileStream(FileDialog.FileName, FileMode.Open))
                {
                    using (var Reader = new BinaryReader(FileStream))
                    {
                        Int32 CurrentReadedBytesCount;
                        //Вначале отправим название файла
                        Connector.Send(First256Bytes.ToArray());
                        do
                        {
                            //Затем по частям - файл
                            CurrentReadedBytesCount = Reader.Read(ReadedBytes, 0, ReadedBytes.Length);
                            Connector.Send(ReadedBytes, CurrentReadedBytesCount, SocketFlags.None);
                        }
                        while (CurrentReadedBytesCount == ReadedBytes.Length);
                    }
                }
                //Завершаем передачу данных
                Connector.Close();
            }
        }

    }
}
