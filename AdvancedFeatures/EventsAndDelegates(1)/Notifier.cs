namespace EventsAndDelegates
{
    /// <summary>
    /// Event Notifier Class
    /// </summary>
    internal class Notifier
    {
        public delegate void Notify(string message);
        public event Notify? OnAction;

        /// <summary>
        /// To invoke the event
        /// </summary>
        /// <param name="message">Parameter to be passed to the methods</param>
        public void TriggerEvent(string message)
        {
            OnAction?.Invoke(message);
        }
    }
}
