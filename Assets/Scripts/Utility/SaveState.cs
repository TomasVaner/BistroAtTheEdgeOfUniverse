using System;

namespace Utility
{
    [Serializable]
    public class SaveState
    {
        public string Id;
        public object State;

        public SaveState(string id, object state)
        {
            Id = id;
            State = state;
        }
    }
}