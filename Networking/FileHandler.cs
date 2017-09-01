using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using NetworkCommsDotNet;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet.DPSBase.SevenZipLZMACompressor;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using ProtoBuf;

namespace Networking
{
    public class FileHandler
    {

        #region Private Fields
        /// <summary>
        /// Data context for the GUI list box
        /// </summary>
        ObservableCollection<ReceivedFile> receivedFiles = new ObservableCollection<ReceivedFile>();

        /// <summary>
        /// References to received files by remote ConnectionInfo
        /// </summary>
        Dictionary<ConnectionInfo, Dictionary<string, ReceivedFile>> receivedFilesDict = new Dictionary<ConnectionInfo, Dictionary<string, ReceivedFile>>();

        /// <summary>
        /// Incoming partial data cache. Keys are ConnectionInfo, PacketSequenceNumber. Value is partial packet data.
        /// </summary>
        Dictionary<ConnectionInfo, Dictionary<long, byte[]>> incomingDataCache = new Dictionary<ConnectionInfo, Dictionary<long, byte[]>>();

        /// <summary>
        /// Incoming sendInfo cache. Keys are ConnectionInfo, PacketSequenceNumber. Value is sendInfo.
        /// </summary>
        Dictionary<ConnectionInfo, Dictionary<long, SendInfo>> incomingDataInfoCache = new Dictionary<ConnectionInfo, Dictionary<long, SendInfo>>();

        /// <summary>
        /// Custom sendReceiveOptions used for sending files. Can be changed via GUI.
        /// </summary>

        SendReceiveOptions customOptions = new SendReceiveOptions<ProtobufSerializer>();

        /// <summary>
        /// Object used for ensuring thread safety.
        /// </summary>
        object syncRoot = new object();
        Task[] tasks;
        /// <summary>
        /// Boolean used for suppressing errors during GUI close
        /// </summary>
        static volatile bool windowClosing = false;
        #endregion

        public delegate void UpdateLogEH(string message);
        public delegate void UpdatePercentEH(double percent);
        public delegate void ConnectionEstablishedEH();
        public delegate void TransitionCompletedEH();

        public event UpdateLogEH UpdateLog;
        public event UpdateLogEH UpdateStatus;
        public event UpdatePercentEH UpdatePercent;
        public event ConnectionEstablishedEH ConnectionEstablished;
        public event TransitionCompletedEH TransitionCompleted;

        private ConnectionInfo remoteInfo;

        public FileHandler()
        {
            UpdateLog = null;
            UpdateStatus = null;
            UpdatePercent = null;
            ConnectionEstablished = null;
            TransitionCompleted = null;
        }

        public void StartListening()
        {
            //Trigger IncomingPartialFileData method if we receive a packet of type 'PartialFileData'
            NetworkComms.AppendGlobalIncomingPacketHandler<byte[]>("PartialFileData", IncomingPartialFileData);
            //Trigger IncomingPartialFileDataInfo method if we receive a packet of type 'PartialFileDataInfo'
            NetworkComms.AppendGlobalIncomingPacketHandler<SendInfo>("PartialFileDataInfo", IncomingPartialFileDataInfo);
            NetworkComms.AppendGlobalIncomingPacketHandler<bool>("FileDataCompleted", RecievengCompleted);
            //Trigger the method OnConnectionClose so that we can do some clean-up
            NetworkComms.AppendGlobalConnectionCloseHandler(OnConnectionClose);

            //Start listening for TCP connections
            //We want to select a random port on all available adaptors so provide 
            //an IPEndPoint using IPAddress.Any and port 0.
            Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, 0));

