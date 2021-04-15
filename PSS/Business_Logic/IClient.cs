using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSS.Business_Logic.DataBaseThings;

namespace PSS.Business_Logic
{
    //stupid C# 
    //can't have covarient objects in C#
    public interface IClient
    {
        int ClientID { get; set; }
    }
}
