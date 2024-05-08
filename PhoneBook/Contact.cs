namespace PhoneBook
{
    internal class Contact
    {
        string name;
        List<Phone> phones;
        Adress adress;
        string email;

        public Contact(string name, Adress adress, string email)
        {
            this.name = name;
            this.adress = adress;
            this.email = email;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public override string? ToString()
        {
            return name + "|" + adress + "|" + email;
        }
    }
}
