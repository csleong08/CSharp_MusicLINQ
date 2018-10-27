using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================
            //A list of all artists
            System.Console.WriteLine("List of all Artists");
            foreach (var item in Artists)
            {
                System.Console.WriteLine(item.ArtistName);
            }
            // //There is only one artist in this collection from Mount Vernon, what is their name and age?
            // System.Console.WriteLine("Artist from Mount Vernon");
            // var MountVernon = Artists.Where(p => p.Hometown == "Mount Vernon").Select(p => new {p.RealName, p.Age});
            // foreach (var item in MountVernon)
            // {
            //     System.Console.WriteLine(item.RealName);
            //     System.Console.WriteLine(item.Age);
            // }
            // //Who is the youngest artist in our collection of artists?
            // System.Console.WriteLine("The Youngest Artist");
            // var Youngest = Artists.OrderBy(p => p.Age).First();
            // System.Console.WriteLine(Youngest.ArtistName);
            // System.Console.WriteLine(Youngest.RealName);
            // System.Console.WriteLine(Youngest.Age);
            // System.Console.WriteLine(Youngest.Hometown);
            // System.Console.WriteLine(Youngest.Group);

            // //Display all artists with 'William' somewhere in their real name
            // System.Console.WriteLine("Artists named 'William'");
            // var Williams = Artists.Where(p => p.RealName.Contains("William"));
            // foreach (var item in Williams)
            // {
            //     System.Console.WriteLine(item.RealName);
            // }
            // //Display all groups with names less than 8 characters in length.
            // System.Console.WriteLine("Groups with <8 chars in length");
            // var LessThanEight = Groups.Where(p => p.GroupName.Length <8 );
            // foreach (var item in LessThanEight)
            // {
            //     System.Console.WriteLine(item.GroupName);
            // }
            // //Display the 3 oldest artist from Atlanta
            // System.Console.WriteLine("Three Oldest Artists from Atlanta");
            // var ATLThreeOldest = Artists.OrderByDescending(p => p.Age).Where(p => p.Hometown == "Atlanta").Take(3);
            // foreach (var item in ATLThreeOldest)
            // {
            //     System.Console.WriteLine(item.ArtistName);
            //     System.Console.WriteLine(item.Age);
            // }
            // //(Optional) Display the Group Name of all groups that have members that are not from New York City
            // System.Console.WriteLine("Non-NY Groups");
            // var NonNYGroups = Artists.Join(Groups, GroupArtists => GroupArtists.GroupId, group => group.Id, (GroupArtists, group) => new {Artists = GroupArtists, Groups = group})
            // .Where(p => p.Artists.Hometown != "New York City");
            
            // foreach (var item in NonNYGroups)
            // {
            //     System.Console.WriteLine(item.Groups.GroupName);
            //     System.Console.WriteLine(item.Artists.RealName);
            //     System.Console.WriteLine(item.Artists.Hometown);
            // }
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            // System.Console.WriteLine("Wu-Tang Clan members");
            var WuTangMembers = Artists.Join(Groups, GroupArtists => GroupArtists.GroupId, 
            group => group.Id, (GroupArtists, group) => new {Artists = GroupArtists, Groups = group})
            .Where(p => p.Groups.GroupName == "Wu-Tang Clan");
            foreach (var item in WuTangMembers)
            {
                System.Console.WriteLine(item.Artists.ArtistName);
            }
	    Console.WriteLine(Groups.Count);
        }
    }
}
