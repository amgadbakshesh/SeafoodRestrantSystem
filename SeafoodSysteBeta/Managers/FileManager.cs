using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace SeafoodSysteBeta.Managers
{
    public class FileManager
    {
        public void SaveInvoice(string content)
        {
            File.WriteAllText("invoice.txt", content);
        }
    }
}
