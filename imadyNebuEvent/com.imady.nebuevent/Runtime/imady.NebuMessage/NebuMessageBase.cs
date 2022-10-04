using System;

namespace imady.NebuEvent
{
    public class NebuMessageBase : IDisposable
    {
        public DateTime timeSend { get; set; }

        public Guid senderId { get; set; }

        public string senderName { get; set; }


        public NebuMessageBase()
        {
            timeSend = DateTime.Now;
        }
        public NebuMessageBase(Guid userId) : this()
        {
            senderId = userId;
        }
        public NebuMessageBase(string userName) : this()
        {
            senderName = userName;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Release managed resources
                }
                // Release unmanaged resources
                // TODO：这里只释放了imadyEvent.Message对象，而没有释放T（messageBody）。需要为T类都实现IDisposable。

                m_disposed = true;
            }
        }

        ~NebuMessageBase()
        {
            Dispose(false);
        }

        private bool m_disposed;
    }
}

