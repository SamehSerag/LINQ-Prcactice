using Task_D10;
using static Task_D10.ListGenerators;
Console.WriteLine("Start Main\n");
//LINQ - Restriction Operators

// 1) Find all products that are out of stock.
Console.WriteLine("1) All products that are out of stock:");
var allProductsOut = ProductList.Where(p => p.UnitsInStock == 0);
foreach (var product in allProductsOut)
    Console.WriteLine(product);
Console.WriteLine();

// 2) Find all products that are in stock and cost more than 3.00 per unit.
Console.WriteLine("2) All products that are in stock and cost more than 3.00 per unit:");
var result = ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3M);
foreach (var product in result)
    Console.WriteLine(product);
Console.WriteLine();

// 3)Returns digits whose name is shorter than their value.
Console.WriteLine("3) Digits whose name is shorter than their value:");
string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var digits = Arr.Where((str, i) => str.Length < i);
foreach (var digit in digits)
    Console.WriteLine(digit);
Console.WriteLine();

Console.WriteLine("_______________________________________________________________");
// LINQ - Element Operators

// 1) Get first Product out of Stock 
Console.WriteLine("\n1) First Product out of Stock: ");
var fProductOut = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
Console.WriteLine(fProductOut + "\n");

// 2) Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
Console.WriteLine("2) First product whose Price > 1000, unless there is no match, in which case null is returned:");
var fProductOut2 = ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
if (fProductOut2 == null)
    Console.WriteLine("Not Found");
else
    Console.WriteLine(fProductOut2);

// 3) Retrieve the second number greater than 5
Console.WriteLine("3) Retrieve the second number greater than 5:");
int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var sProductg5 = Arr2.Where(x => x > 5).OrderBy(x => x).ElementAtOrDefault(1);
Console.WriteLine(sProductg5);

Console.WriteLine("_______________________________________________________________");


// LINQ - Set Operators

// 1. Find the unique Category names from Product List
Console.WriteLine("\n1. Find the unique Category names from Product List");
var uProductListN = ProductList.Select(p => p.Category).Distinct();
foreach (var uProduct in uProductListN)
    Console.WriteLine(uProduct);
Console.WriteLine();

// 2. Produce a Sequence containing the unique first letter from both product and customer names.
Console.WriteLine("2. Produce a Sequence containing the unique first letter from both product and customer names.");
var uFirstLetterP = ProductList.Select(p => p.ProductName[0]);
var uFirstLetterC = CustomerList.Select(c => c.CompanyName[0]);
////Console.WriteLine(uFirstLetterP.Union(uFirstLetterC).FirstOrDefault() + "\n");

foreach (var item in uFirstLetterP.Union(uFirstLetterC))
    Console.Write($"{item} ");
Console.WriteLine();

// 3. Create one sequence that contains the common first letter from both product and customer names.
Console.WriteLine("3) Create one sequence that contains the common first letter from both product and customer names.");
var uFirstLetterP2 = ProductList.Select(p => p.ProductName[0]);
var uFirstLetterC2 = CustomerList.Select(c => c.CompanyName[0]);

////Console.WriteLine(uFirstLetterP2.Intersect(uFirstLetterC2).FirstOrDefault());
foreach (var item in uFirstLetterP2.Intersect(uFirstLetterC2))
    Console.Write($"{item} ");
Console.WriteLine();

// 4. Create one sequence that contains the common first letter from both product and customer names. 
Console.WriteLine("4) Create one sequence that contains the common first letter from both product and customer names.");
var uFirstLetterP3 = ProductList.Select(p => p.ProductName[0]);
var uFirstLetterC3 = CustomerList.Select(c => c.CompanyName[0]);
var except = uFirstLetterP3.Except(uFirstLetterC3);
foreach (var item in except)
{
    Console.WriteLine(item);
}
Console.WriteLine();

//5.Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
Console.WriteLine("5) Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates");
//Console.WriteLine(ProductList[0].ProductName);
var uFirstLetterP4 = ProductList.Select(p => p.ProductName.Substring(p.ProductName.Length - 3));
var uFirstLetterC4 = CustomerList.Select(c => c.CompanyName.Substring(c.CompanyName.Length - 3));
var concat = uFirstLetterP4.Concat(uFirstLetterC4);
foreach (var item in concat)
{
    Console.WriteLine(item);
}

Console.WriteLine("_______________________________________________________________");

// LINQ - Aggregate Operators
// 1. Uses Count to get the number of odd numbers in the array
Console.WriteLine("1) Uses Count to get the number of odd numbers in the array: ");
int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
Console.WriteLine(Arr3.Count(i => i % 2 != 0));

