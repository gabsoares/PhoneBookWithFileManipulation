namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new();
            List<Contact> contacts = new();

            string path = @"C:\PhoneBook\";
            string file = "contacts.txt";
            string filePhone = "phones.txt";

            Contact CreateContact()
            {
                Console.Write("Informe o nome do contato a ser adicionado: ");
                string name = Console.ReadLine();

                Console.Write("Informe o e-mail do contato: ");
                string email = Console.ReadLine();

                return new(name, GetAdress(), email);
            }

            Adress GetAdress()
            {
                Console.Write("Informe o logradouro: ");
                string publicPlace = Console.ReadLine();

                Console.Write("Informe o número: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Informe o bairro: ");
                string district = Console.ReadLine();

                Console.Write("Informe o CEP: ");
                string zipCode = Console.ReadLine();

                Console.Write("Informe a cidade: ");
                string city = Console.ReadLine();

                Console.Write("Informe a UF: ");
                string UF = Console.ReadLine();

                return new(publicPlace, district, zipCode, city, UF, number);
            }

            Phone GetPhone()
            {
                Console.Write("Informe o telefone: ");
                string phone = Console.ReadLine();

                return new(phone);
            }

            void ShowAll(List<Contact> l)
            {
                foreach (var item in l)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            void ShowAllPhones(List<Phone> l)
            {
                foreach (var item in l)
                {
                    Console.Write(item.ToString());
                }
            }

            bool CheckIfExists(string p, string f)
            {
                if (!Directory.Exists(p))
                {
                    Directory.CreateDirectory(p);
                }

                if (!File.Exists(f))
                {
                    File.Create(f);
                }

                return true;
            }

            void SaveFileContact(List<Contact> l, string p, string f)
            {
                if (CheckIfExists(p, f))
                {
                    StreamWriter sw = new(p + f);

                    foreach (var item in l)
                    {
                        sw.WriteLine(item);
                    }

                    sw.Close();
                }
            }

            void SaveFilePhone(List<Phone> l, string p, string f)
            {
                if (CheckIfExists(p, f))
                {
                    StreamWriter sw = new(p + f);

                    foreach (var item in l)
                    {
                        sw.WriteLine(item);
                    }

                    sw.Close();
                }
            }

            phones.Add(GetPhone());
            Console.Clear();
            phones.Add(GetPhone());
            Console.Clear();
            contacts.Add(CreateContact());
            Console.Clear();
            contacts.Add(CreateContact());
            Console.Clear();
            Console.WriteLine("Impressão\n");
            ShowAll(contacts);
            SaveFileContact(contacts, path, file);
            Console.WriteLine("\nImpressão Telefones\n");
            ShowAllPhones(phones);
            SaveFilePhone(phones, path, filePhone);
        }
    }
}