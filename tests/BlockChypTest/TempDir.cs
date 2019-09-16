using System;
using System.IO;

namespace BlockChypTest
{
    public sealed class TempDir : IDisposable
    {
        public TempDir() : this("blockchyp-test")
        {
        }

        public TempDir(string prefix)
        {
            Name = Path.Combine(Path.GetTempPath(), prefix + Guid.NewGuid().ToString());
            Directory.CreateDirectory(Name);
        }

        public string Name { get; private set; }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                Directory.Delete(Name, true);
            }

            disposed = true;
        }
    }
}