// 2. Return a list of customers and how many orders each has.
Console.WriteLine("2. Return a list of customers and how many orders each has.");
var cust = CustomerList.Select(c => new { Customer = c, Orders = c.Orders.Count() });
////cust = from i in CustomerList
////       select new { Customer = i, Orders = i.Orders.Count() };
foreach (var c in cust)
    Console.WriteLine(c);


/// 3. Return a list of categories and how many products each has
//Console.WriteLine("3. Return a list of categories and how many products each has");
var categoriesAndProducts = ProductList.GroupBy(p => p.Category)
                                       .Select(c => new
                                       {
                                           Category = c.Key,
                                           Products = c.Count()
                                       });

#region V.0
////var categories = ProductList.Select(p => new
////{
////    categoryName = p.Category,
////    Count = ProductList.Count(pp => pp.Category == p.Category)
////}).Distinct();

////foreach (var category in categories)
////{
////    Console.WriteLine(category);
////}
////Console.WriteLine();
#endregion

foreach (var category in categoriesAndProducts)
{
    Console.WriteLine(category);
}

//4. Get the total of the numbers in an array.
Console.WriteLine("4) Get the total of the numbers in an array: ");
int[] Arr5 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
Console.WriteLine(Arr5.Sum());

// 5. Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
string[] arrDic = File.ReadAllLines(@"E:\ITI\C#\D10\Tasks\Task_D10\Task_D10\bin\Debug\net6.0\dictionary_english.txt");
Console.WriteLine("5) Get the total number of characters of all words in dictionary_english.txt: ");
Console.WriteLine(arrDic.Sum(s => s.Length));

// 6.Get the total units in stock for each product category.
Console.WriteLine("6) Get the total units in stock for each product category: ");
var category2 = ProductList.GroupBy(p => p.Category)
                            .Select(c => new { category = c.Key, AllUnits = c.Sum(c => c.UnitsInStock) });

foreach (var item in category2)
    Console.WriteLine(item);
Console.WriteLine();


// 7. Get the length of the shortest word in dictionary_english.txt 
Console.WriteLine("7)  Get the length of the shortest word in dictionary_english.txt ");
Console.WriteLine(arrDic.Min(str => str.Length) + "\n");

// 8. Get the cheapest price among each category's products
Console.WriteLine("8) Get the cheapest price among each category's products: ");
var cheapestPrices = ProductList.GroupBy(p => p.Category)
    .Select(c => new { Category = c.Key, MinPrice = c.Min(c => c.UnitPrice) });

foreach (var item in cheapestPrices)
    Console.WriteLine(item);
Console.WriteLine();

// 9. Get the products with the cheapest price in each category (Use Let)
Console.WriteLine("9) Get the products with the cheapest price in each category (Use Let)");
var letQueary = from catg in ProductList.GroupBy(p => p.Category)
                from product in catg
                let productName = product.ProductName
                where catg.Min(p => p.UnitPrice) == product.UnitPrice
                select new { Category = catg.Key, CheapestProduct = productName };

foreach (var item in letQueary)
{
    Console.WriteLine(item);
}
Console.WriteLine();

// 10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
Console.WriteLine("10) Get the length of the longest word in dictionary_english.txt");
Console.WriteLine(arrDic.Max(str => str.Length));


/// 11. Get the most expensive price among each category's products.
Console.WriteLine("11) Get the most expensive price among each category's products: ");
var letQueryExpen = ProductList.GroupBy(p => p.Category)
    .Select(catParent => new { Category = catParent.Key, MaxPrice = catParent.Max(p => p.UnitPrice) });

foreach (var item in letQueryExpen)
    Console.WriteLine(item);

// 12. Get the products with the most expensive price in each category.
Console.WriteLine("12) Get the products with the most expensive price in each category: ");
var expensiveProducts = from product in ProductList
                        group product by product.Category
                        into categ
                        from pro in categ
                        where pro.UnitPrice == categ.Max(p => p.UnitPrice)
                        select new { Category = categ.Key, Product = pro };

foreach (var item in expensiveProducts)
{
    Console.WriteLine(item);
}
Console.WriteLine();
//#region V0
//var expensiveProducts = ProductList.GroupBy(p => p.Category)
//    .Select(catParent => catParent.Select(p => p).Where(p => p.UnitPrice == catParent.Max(p => p.UnitPrice)));

//foreach (var item in expensiveProducts)
//{
//    foreach (var product in item)
//        Console.WriteLine(product);
//}
//#endregion

// 13. Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
Console.WriteLine("13) Get the average length of the words in dictionary_english.txt: ");
Console.WriteLine((int)arrDic.Average(str => str.Length) + "\n");

// 14. Get the average price of each category's products
Console.WriteLine("14) Get the average price of each category's products:");
var avrPricePerCat = ProductList.GroupBy(p => p.Category)
    .Select(cParent => new { Category = cParent.Key, AveragePrice = cParent.Average(p => p.UnitPrice) });

