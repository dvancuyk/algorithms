using System;
using System.Runtime.Serialization;

namespace VisualizingStronglyConnectedClients
{
    [Serializable]
    internal class InvalidFileFormatException : Exception
    {

        public InvalidFileFormatException(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}