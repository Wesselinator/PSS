using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PSS.Data_Access;

namespace PSS.Business_Logic
{
    public class CallChangeAssociation : SingleIntID
    {
        public int CallChangeAssociationID { get => ID; private set => ID = value; }
        public Call CallInstanceID { get; set; }
        public string fTableName { get; set; }
        public string TableRecordID { get; set; }

        private static readonly string tableName = "CallChangeAssociation";
        private static readonly string idColumn = "CallChangeAssociationID";

        public CallChangeAssociation() : base(tableName, idColumn) 
        { }

        public CallChangeAssociation(int callChangeAssociationID, Call callInstanceID, string fTableName, string tableRecordID) : this()
        {
            this.CallChangeAssociationID = callChangeAssociationID;
            this.CallInstanceID = callInstanceID;
            this.fTableName = fTableName;
            this.TableRecordID = tableRecordID;
        }

        public CallChangeAssociation(Call callInstanceID, string fTableName, string tableRecordID) : this()
        {
            this.CallChangeAssociationID = base.GetNextID();
            this.CallInstanceID = callInstanceID;
            this.fTableName = fTableName;
            this.TableRecordID = tableRecordID;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.CallChangeAssociationID = row.Field<int>(idColumn);
            this.CallInstanceID = DataEngine.GetDataObject<Call>(row.Field<int>("CallInstanceID"));
            this.fTableName = row.Field<string>("TableName");
            this.TableRecordID = row.Field<string>("TableRecordID");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE " + tableName);
            sql.Append("SET ");

            sql.Append("CallAssociationID = " + CallChangeAssociationID + ", ");
            sql.Append("CallInstanceID = " + CallInstanceID + ", ");
            sql.Append("TableName = " + fTableName + ", ");
            sql.Append("TableRecordID = " + TableRecordID);

            sql.Append("WHERE " + idColumn + " = " + CallChangeAssociationID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO " + tableName);
            sql.Append("VALUES (");

            sql.Append(CallChangeAssociationID + ", ");
            sql.Append("'" + CallInstanceID + "' ,");
            sql.Append("'" + fTableName + "' ,");
            sql.Append("'" + TableRecordID + "'");

            sql.Append(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is CallChangeAssociation association &&
                   CallChangeAssociationID == association.CallChangeAssociationID &&
                   EqualityComparer<Call>.Default.Equals(CallInstanceID, association.CallInstanceID) &&
                   fTableName == association.fTableName &&
                   TableRecordID == association.TableRecordID;
        }

        public override int GetHashCode()
        {
            int hashCode = 1886432251;
            hashCode = hashCode * -1521134295 + CallChangeAssociationID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Call>.Default.GetHashCode(CallInstanceID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(fTableName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TableRecordID);
            return hashCode;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
