﻿using System;

namespace EPII
{
    public abstract class ObjectEx : IDisposable
    {
        protected bool _Disposed = false;

        ~ObjectEx()
        {
            if (_Disposed)
                return;
            DisposeNative();
            _Disposed = true;
        }

        protected abstract void DisposeManaged();

        protected abstract void DisposeNative();

        public void Dispose()
        {
            if (_Disposed)
                return;
            DisposeManaged();
            DisposeNative();
            _Disposed = true;
            GC.SuppressFinalize(this);
        }
    }
}