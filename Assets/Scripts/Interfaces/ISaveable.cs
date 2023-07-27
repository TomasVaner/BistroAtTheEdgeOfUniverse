using System;
using Utility;

namespace Interfaces
{
    public interface ISaveable
    {
        public string ID { get; }
        
        SaveState Save();
        void Load(SaveState state);

    }
}