using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CSFramework3.Interfaces.Interfaces_Bridge
{
    public interface IBridge_AttachFile
    {
        DataTable GetData(string docID);
    }
}
