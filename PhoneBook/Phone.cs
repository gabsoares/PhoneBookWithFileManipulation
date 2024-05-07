namespace PhoneBook
{
    internal class Phone
    {
        string number;

        public Phone(string number)
        {
            this.number = number;
        }
        public override string? ToString()
        {
            return number+"|";
        }
    }
}
