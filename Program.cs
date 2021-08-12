using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class TestParseExact
{
   public static void Main(string[] args)
   {
        string filename, exp, format, strDate;
        DateTime result;


        filename = args[0];
        exp = args[1];
        format = args[2];

        Regex regex = new Regex(exp);

        Match match = regex.Match(filename);

        if (match.Success)
            strDate = match.Value;
        else
        {
            strDate = "DID NOT MATCH FILENAME";
            Console.WriteLine("FILE:{0}, EXP:{1}, STRING:{2}, FORMAT: {3} ", filename, regex, strDate, format); return;
        }


        try
        {
            result = DateTime.ParseExact(strDate, format, null);
            Console.WriteLine("FILE:{0}, EXP:{1}, DATE-STRING:{2}, FORMAT:{3}, DATE:{4}.", filename, regex, strDate, format, result.ToString());
        }
        catch (FormatException)
        {
            Console.WriteLine("FILE:{0}, EXP:{1}, DATE-STRING:{2}, FORMAT:{3} << Check Format .", filename, regex, strDate, format); 
        }

   }
}