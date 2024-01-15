using static System.Formats.Asn1.AsnWriter;

namespace Uppgift2;
class Program
{
    static void Main(string[] args)
    {
        // skapar en tom lista
        List<Category> categoryList = new List<Category>();


        Console.WriteLine("Skriv in en vara.");
        Console.WriteLine("Avsluta med 'q'");

        //skapar en While loop
        while (true)
        {
            // skapar en variabel med namnet category med startvärdet null.
            Category category = null;

            //skapar en variabel med namnet index som startvärde -1.
            int index = -1;

            Console.Write("Kategori:");

            String categoryName = Console.ReadLine();

            //om användaren skriver in q avslutas loopen
            if (categoryName.ToLower() == "q")
            {
                break;
            }
            //skapar en foreach loop och går igenom den befintliga kategorilistan.
            foreach (Category cat in categoryList)
            {
                // kontrollerar om kategorinamnet redan existerar i kategorilistan.
                if (cat.categoryName.Equals(categoryName))
                {
                    //sätter category variabeln till värdet av den befintliga kategorin med samma namn.
                    category = cat;
                    // hämtar ut index av den befintliga kategorin med samma namn.
                    index = categoryList.IndexOf(cat);
                }
            }
            //kontrollerar om category fortfarande har värdet null.
            if (category == null)
            {
                //sätter värdet av category till en ny kategori med kategorinamnet av input.
                category = new Category(categoryName);
            }

            Console.Write("Produkt:");
            String productName = Console.ReadLine();

            if (productName.ToLower() == "q")
            {
                break;
            }


            //skapar en foreach loop och kontrollerar om produkten redan existerar.
            foreach (Product p in category.productList)
            {
                if (p.productName.Equals(productName))
                {
                    while (true)
                    {
                        Console.Write("Produkten finns redan. Välj en annan Produkt:");
                        String newProduct = Console.ReadLine();
                        bool x = false;
                        foreach (Product pro in category.productList)
                        {
                            if (pro.productName.Equals(newProduct))
                            {
                                x = true;
                            }
                        }
                        if (x == false)
                        {
                            productName = newProduct;
                            break;
                        }
                    }


                }

            }
            Console.Write("Pris:");
            String priceString = Console.ReadLine();

            if (priceString.ToLower() == "q")
            {
                break;
            }
            // konverterar variabeln från en String till en int.

            int price = Convert.ToInt32(priceString);

            Product product = new Product(productName, price);

            category.productList.Add(product);
            //kontrollerar om index fortfarande är =-1.
            if (index == -1)
            {
                categoryList.Add(category);
            }
            //den nya kategorin ersätter den gamla kategorin med en uppdaterad produktlista.
            else
            {
                categoryList[index] = category;
            }
        }

        // skriver ut användarens inmatning för listan
        Console.WriteLine("Du skrev in:");


        int categorySum = 0;

        //skapar en foreach loop som loopar igenom kategorierna i listan
        foreach (Category category in categoryList)
        {
            Console.WriteLine("----------");
            Console.Write("Kategori:");
            Console.WriteLine(category.categoryName);



            int productSum = 0;
            // sorterar listan i prisordning
            List<Product> products = category.productList.OrderBy(product => product.price).ToList();

            foreach (Product product in products)
            {
                Console.WriteLine("Produkt: " + product.productName + " " + product.price + ":-");
                productSum = productSum + product.price;

            }

            Console.WriteLine("Totalsumman är:" + productSum + ":-");

            // lägger ihop totalsumman av alla ketgorier
            categorySum = categorySum + productSum;


        }
        Console.WriteLine("----------");

        Console.WriteLine("Totalsumman för alla kategorier är:" + categorySum + ":-");
    }
}











