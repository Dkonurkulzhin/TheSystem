using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetworkCommsDotNet;
using System.ComponentModel;
using System.IO;

    public class ReceivedFile : INotifyPropertyChanged
    {
        public string Filename { get; private set; }

        public ConnectionInfo SourceInfo { get; private set; }
        public long SizeBytes { get; private set; }
        public long ReceivedBytes { get; private set; }
        public string RelativeDirectory { get; set; }

        public double CompletedPercent
        {
            get { return (double)ReceivedBytes / SizeBytes; }
            set { throw new Exception("An attempt to modify read-only value."); }
        }

        public string SourceInfoStr
        {
            get { return "[" + SourceInfo.RemoteEndPoint.ToString() + "]"; }
        }

        public bool IsCompleted
        {
            get { return ReceivedBytes == SizeBytes; }
        }

        object SyncRoot = new object();

        Stream data;

        public event PropertyChangedEventHandler PropertyChanged;

        public ReceivedFile(string filename, ConnectionInfo sourceInfo, long sizeBytes, string relativeDirectory = "")
        {
            this.Filename = filename;
            this.SourceInfo = sourceInfo;
            this.SizeBytes = sizeBytes;
            this.RelativeDirectory = relativeDirectory;
            //We create a file on disk so that we can receive large files
            data = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite, FileShare.Read, 8 * 1024, FileOptions.DeleteOnClose);
        }

        public void AddData(long dataStart, int bufferStart, int bufferLength, byte[] buffer)
        {
            lock (SyncRoot)
            {
                data.Seek(dataStart, SeekOrigin.Begin);
                data.Write(buffer, (int)bufferStart, (int)bufferLength);

                ReceivedBytes += (int)(bufferLength - bufferStart);

                //Ensure the data is correctly flushed if we have received everything
                if (ReceivedBytes == SizeBytes)
                    data.Flush();
            }

            NotifyPropertyChanged("CompletedPercent");
            NotifyPropertyChanged("IsCompleted");
        }

        public void SaveFileToDisk(string saveLocation)
        {
            if (ReceivedBytes != SizeBytes)
                throw new Exception("Attempted to save out file before data is complete.");
            
            if (!File.Exists(Filename))
                throw new Exception("The transferred file should have been created within the local application directory. Where has it gone?");

            File.Delete(saveLocation);
            File.Copy(Filename, saveLocation);
        }
        
        public void Close()
        {
            try
            {
                data.Dispose();
            }
            catch (Exception) { }
            try
            {
                data.Close();
            }
            catch (Exception) { }
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

