using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqlbackup.Enums
{
    public enum SqlEnum
    {
        MSSQL,
        MYSQL,
        POSTGRESQL
      

    }

   public static class SqlEnums
    {
        public static string GetSqlName(this SqlEnum sqlEnum)
        {
            if (sqlEnum == SqlEnum.MSSQL)
                return "MSSQL";
          else  if (sqlEnum == SqlEnum.MYSQL)
                return "MSSQL";
          else if (sqlEnum == SqlEnum.POSTGRESQL)
                return "MSSQL";
       return "";
        }

    }
}
