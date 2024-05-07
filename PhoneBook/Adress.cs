namespace PhoneBook
{
    internal class Adress
    {
        string publicPlace;
        string district;
        string zipCode;
        string city;
        string UF;
        int number;

        public Adress(string publicPlace, string district, string zipCode, string city, string UF, int number)
        {
            this.publicPlace = publicPlace;
            this.district = district;
            this.zipCode = zipCode;
            this.city = city;
            this.UF = UF;
            this.number = number;
        }

        public override string? ToString()
        {
            return publicPlace + "|" + number + "|" + district + "|" + zipCode + "|" + city + "|" + UF;
        }
    }
}
