using Google.Protobuf;
using System.Timers;

namespace Style_Forge_Grpc.Service.Modules
{
    internal abstract class GrpcConnectionHandler
    {
        private System.Timers.Timer _KeepAliveTimer = new System.Timers.Timer(500);
        private DateTime m_LastTransactionSent;

        private int m_MaxRetries = 10;
        private int m_Retries = 0;
        private int m_RetryInterval = 3000;
        private bool b_IsConnected = false;

        public bool IsConnected { get { return b_IsConnected; } set { b_IsConnected = value; } }
        public DateTime LastTransactionSent { get { return m_LastTransactionSent; } set { m_LastTransactionSent = value; } }
        public int MaxRetries { set { m_MaxRetries = value; }  get { return m_MaxRetries; } }
        public int RetryInterval { set { m_RetryInterval = value; } get { return m_RetryInterval; } }

        public abstract void Reconnecting(AutoReconnectArgs value);
        public abstract void Connected();
        public abstract void TriggerKeepAlive();
        public abstract void AttemptsExceeded();
        public abstract void TryReconnect(IMessage message);

        public event EventHandler? StartingTransaction;
        public event EventHandler<string>? FailedTransaction;

        public GrpcConnectionHandler()
        {
            _KeepAliveTimer.Elapsed += _KeepAliveTimer_Elapsed;
        }

        public void StartTimer()
        {
            _KeepAliveTimer.Start();
        }

        public void NotifyTransactionStarting()
        {
            StartingTransaction?.Invoke(this, EventArgs.Empty);
        }

        public void NotifyTransactionFailed(string reason)
        {
            FailedTransaction?.Invoke(this, reason);
        }

        public async void Reconnect(IMessage orig_message)
        {
            if (m_Retries == -1)
            {
                ResetReconnect();
            }

            m_Retries++;

            if (m_Retries > 0 && m_Retries <= m_MaxRetries)
            {
                Console.WriteLine(">> [Reconnect Attempt #" + m_Retries + " out of " + m_MaxRetries + " Attempts]");

                Reconnecting(new AutoReconnectArgs(m_Retries, m_MaxRetries));
                await Task.Delay(m_RetryInterval); //default 3 seconds
                TryReconnect(orig_message);
            }
            else
            {
                Console.WriteLine(">> [Reconnect Attempts Maxed Out, Assuming Lost Connection to Server! Stopped Auto Reconnect.]");
                b_IsConnected = false;
                FailedTransaction?.Invoke(this, "Server Lost, Stopped Auto Reconnect.");
                AttemptsExceeded();
            }
        }

        public void ResetReconnect()
        {
            Console.WriteLine(">> [Auto Reconnect Cancelled.]");
            m_Retries = 0;
        }

        public void CancelReconnect()
        {
            Console.WriteLine(">> [Cancelling Auto Reconnect...]");
            m_Retries = -1;
        }

        private async void _KeepAliveTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            if (DateTime.UtcNow >= m_LastTransactionSent.AddSeconds(15))
            {
                //Console.WriteLine(">> [Sending KeepAlive...]");
                TriggerKeepAlive();
            }
        }
    }

    public class AutoReconnectArgs : EventArgs
    {
        private int _retryCount;
        private int _maxRetries;

        public AutoReconnectArgs(int retryCount, int maxRetries)
        {
            _retryCount = retryCount;
            _maxRetries = maxRetries;
        }

        public int RetryCount { get { return _retryCount; } }
        public int MaxRetries { get { return _maxRetries; } }
    }
}
