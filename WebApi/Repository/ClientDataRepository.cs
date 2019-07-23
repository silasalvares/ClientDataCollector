using webapi.Models;

namespace webapi.Repository 
{
    public class ClientDataRepository
    {
        private DB_Context db;

        public ClientDataRepository(DB_Context _db)
        {
            db = _db;
        }

        public void Add(ClientData _ClientData)
        {
            db.ClientData.Add(_ClientData);
            db.SaveChanges();
        }
    }
}