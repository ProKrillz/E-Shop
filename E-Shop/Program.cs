using RestSharp;
using RestSharp.Authenticators;
using System.Xml.Linq;

var client = new RestClient("https://api.dataforsyningen.dk");

//XDocument doc = XDocument.Load("https://api.dataforsyningen.dk/postnumre");
//Console.WriteLine(doc);

var request = new RestRequest("https://api.dataforsyningen.dk/postnumre");



Console.WriteLine(request.ToString());