foreach (var item in avrPricePerCat)
    Console.WriteLine(item);
Console.WriteLine();

Console.WriteLine("________________________________________________________________________________________");

// LINQ - Ordering Operators

// 1. Sort a list of products by name
Console.WriteLine("1. Sort a list of products by name: ");
var sortedProducts = ProductList.OrderBy(p => p.ProductName);
foreach (var product in sortedProducts)
    Console.WriteLine(product);
Console.WriteLine();

// 2. Uses a custom comparer to do a case-insensitive sort of the words in an array.
Console.WriteLine("2. Uses a custom comparer to do a case-insensitive sort of the words in an array: ");
string[] Arr4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
var orderedArr = Arr4.OrderBy(str => str, new StrComparer());
//var orderedArr2 = Arr4.OrderBy(str => str);
//var orderedArr = Arr4.OrderBy(str => str.ToLower());

foreach (var item in orderedArr)
    Console.WriteLine(item);
Console.WriteLine();

// 3. Sort a list of products by units in stock from highest to lowest.
Console.WriteLine("3. Sort a list of products by units in stock from highest to lowest: ");
var sortedProducts2 = ProductList.OrderByDescending(p => p.UnitsInStock);
foreach (var item in sortedProducts2)
    Console.WriteLine(item);
Console.WriteLine();

// 4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
Console.WriteLine("4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself: ");
string[] Arr6 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var sortedArr6 = Arr6.OrderBy(str => str.Length).ThenBy(str => str);
foreach (var item in sortedArr6)
    Console.WriteLine(item);
Console.WriteLine();

//5. Sort first by word length and then by a case-insensitive sort of the words in an array.
Console.WriteLine("5. Sort first by word length and then by a case-insensitive sort of the words in an array: ");
string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
var sortedWords = words.OrderBy(w => w.Length).ThenBy(w => w, new StrComparer());
foreach (string word in sortedWords)
    Console.WriteLine(word);
Console.WriteLine();

// 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
Console.WriteLine("6. Sort a list of products, first by category, and then by unit price, from highest to lowest.");
var sortedProducts6 = ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
foreach (var product in sortedProducts6)
    Console.WriteLine(product);
Console.WriteLine();

// 7.Sort first by word length and then by a case-insensitive descending sort of the words in an array
Console.WriteLine("7. Sort first by word length and then by a case-insensitive descending sort of the words in an array");
string[] words2 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
var sortedWords2 = words2.OrderBy(w => w.Length).ThenByDescending(w => w, new StrComparer());
foreach (string word in sortedWords2)
    Console.WriteLine(word);
Console.WriteLine();


// 8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
Console.WriteLine("8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.");
string[] Arr8 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
var sortArr8 = Arr8.Where(x => x.ElementAt(1) == 'i').Reverse();

foreach (var item in sortArr8)
    Console.WriteLine(item);
Console.WriteLine();

Console.WriteLine("_________________________________________________________________________________________");

//LINQ - Partitioning Operators

//1. Get the first 3 orders from customers in Washington
Console.WriteLine("1. Get the first 3 orders from customers in Washington");
var f3oInWashington = CustomerList.Where(c => c.City == "Washington").SelectMany(c => c.Orders).Take(3);
foreach (var item in f3oInWashington)
    Console.WriteLine(item);
Console.WriteLine();


//2. Get all but the first 2 orders from customers in Washington.
Console.WriteLine("2. Get all but the first 2 orders from customers in Washington.");
var f3oInWashington2 = CustomerList.Where(c => c.City == "Washington").SelectMany(c => c.Orders).Skip(2);
foreach (var item in f3oInWashington2)
    Console.WriteLine(item);
Console.WriteLine();


//// 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.
Console.WriteLine("3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.");
int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var fromNumber3 = numbers3.TakeWhile((x, i) => x > i);
foreach (var item in fromNumber3)
    Console.Write(item + ", ");
Console.WriteLine();


//4. Get the elements of the array starting from the first element divisible by 3.
Console.WriteLine("4. Get the elements of the array starting from the first element divisible by 3.");
int[] numbers4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var fromNumber4 = numbers4.SkipWhile(x => x % 3 != 0);
foreach (var item in fromNumber4)
    Console.Write(item + ", ");
Console.WriteLine();

//5. Get the elements of the array starting from the first element less than its position.
Console.WriteLine("5. Get the elements of the array starting from the first element less than its position.");
int[] numbers5 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var fromNumber5 = numbers5.SkipWhile((x, i) => x > i);
foreach (var item in fromNumber5)
    Console.Write(item + ", ");
Console.WriteLine();

Console.WriteLine("_________________________________________________________________________________________");

// LINQ - Projection Operators
// 1. Return a sequence of just the names of a list of products.
var namesofProducts = ProductList.Select(p => p.ProductName);
foreach (var item in namesofProducts)
    Console.WriteLine(item);
