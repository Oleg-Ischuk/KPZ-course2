using System;
using System.Collections.Generic;

namespace SingletonDemo.Services
{
    public sealed class Authenticator
    {
        private static readonly object _lock = new object();
        private static Authenticator? _instance;
        private readonly HashSet<string> _activeSessions = new();

        private Authenticator()
        {
            Console.WriteLine("\n🔒 Ініціалізовано автентифікатор");
        }

        public static Authenticator Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Authenticator();
                        }
                    }
                }
                return _instance;
            }
        }

        public bool Authenticate(string userId, string password)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("❌ UserId та пароль не можуть бути порожніми");
            }

            _activeSessions.Add(userId);
            Console.WriteLine($"✅ Користувач {userId} успішно автентифіковано");
            return true;
        }

        public bool IsSessionActive(string userId)
        {
            return _activeSessions.Contains(userId);
        }

        public void Logout(string userId)
        {
            if (_activeSessions.Remove(userId))
            {
                Console.WriteLine($"🚪 Користувач {userId} успішно вийшов з системи");
            }
        }
    }
}