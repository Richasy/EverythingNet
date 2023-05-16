// See https://aka.ms/new-console-template for more information
using EverythingNet.Core;

var client = new Everything();
Console.Write("输入关键词：");
var keyword = Console.ReadLine();
var results = client.Search()
    .Name
    .Contains(keyword);
foreach (var item in results)
{
    Console.WriteLine(item.FileName);
}

Console.WriteLine($"总数：{results.Count}");