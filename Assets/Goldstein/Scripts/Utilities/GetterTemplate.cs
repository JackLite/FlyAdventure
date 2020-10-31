using System;

namespace Goldstein.Scripts.Utilities
{
    public class GetterTemplate<T>
    {
        private Func<T> _getter;

        public GetterTemplate()
        {
            _getter = DefaultGetter;
        }
        
        public void SetGetter(Func<T> getter)
        {
            if(_getter != DefaultGetter)
                throw new MemberAccessException($"Поле {nameof(_getter)} уже установлено и не может быть установлено повторно");
            _getter = getter;
        }

        public T Get()
        {
            return _getter.Invoke();
        }

        private T DefaultGetter()
        {
            return default;
        }
    }
}