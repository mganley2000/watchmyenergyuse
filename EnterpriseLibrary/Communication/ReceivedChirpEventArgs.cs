using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Energy.Communication
{
    /// <summary>
    /// Event Arguments for when a chirp is recieved at a port
    /// This is used to communicate this to those that choose to listen
    /// </summary>
    public class ReceivedChirpEventArgs : System.EventArgs
    {
        private chirp m_chirp;

        public ReceivedChirpEventArgs(chirp obj)
        {
            this.m_chirp = obj;
        }

        public chirp Chirp
        {
            get { return m_chirp; }
            set { m_chirp = value; }
        }
    }

}