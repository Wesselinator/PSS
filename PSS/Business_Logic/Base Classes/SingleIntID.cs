using System;
using System.Data;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public abstract class SingleIntID : BaseSingleID<int> //Quality of life
    {
        protected SingleIntID(string tableName, string idColumn) : base(tableName, idColumn)
        {  }

        public void SetNextID()
        {
            ID = GetNextID();
        }

        protected override int GetNextID()
        {
            return base.GetNextIDFor(IDColumn);
        }


        public new static TObject GetDataObject<TObject>(int id) 
            where TObject : SingleIntID, new()
        {
            return BaseSingleID<int>.GetDataObject<TObject>(id);
        }
    }
}
