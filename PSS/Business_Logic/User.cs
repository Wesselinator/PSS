using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PSS.Business_Logic
{
    class User : SingleIntID
    {
        public int UserID { get => ID; private set => ID = value; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        private static readonly string tableName = "User";
        private static readonly string idColumn = "UserID";

        public User() : base(tableName, idColumn)
        {
        }

        public User(int userID, string userName, string password, string role) : this()
        {
            this.UserID = userID;
            this.UserName = userName;
            this.Password = password;
            this.Role = role;
        }

        public User(string userName, string password, string role) : this()
        {
            this.UserID = GetNextID();
            this.UserName = userName;
            this.Password = password;
            this.Role = role;
        }

        #region DataBase

        public override void FillFromRow(DataRow row)
        {
            this.UserID = row.Field<int>(IDColumn);
            this.UserName = row.Field<string>("UserName");
            this.Password = row.Field<string>("Password");
            this.Role = row.Field<string>("Role");
        }

        protected override string Update()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE " + TableName);
            sql.Append("SET ");

            sql.Append("UserName = '" + UserName + "', ");
            sql.Append("Password = '" + Password + "', ");
            sql.Append("Role = '" + Role + "' ");

            sql.AppendLine("WHERE " + IDColumn + " = " + UserID);

            return sql.ToString();
        }

        protected override string Insert()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO " + TableName + " (UserID, UserName, Password, Role)");
            sql.Append("VALUES (");

            sql.Append(UserID + ", ");
            sql.Append("'" + UserName + "', ");
            sql.Append("'" + Password + "', ");
            sql.Append("'" + Role + "' ");

            sql.AppendLine(");");

            return sql.ToString();
        }

        #endregion

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UserID == user.UserID &&
                   UserName == user.UserName &&
                   Password == user.Password &&
                   Role == user.Role;
        }

        public override int GetHashCode()
        {
            int hashCode = -902689823;
            hashCode = hashCode * -1521134295 + UserID.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UserName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Role);
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
