using Newtonsoft.Json;
using Supabase;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

namespace tMS.Helper
{
    internal class SupabaseSessionHandler : IGotrueSessionPersistence<Session>
    {
        private static readonly string PREF_KEY = "SupabaseSession";

        private Session? session;

        void IGotrueSessionPersistence<Session>.DestroySession()
        {
            session = null;
            Preferences.Remove(PREF_KEY);
        }

        Session? IGotrueSessionPersistence<Session>.LoadSession()
        {
            if (session == null)
            {
                if (Preferences.ContainsKey(PREF_KEY))
                {
                    session = JsonConvert.DeserializeObject<Session>(Preferences.Get(PREF_KEY, null));
                }
            }
            return session;
        }

        void IGotrueSessionPersistence<Session>.SaveSession(Session _session)
        {
            session = _session;
            Preferences.Set(PREF_KEY, JsonConvert.SerializeObject(_session));
        }
    }
}