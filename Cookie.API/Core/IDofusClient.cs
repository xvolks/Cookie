using System;
using Cookie.API.Protocol;
using Cookie.Core;

namespace Cookie.API.Core
{
    public interface IDofusClient
    {
        /// <summary>
        ///     The account belongs to the client
        /// </summary>
        IAccount Account { get; set; }

        /// <summary>
        ///     Debug mode for listing all incoming/outgoing packets
        /// </summary>
        bool Debug { get; set; }

        /// <summary>
        ///     Use this methods for register handlers
        /// </summary>
        /// <param name="type"></param>
        void Register(Type type);

        /// <summary>
        ///     This method send a packet to the server
        /// </summary>
        /// <param name="message"></param>
        void Send(NetworkMessage message);

        /// <summary>
        ///     This method is used to log text on the GUI
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        void Log(string text, LogMessageType type = LogMessageType.Default);
    }
}