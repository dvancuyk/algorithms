using System;
using System.Collections.Generic;

namespace Commons
{
    public static class DomainEvents
    {
        [ThreadStatic]
        public static List<Delegate> _handlers;

        public static void Raise<T>(T events)
            where T : IDomainEvent
        {
            if (_handlers == null)
                return;

            foreach (var handler in _handlers)
            {
                if (handler is Action<T>)
                    ((Action<T>)handler)(events);
            }
        }

        public static void Register<T>(Action<T> actions)
            where T : IDomainEvent
        {
            if (_handlers == null)
                _handlers = new List<Delegate>();

            _handlers.Add(actions);
        }
    }
}
