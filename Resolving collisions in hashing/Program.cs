using System;
using System.Collections.Generic;
using System.Text;

class Product
{
    public int Number { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Product(int number, string name, int quantity)
    {
        Number = number;
        Name = name;
        Quantity = quantity;
    }
}

class HashTable
{
    private LinkedList<Product>[] table;

    public HashTable(int size)
    {
        table = new LinkedList<Product>[size];
    }

    private int HashFunctionMultiplication(int number)
    {
        double A = 0.6180339887;
        double fraction = number * A - Math.Truncate(number * A);
        return (int)Math.Floor(table.Length * fraction);
    }

    public void AddProduct(Product product)
    {
        int index = HashFunctionMultiplication(product.Number);

        if (table[index] == null)
        {
            table[index] = new LinkedList<Product>();
        }

        table[index].AddLast(product);
    }

    public Product FindProduct(int number)
    {
        int index = HashFunctionMultiplication(number);

        if (table[index] != null)
        {
            foreach (Product product in table[index])
            {
                if (product.Number == number)
                {
                    return product;
                }
            }
        }

        return null;
    }

    public void RemoveProduct(int number)
    {
        int index = HashFunctionMultiplication(number);

        if (table[index] != null)
        {
            LinkedListNode<Product> currentNode = table[index].First;
            while (currentNode != null)
            {
                if (currentNode.Value.Number == number)
                {
                    table[index].Remove(currentNode.Value);
                    break;
                }
                currentNode = currentNode.Next;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        HashTable hashTable = new HashTable(1000);

        while (true)
        {
            Console.WriteLine("\n1. Додати товар");
            Console.WriteLine("2. Знайти товар");
            Console.WriteLine("3. Видалити товар");
            Console.WriteLine("4. Вийти");
            Console.Write("Виберіть опцію: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть номер продукту: ");
                        if (int.TryParse(Console.ReadLine(), out int number))
                        {
                            Console.Write("Введіть назву продукту: ");
                            string name = Console.ReadLine();
                            Console.Write("Введіть кількість продукту: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity))
                            {
                                hashTable.AddProduct(new Product(number, name, quantity));
                                Console.WriteLine("Товар успішно додано");
                            }
                            else
                            {
                                Console.WriteLine("Некоректне значення кількості продукту. Спробуйте ще раз.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректний номер продукту. Спробуйте ще раз.");
                        }
                        break;
                    case 2:
                        Console.Write("Введіть номер продукту: ");
                        if (int.TryParse(Console.ReadLine(), out int searchedNumber))
                        {
                            Product foundProduct = hashTable.FindProduct(searchedNumber);
                            if (foundProduct != null)
                            {
                                Console.WriteLine($"Знайдено товар: {foundProduct.Name}, кількість: {foundProduct.Quantity}");
                            }
                            else
                            {
                                Console.WriteLine("Товар не знайдено");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некоректний номер продукту. Спробуйте ще раз.");
                        }
                        break;
                    case 3:
                        Console.Write("Введіть номер продукту для видалення: ");
                        if (int.TryParse(Console.ReadLine(), out int removeNumber))
                        {
                            hashTable.RemoveProduct(removeNumber);
                            Console.WriteLine("Товар успішно видалено");
                        }
                        else
                        {
                            Console.WriteLine("Некоректний номер продукту. Спробуйте ще раз.");
                        }
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Неправильний вибір опції. Спробуйте ще раз.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некоректний вибір опції. Спробуйте ще раз.");
            }
        }
    }
}
