using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019TobbformosMvcPizzaEgyTabla.model
{
    partial class Futar
    {
        public string getFutarInsert()
        {
            return "INSERT INTO `futarok` (`futarazon`,`futarnev`,`futarlakcim`,`futartelszam`,`futaremail`)" +
                   "VALUES ('" +
                   id +
                   "', '" +
                   getName() +
                   "', '" +
                   getAddress() +
                   "', '" +
                   getPhonenumber() +
                   "', '" +
                   getEmail() +
                   "', '" +
                   "');";
        }
        public string getFutarUpdate(int id)
        {
            return "UPDATE `futarok` SET `futaroknev` = '" +
                getName() +
                "', `futarlakcim` = '" +
                getAddress() +
                "', `futartelszam` = '" +
                getPhonenumber() +
                "', `futaremail` = '" +
                getEmail() +
                "' WHERE `futaork`.`futarazon` = " +
                id;
        }

        public static string getSQLCommandFutarDeleteAllRecord()
        {
            return "DELETE FROM futarok";
        }
        public static string getSQLCommandFutarGetAllRecord()
        {
            return "SELECT * FROM futarok";
        }
    }
}
