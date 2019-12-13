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
            this.name = name;
            this.address = address;
            this.phonenumber = phonenumber;
            this.email = email;
        }

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
