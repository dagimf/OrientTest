using System;

namespace OrientTest
{
    public class OrientContext : IDisposable
    {
        public OrientContext()
        {
            //OrientConnection.CreateTestDatabase();
            OrientConnection.CreatePool();
        }
        public void Dispose()
        {
            OrientConnection.DropPool();
            //OrientConnection.DropTestDatabase();
        }
    }
}
