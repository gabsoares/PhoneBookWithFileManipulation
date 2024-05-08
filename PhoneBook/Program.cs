using System.Diagnostics.Metrics;

namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new();
            List<Contact> contacts = new();
            int opt = 0;
            string name = "";
            int numPhone = 0, count = 0;

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
                if (!IsContactListEmpty())
                {
                    foreach (var item in l)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }

            void ShowAllPhones(List<Phone> l)
            {
                if (!IsContactListEmpty())
                {
                    foreach (var item in l)
                    {
                        Console.Write(item.ToString());
                    }
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

            void RemoveContactByName(string name)
            {
                if (!IsContactListEmpty())
                {
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].getName() == name)
                        {
                            contacts.RemoveAt(i);
                            phones.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            bool IsContactListEmpty()
            {
                return contacts.Count == 0;
            }

            Contact SearchContactByName()
            {
                if (!IsContactListEmpty())
                {
                    Console.Write("Informe o nome do contato a ser procurado: ");
                    name = Console.ReadLine();
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].getName() == name)
                        {

                            return contacts[i];
                        }
                    }
                }
                return null;
            }

            Phone SearchContactByNameGetPhone()
            {
                if (!IsContactListEmpty())
                {
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].getName() == name)
                        {
                            return phones[i];
                        }
                    }
                }
                return null;
            }

            Contact ModifyContact()
            {
                if (!IsContactListEmpty())
                {
                    Console.Write("Informe o nome do contato a ser modificado: ");
                    name = Console.ReadLine();
                    string desc = "";
                    for (int i = 0; i < contacts.Count; i++)
                    {
                        if (contacts[i].getName() == name)
                        {
                            Console.Write("Informe o que você quer editar do contato: ");
                            desc = Console.ReadLine();
                            switch (desc)
                            {
                                case "nome":
                                case "Nome":
                                    Console.Write("Digite o novo nome do contato: ");
                                    contacts[i].setName(Console.ReadLine());
                                    break;
                                //case "Endereco":
                                //case "endereco":
                                //    break;
                                case "email":
                                case "Email":
                                case "E-mail":
                                case "e-mail":
                                    Console.Write("Digite o novo e-mail do contato: ");
                                    contacts[i].setEmail(Console.ReadLine());
                                    break;
                                //case "Telefone":
                                //case "telefone":
                                //    do
                                //    {
                                //        phones.Add(GetPhone());
                                //        count++;
                                //    } while (count < numPhone);
                                //    break;
                            }
                            return contacts[i];
                        }
                    }
                }
                return null;
            }

            do
            {
                Console.Clear();

                Console.WriteLine("****MENU PRINCIPAL****");
                Console.WriteLine("Digite 1 para adicionar um novo contato");
                Console.WriteLine("Digite 2 para remover um contato");
                Console.WriteLine("Digite 3 para mostrar todos os contatos");
                Console.WriteLine("Digite 4 para pesquisar um contato");
                Console.WriteLine("Digite 5 para editar um contato");
                Console.WriteLine("Digite 0 para sair");
                Console.Write("Opção desejada (0-4):< > \b\b\b");
                opt = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (opt)
                {
                    case 1:
                        contacts.Add(CreateContact());
                        Console.Write("Informe o número de telefones a serem adicionados: ");
                        numPhone = int.Parse(Console.ReadLine());
                        count = 0;
                        do
                        {
                            phones.Add(GetPhone());
                            count++;
                        } while (count < numPhone);
                        SaveFileContact(contacts, path, file);
                        SaveFilePhone(phones, path, filePhone);
                        break;
                    case 2:
                        Console.Write("Digite o nome do contato que deseja remover: ");
                        RemoveContactByName(Console.ReadLine());
                        SaveFileContact(contacts, path, file);
                        SaveFilePhone(phones, path, filePhone);
                        break;
                    case 3:
                        ShowAll(contacts);
                        ShowAllPhones(phones);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine(SearchContactByName());
                        Console.WriteLine(SearchContactByNameGetPhone());
                        Console.ReadKey();
                        break;
                    case 5:
                        ModifyContact();
                        SaveFileContact(contacts, path, file);
                        SaveFilePhone(phones, path, filePhone);
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida");
                        break;
                }
            } while (opt != 0);
        }
    }
}