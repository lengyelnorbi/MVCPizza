using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2019TobbformosMvcPizzaEgyTabla.model
{
    partial class Futar
    {
        private int id;
        private string name;
        private string address;
        private string phonenumber;
        private string email;

        public Futar(int id, string name, string address, string phonenumber, string email)
        {
            this.id = id;
            if (!isValidName(name))
                throw new ModelFutarNotValidNameExeption("A futár neve nem megfelelő!");
            /*if (!isValidAddress(address))
                throw new ModelFutarNotValidAddressExeption("A futár lakcíme nem megfelelő!");*/
            if (!isValidPhonenumber(phonenumber))
                throw new ModelFutarNotValidPhonenumberExeption("A futár telefonszáma nem megfelelő!");
            /*if (!isValidEmail(email))
                throw new ModelFutarNotValidEmailExeption("A futár email címe nem megfelelő!");*/
            this.name = name;
            this.address = address;
            this.phonenumber = phonenumber;
            this.email = email;
        }

        private bool isValidName(string name)
        {
            if (name == string.Empty)
                return false;
            if (!char.IsUpper(name.ElementAt(0)))
                return false;
            for (int i = 1; i < name.Length; i = i + 1)
                if (
                    !char.IsLetter(name[i])
                        &&
                    (!char.IsWhiteSpace(name[i]))

                    )
                    return false;
            return true;
        }

        /*private bool isValidAddress(string address)
        {
            if (address == string.Empty)
                return false;
            if (!char.IsUpper(address.ElementAt(0)))
                return false;
            for (int i = 1; i < address.Length; i = i + 1)
                if (
                    !char.IsLetter(address[i]))
                    return false;
            return true;
        }*/

        private bool isValidPhonenumber(string phonenumber)
        {
            if (phonenumber == string.Empty)
                return false;
            for (int i = 1; i < phonenumber.Length; i = i + 1)
                if (char.IsLetter(phonenumber[i])
                        &&
                    (char.IsWhiteSpace(phonenumber[i]))

                    )
                    return false;
            return true;
        }

        /*private bool isValidEmail(string email)
        {
            if (email == string.Empty)
                return false;
            if (!char.IsUpper(email.ElementAt(0)))
                return false;
            for (int i = 1; i < email.Length; i = i + 1)
                if ((
                    !char.IsLetter(email[i]))
                        &&
                    (!char.IsWhiteSpace(email[i])))
                    return false;
            return true;
        }*/

        public void update(Futar modified)
        {
            this.name = modified.getName();
            this.address = modified.getAddress();
            this.phonenumber = modified.getPhonenumber();
            this.email = modified.getEmail();
        }

        public void setId()
        {
            this.id = id;
        }
        public void setName()
        {
            this.name = name;
        }
        public void setAddress()
        {
            this.address = address;
        }
        public void setPhonenumber()
        {
            this.phonenumber = phonenumber;
        }
        public void setEmail()
        {
            this.email = email;
        }

        public int getId()
        {
            return id;
        }
        public string getName()
        {
            return name;
        }
        public string getAddress()
        {
            return address;
        }
        public string getPhonenumber()
        {
            return phonenumber;
        }
        public string getEmail()
        {
            return email;
        }
    }
}
