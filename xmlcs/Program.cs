using System.Xml.Serialization;

Person p = new Person() { Name = "John", Age = 30 };
string xmlfile = "person.xml";
XmlSerializer xs = new XmlSerializer(typeof(Person));
using (StreamWriter o = File.CreateText(xmlfile))
{ xs.Serialize(o, p); }

using (StreamReader i = File.OpenText(xmlfile))
{
    Person? p2 = xs.Deserialize(i) as Person;
    if (p2 != null)
    {
        Console.WriteLine($"Name: {p2.Name}, Age: {p2.Age}");
    }
}