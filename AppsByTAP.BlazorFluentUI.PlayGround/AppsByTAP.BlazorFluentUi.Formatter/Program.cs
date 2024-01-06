// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");

string text = File.ReadAllText(@"R:\temp\css.txt");

//StringBuilder sb = new StringBuilder();

//for(int i = 0; i < lines.Length; i +=4)
//{
//    sb.Append(lines[i].Trim() + $" {lines[i+1].Trim()} }}{Environment.NewLine}");
//}

//File.WriteAllText(@"R:\temp\css-output.txt", sb.ToString());

Regex rex = new Regex(@"--(?<name>[A-Za-z0-9]+):before { content: ""\\(?<code>[A-Za-z0-9]+)""; }");
MatchCollection matches = rex.Matches(text);


StringBuilder sb2 = new StringBuilder();
StringBuilder sb3 = new StringBuilder();

foreach(Match match in matches)
{
    if(match.Success)
    {
        sb2.Append("\t\t" + match.Groups["name"].Value + "," + Environment.NewLine);
        sb3.Append(match.Groups["code"].Value + Environment.NewLine);
    }
}

string iconTypes = sb2.ToString();
string unicodeSelection = sb3.ToString();//https://uifabricicons.azurewebsites.net/

Console.WriteLine(iconTypes);