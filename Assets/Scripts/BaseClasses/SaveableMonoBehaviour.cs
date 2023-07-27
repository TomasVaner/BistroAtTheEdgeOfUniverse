/*
 * Copyright (c) Tomas Vaner
 * https://github.com/TomasVaner
*/

using System;
using Interfaces;
using Utility;

namespace BaseClasses
{
    public abstract class SaveableMonoBehaviour : MonoBehaviourId, ISaveable
    {
        public SaveState Save()
        {
            return new SaveState(ID, GetSaveState());
        }

        public abstract object GetSaveState();

        public void Load(SaveState state)
        {
            if (!(state is null) && state.Id == ID)
                SetSaveState(state.State);
        }
        
        public abstract void SetSaveState(object state);
    }
}