Console.WriteLine();


// 2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).
Console.WriteLine("2. Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).");
string[] words3 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
var namesofProducts2 = words3.Select(word => new { WordUpper = word.ToUpper(), WordLower = word.ToLower() });

foreach (var item in namesofProducts2)
    Console.WriteLine(item);
Console.WriteLine();

//3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
Console.WriteLine("3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.");
var Products3 = ProductList.Select(p => new { ID = p.ProductID, Name = p.ProductName, Price = p.UnitPrice });
foreach (var item in Products3)
    Console.WriteLine(item);
Console.WriteLine();

//4. Determine if the value of ints in an array match their position in the array.
Console.WriteLine("4. Determine if the value of ints in an array match their position in the array.");
int[] Arr01 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var Arr01Match = Arr01.Select((x, i) => new { Num = x, Bool = x == i });

foreach (var item in Arr01Match)
    Console.WriteLine(item);
Console.WriteLine();

//5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
Console.WriteLine("5. Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.");
int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };
var numberPairs = from num1 in numbersA
                  from num2 in numbersB
                  where num1 < num2
                  select new { num1, num2 };

foreach (var item in numberPairs)
    Console.WriteLine(item);
Console.WriteLine();

//6. Select all orders where the order total is less than 500.00.
Console.WriteLine("6. Select all orders where the order total is less than 500.00.");
var allOrders = CustomerList.SelectMany(c => c.Orders).Where(x => x.Total < 500);
foreach (var item in allOrders)
    Console.WriteLine(item);
Console.WriteLine();


// 7. Select all orders where the order was made in 1998 or later.
Console.WriteLine("7. Select all orders where the order was made in 1998 or later.");
var allOrders2 = CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998);
foreach (var item in allOrders2)
    Console.WriteLine(item);
Console.WriteLine();

Console.WriteLine("________________________________________________________________________________________");

///LINQ - Quantifiers

// 1. Determine if any of the words in dictionary_english.txt contain the substring 'ei'.
Console.WriteLine("1. Determine if any of the words in dictionary_english.txt contain the substring 'ei'.");
Console.WriteLine(arrDic.Any(str => str.Contains("ei")));

// 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.
Console.WriteLine("2. Return a grouped a list of products only for categories that have at least one product that is out of stock.");
var test02 = ProductList.GroupBy(p => p.Category).Where(cp => cp.Any(p => p.UnitsInStock == 0));
foreach (var category in test02)
{
    Console.WriteLine(category.Key);
    foreach (var product in category)
        Console.WriteLine($"...{product}");
}
Console.WriteLine();


// 3. Return a grouped a list of products only for categories that have all of their products in stock.
Console.WriteLine("3. Return a grouped a list of products only for categories that have all of their products in stock.");

var test03 = ProductList.GroupBy(p => p.Category).Where(cp => cp.All(p => p.UnitsInStock > 0));
foreach (var category in test03)
{
    Console.WriteLine(category.Key);
    foreach (var product in category)
        Console.WriteLine($"...{product}");
}
Console.WriteLine();


Console.WriteLine("_________________________________________________________________________________________");

// LINQ - Grouping Operators

// 1. Use group by to partition a list of numbers by their remainder when divided by 5
Console.WriteLine("1. Use group by to partition a list of numbers by their remainder when divided by 5: ");
var list = Enumerable.Range(0, 21);
var grouping1 = list.GroupBy(x => x % 5);

foreach (var category in grouping1)
{
    Console.WriteLine(category.Key);
    foreach (var element in category)
        Console.WriteLine($"...{element}");
}
Console.WriteLine();


//2. Uses group by to partition a list of words by their first letter.
Console.WriteLine("2. Uses group by to partition a list of words by their first letter.");
var grouping2 = arrDic.GroupBy(s => s[0]);

foreach (var category in grouping2)
{
    Console.WriteLine(category.Key);
    foreach (var element in category)
        Console.WriteLine($"...{element}");
}
Console.WriteLine();

// 3 Use Group By with a custom comparer that matches words that are consists of the same Characters Together
string[] Arr05 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
var test04 = Arr05.GroupBy(s => s, new CustomComparer());

foreach (var category in test04)
{
    Console.WriteLine(category.Key);
    foreach (var element in category)
        Console.WriteLine($"...{element}");
}
Console.WriteLine();









//foreach (var category in category2)
//{
//    Console.WriteLine(category.Key + " " + category.Count() + " " + category.Sum(c => c.UnitsInStock));
//    foreach (var item in category)
//    {
//        Console.WriteLine($"...{item.ProductName}");
//    }
//}

//foreach (var item in uFirstLetterP2.Intersect(uFirstLetterC2))
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine();
//foreach (var item in uFirstLetterC2)
//{
//    Console.WriteLine(item);
//}







