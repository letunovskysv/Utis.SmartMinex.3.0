using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Utis.Minex.Common.Messages
{
    /// <summary>
    /// Фабрика создания IUtisMessager
    /// </summary>
    public static class UtisMessengerFactory
    {
        /// <summary>
        /// Месенджер по умолчанию
        /// </summary>
        public static IUtisMessenger Default { get; set;}

        static UtisMessengerFactory()
        {
            Default = CreateMessager();
        }

        /// <summary>
        /// Создать месенджер
        /// </summary>
        /// <returns></returns>
        public static IUtisMessenger CreateMessager()
        {
            return new UtisMessenger();
        }
    }

    struct SubscribeInfo
    {
        public long Object { get; private set; }
        public Delegate Delegates { get; private set; }

        public SubscribeInfo(long subscribeObject, Delegate subscribeDelegate)
        {
            this.Object = subscribeObject;
            this.Delegates = subscribeDelegate;
        }
    }

    internal class UtisMessenger : IUtisMessenger
    {
        #region Properties

        private ObjectIDGenerator _iDGenerator = new();
        private readonly IDictionary<string, HashSet<SubscribeInfo>> _dict_subscribers;

        #endregion

        #region Events



        #endregion

        #region Constructors

        internal UtisMessenger()
        {
            _dict_subscribers = new Dictionary<string, HashSet<SubscribeInfo>>();            
        }


        #endregion

        #region Methods

        public async Task RequestAsync<T>(string Topic, Action<IEnumerable<T>> ActionSuccess, Action<string> ActionFaulted = null)
        {
            IList<T> req = new List<T>();

            if (!_dict_subscribers.ContainsKey(Topic))
            {
                ActionSuccess(req);
                return;
            }

            await Task.Factory.StartNew<IEnumerable<T>>(() =>
            {
                foreach (var deleg in _dict_subscribers[Topic])
                {
                    var func = deleg.Delegates as Func<T>;
                    if (func == null)
                        continue;

                    var obj = func();
                    if (obj != null)
                        req.Add(obj);
                }

                return req;
            }).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    ActionFaulted?.Invoke(task.Exception.Message);
                }
                else
                {
                    ActionSuccess?.Invoke(task.Result);
                }
            });
        }

        public async Task SendAsync<T>(string Topic, T Message, Action ActionSuccess, Action<string> ActionFaulted = null)
        {
            IList<T> req = new List<T>();

            if (!_dict_subscribers.ContainsKey(Topic))
            {
                ActionSuccess?.Invoke();
                return;
            }

            await Task.Factory.StartNew(() =>
            {
                foreach (var deleg in _dict_subscribers[Topic])
                {
                    var act = deleg.Delegates as Action<T>;
                    act?.Invoke(Message);
                }

            }).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    ActionFaulted?.Invoke(task.Exception.Message);
                }
                else
                {
                    ActionSuccess?.Invoke();
                }
            });
        }

        public void Subscribe<T>(string Topic, object SubscribeObject, Action<T> Action)
        {
            Subcribe<T>(Topic, SubscribeObject, Action);
        }
        public void Subscribe<T>(string Topic, object SubscribeObject, Func<T> Function)
        {
            Subcribe<T>(Topic, SubscribeObject, Function);
        }


        void Subcribe<T>(string Topic, object SubscribeObject, Delegate Delegate)
        {
            if (string.IsNullOrEmpty(Topic) ||
               SubscribeObject == null || Delegate == null)
                return;

            long obj_index = _iDGenerator.GetId(SubscribeObject, out var _);

            var new_subscribe = new SubscribeInfo(obj_index, Delegate);
            if (!_dict_subscribers.ContainsKey(Topic))
            {
                _dict_subscribers.Add(Topic, new() { new_subscribe });
            }
            else
            {
                _dict_subscribers[Topic].Add(new_subscribe);
            }
        }

        public void UnSubscribe(string Topic, object SubscribeObject)
        {
            if (string.IsNullOrEmpty(Topic) ||
            SubscribeObject == null ||
            !_dict_subscribers.ContainsKey(Topic))
                return;

            long obj_index = _iDGenerator.GetId(SubscribeObject, out var _);

            _dict_subscribers[Topic].RemoveWhere(s => s.Object == obj_index);
        }

        public void UnSubscribe(string Topic)
        {
            if (string.IsNullOrEmpty(Topic) ||
                !_dict_subscribers.ContainsKey(Topic))
                return;

            _dict_subscribers.Remove(Topic);
        }

        #endregion
    }
}
    