            //Write out some useful debugging information the log window
            UpdateLog("Initialised WPF file transfer example. Accepting TCP connections on:");
            foreach (IPEndPoint listenEndPoint in Connection.ExistingLocalListenEndPoints(ConnectionType.TCP))
            {
                Console.WriteLine(listenEndPoint.Address + ":" + listenEndPoint.Port);
                UpdateLog(listenEndPoint.Address + ":" + listenEndPoint.Port);
            }
            //UpdateStatus("Подключение к серверу");
        }

        public void RecievengCompleted(PacketHeader header, Connection connection, bool Complete)
        {
            UpdateStatus("Обновление завершено");
            TransitionCompleted();
        }

        public void IncomingPartialFileData(PacketHeader header, Connection connection, byte[] data)
        {
            
            try
            {
                SendInfo info = null;
                ReceivedFile file = null;

                //Perform this in a thread safe way
                lock (syncRoot)
                {
                    //Extract the packet sequence number from the header
                    //The header can also user defined parameters
                    long sequenceNumber = header.GetOption(PacketHeaderLongItems.PacketSequenceNumber);
                    ConnectionEstablished();
                    UpdateStatus("Получение обновлений...");
                    if (incomingDataInfoCache.ContainsKey(connection.ConnectionInfo) && incomingDataInfoCache[connection.ConnectionInfo].ContainsKey(sequenceNumber))
                    {
                        //We have the associated SendInfo so we can add this data directly to the file
                        info = incomingDataInfoCache[connection.ConnectionInfo][sequenceNumber];
                        incomingDataInfoCache[connection.ConnectionInfo].Remove(sequenceNumber);

                        //Check to see if we have already received any files from this location
                        if (!receivedFilesDict.ContainsKey(connection.ConnectionInfo))
                            receivedFilesDict.Add(connection.ConnectionInfo, new Dictionary<string, ReceivedFile>());

                        //Check to see if we have already initialised this file
                        if (!receivedFilesDict[connection.ConnectionInfo].ContainsKey(info.Filename))
                        {
                            receivedFilesDict[connection.ConnectionInfo].Add(info.Filename, new ReceivedFile(info.Filename, connection.ConnectionInfo, info.TotalBytes));
                            // AddNewReceivedItem(receivedFilesDict[connection.ConnectionInfo][info.Filename]);
                        }

                        file = receivedFilesDict[connection.ConnectionInfo][info.Filename];

                        Console.WriteLine(file.CompletedPercent);
                    }
                    else
                    {
                        //We do not yet have the associated SendInfo so we just add the data to the cache
                        if (!incomingDataCache.ContainsKey(connection.ConnectionInfo))
                            incomingDataCache.Add(connection.ConnectionInfo, new Dictionary<long, byte[]>());

                        incomingDataCache[connection.ConnectionInfo].Add(sequenceNumber, data);
                    }
                    //SaveAllRecievedFiles();
                }

                //If we have everything we need we can add data to the ReceivedFile
                if (info != null && file != null && !file.IsCompleted)
                {
                    file.AddData(info.BytesStart, 0, data.Length, data);

                    //Perform a little clean-up
                    file = null;
                    data = null;
                    GC.Collect();
                }
                else if (info == null ^ file == null)
                    throw new Exception("Either both are null or both are set. Info is " + (info == null ? "null." : "set.") + " File is " + (file == null ? "null." : "set.") + " File is " + (file.IsCompleted ? "completed." : "not completed."));
            }
            catch (Exception ex)
            {
                //If an exception occurs we write to the log window and also create an error file
                UpdateLog("Exception - " + ex.ToString());
                UpdateStatus("Ошибка обновления");
                LogTools.LogException(ex, "IncomingPartialFileDataError");
            }
        }

        public void IncomingPartialFileDataInfo(PacketHeader header, Connection connection, SendInfo info)
        {
            try
            {
                byte[] data = null;
                ReceivedFile file = null;

                //Perform this in a thread safe way
                lock (syncRoot)
                {
                    //Extract the packet sequence number from the header
                    //The header can also user defined parameters
                    long sequenceNumber = info.PacketSequenceNumber;

                    if (incomingDataCache.ContainsKey(connection.ConnectionInfo) && incomingDataCache[connection.ConnectionInfo].ContainsKey(sequenceNumber))
                    {
                        //We already have the associated data in the cache
                        data = incomingDataCache[connection.ConnectionInfo][sequenceNumber];
                        incomingDataCache[connection.ConnectionInfo].Remove(sequenceNumber);
                        //UpdateStatus("Получение обновлений");
                        //Check to see if we have already received any files from this location
                        if (!receivedFilesDict.ContainsKey(connection.ConnectionInfo))
                            receivedFilesDict.Add(connection.ConnectionInfo, new Dictionary<string, ReceivedFile>());

                        //Check to see if we have already initialised this file
                        if (!receivedFilesDict[connection.ConnectionInfo].ContainsKey(info.Filename))
                        {
                            receivedFilesDict[connection.ConnectionInfo].Add(info.Filename, new ReceivedFile(info.Filename, connection.ConnectionInfo, info.TotalBytes));
                            AddNewReceivedItem(receivedFilesDict[connection.ConnectionInfo][info.Filename]);
                        }

                        file = receivedFilesDict[connection.ConnectionInfo][info.Filename];
                    }
                    else
                    {
                        //We do not yet have the necessary data corresponding with this SendInfo so we add the
                        //info to the cache
                        if (!incomingDataInfoCache.ContainsKey(connection.ConnectionInfo))
                            incomingDataInfoCache.Add(connection.ConnectionInfo, new Dictionary<long, SendInfo>());

                        incomingDataInfoCache[connection.ConnectionInfo].Add(sequenceNumber, info);
                    }
                }

                //If we have everything we need we can add data to the ReceivedFile
                if (data != null && file != null && !file.IsCompleted)
                {
                    file.AddData(info.BytesStart, 0, data.Length, data);

                    //Perform a little clean-up

                    file = null;
                    data = null;
                    GC.Collect();
                }
                else if (data == null ^ file == null)
                    throw new Exception("Either both are null or both are set. Data is " + (data == null ? "null." : "set.") + " File is " + (file == null ? "null." : "set.") + " File is " + (file.IsCompleted ? "completed." : "not completed."));
            }
            catch (Exception ex)
            {
                //If an exception occurs we write to the log window and also create an error file
                UpdateLog("Exception - " + ex.ToString());
                LogTools.LogException(ex, "IncomingPartialFileDataInfo");
            }
        }

        public void OnConnectionClose(Connection conn)
        {
            ReceivedFile[] filesToRemove = null;
            
            lock (syncRoot)
            {
                //Remove any associated data from the caches
                incomingDataCache.Remove(conn.ConnectionInfo);
                incomingDataInfoCache.Remove(conn.ConnectionInfo);

                //Remove any non completed files
                if (receivedFilesDict.ContainsKey(conn.ConnectionInfo))
                {
                    filesToRemove = (from current in receivedFilesDict[conn.ConnectionInfo] where !current.Value.IsCompleted select current.Value).ToArray();
                    receivedFilesDict[conn.ConnectionInfo] = (from current in receivedFilesDict[conn.ConnectionInfo] where current.Value.IsCompleted select current).ToDictionary(entry => entry.Key, entry => entry.Value);
                }
            }
          

            //Update the GUI
            //Write some useful information the log window
            //AddLineToLog("Connection closed with " + conn.ConnectionInfo.ToString());
        }

        public void AddNewReceivedItem(ReceivedFile file)
        {
            //Use dispatcher incase method is not called from GUI thread
            
                receivedFiles.Add(file);
            
        }

        public void SaveAllRecievedFiles()
        {
            foreach (ReceivedFile file in receivedFiles)
            {
                file.SaveFileToDisk(AppDomain.CurrentDomain.BaseDirectory + @"\" + file.Filename);
                Console.WriteLine("Saving file: " + file.Filename);
            }
        }

        public void SendFiles(List<string> filenames, string remoteIP, string remotePort)
        {
            Task.Factory.StartNew(() =>
            {
                //Parse the remote connectionInfo
                //We have this in a separate try catch so that we can write a clear message to the log window
                //if there are problems

                try
                {
                    remoteInfo = new ConnectionInfo(remoteIP, int.Parse(remotePort));
                    UpdateLog("Connected");
                }
                catch (Exception)
                {
                    //AddLineToLog("Failed to parse remote IP and port. Check and try again.");
                    throw new InvalidDataException("Failed to parse remote IP and port. Check and try again.");

                }

                //Get a connection to the remote side
                Connection connection = TCPConnection.GetConnection(remoteInfo);

                foreach (string filename in filenames)
                {
                    
                    try
                    {
                        //Create a fileStream from the selected file
                        FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                        //Wrap the fileStream in a threadSafeStream so that future operations are thread safe
                        StreamTools.ThreadSafeStream safeStream = new StreamTools.ThreadSafeStream(stream);

                        //Get the filename without the associated path information
                        string shortFileName = System.IO.Path.GetFileName(filename);

                        
                        //Break the send into 20 segments. The less segments the less overhead 
                        //but we still want the progress bar to update in sensible steps
                        long sendChunkSizeBytes = (long)(stream.Length / 20.0) + 1;

                        //Limit send chunk size to 500MB
                        long maxChunkSizeBytes = 500L * 1024L * 1024L;
                        if (sendChunkSizeBytes > maxChunkSizeBytes) sendChunkSizeBytes = maxChunkSizeBytes;

                        long totalBytesSent = 0;
                        do
                        {
                            //Check the number of bytes to send as the last one may be smaller
                            long bytesToSend = (totalBytesSent + sendChunkSizeBytes < stream.Length ? sendChunkSizeBytes : stream.Length - totalBytesSent);

                            //Wrap the threadSafeStream in a StreamSendWrapper so that we can get NetworkComms.Net
                            //to only send part of the stream.
                            StreamTools.StreamSendWrapper streamWrapper = new StreamTools.StreamSendWrapper(safeStream, totalBytesSent, bytesToSend);

                            //We want to record the packetSequenceNumber
                            long packetSequenceNumber;
                            //Send the select data
                            connection.SendObject("PartialFileData", streamWrapper, customOptions, out packetSequenceNumber);
                            //Send the associated SendInfo for this send so that the remote can correctly rebuild the data
                            connection.SendObject("PartialFileDataInfo", new SendInfo(shortFileName, stream.Length, totalBytesSent, packetSequenceNumber), customOptions);

                            totalBytesSent += bytesToSend;

                            //Update the GUI with our send progress
                            // UpdateSendProgress((double)totalBytesSent / stream.Length);
                        } while (totalBytesSent < stream.Length);

                        //Clean up any unused memory
                        GC.Collect();

                        //AddLineToLog("Completed file send to '" + connection.ConnectionInfo.ToString() + "'.");
                    }
                    catch (CommunicationException)
                    {
                        //If there is a communication exception then we just write a connection
                        //closed message to the log window
                        // AddLineToLog("Failed to complete send as connection was closed.");
                    }
                    catch (Exception ex)
                    {
                        //If we get any other exception which is not an InvalidDataException
                        //we log the error
                        if (!windowClosing && ex.GetType() != typeof(InvalidDataException))
                        {
                            //AddLineToLog(ex.Message.ToString());
                            LogTools.LogException(ex, "SendFileError");
                        }
                    }
                }

                //Once the send is finished reset the send progress bar
                //UpdateSendProgress(0);

                //Once complete enable the send button again
              
            });
        }

        //public void SendFiles(List<string> files, string remoteIP, string remotePort)
        //{
        //    tasks = null;
        //    tasks = new Task[files.Count];
        //    int i = 0;
        //    foreach (string file in files)
        //    {
        //        SendFile(file, remoteIP, remotePort, i);
        //        i++;
        //    }
        //    Task.Factory.ContinueWhenAll(tasks, completedTasks => {
        //        Connection connection = TCPConnection.GetConnection(remoteInfo);
        //        connection.SendObject("FileDataCompleted");
        //        UpdateStatus("Обновление получено");
        //    });
        //}
    }
}
