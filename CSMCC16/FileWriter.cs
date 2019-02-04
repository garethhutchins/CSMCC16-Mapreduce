using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSMCC16
{
    public class FileWriter
    {
        private static ReaderWriterLockSlim lock_ = new ReaderWriterLockSlim();
        public void WriteData(string WriteData, string filePath)
        {
            lock_.EnterWriteLock();
            try
            {
                using (var fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    using (var fw = new StreamWriter(fs)) {
                        fw.WriteLine(WriteData);
}
                    
                }
            }
            finally
            {
                lock_.ExitWriteLock();
            }
        }
    }
}
