using System;

namespace ConsoleApp1
{
    public class AddressGenerator
    {
        private static string[] StreetNames = new[]
        {
            "Alpine",
            "Veith",
            "Grayhawk",
            "Forest",
            "Prairieview",
            "Del Mar",
            "Anthes",
            "Dakota",
            "Brickson Park",
            "Old Gate",
            "La Follette",
            "Blaine",
            "Continental",
            "Blue Bill Park",
            "Merry",
            "Canary",
            "Sloan",
            "Northwestern",
            "Northridge",
            "Di Loreto",
            "Cascade",
            "8th",
            "Forest Dale",
            "Arrowood",
            "Dunning",
            "Oak Valley",
            "Corben",
            "Sutherland",
            "Arrowood",
            "Pleasure",
            "Dawn",
            "Vidon",
            "Sunfield",
            "Loftsgordon",
            "Tony",
            "Warner",
            "West",
            "Stuart",
            "Park Meadow",
            "Leroy",
            "Delladonna",
            "Talisman",
            "Morrow",
            "Coolidge",
            "Northland",
            "Hintze",
            "Northwestern",
            "Golden Leaf",
            "Shopko",
            "Toban",
            "Declaration",
            "Goodland",
            "Vermont",
            "Clyde Gallagher",
            "Mandrake",
            "Clemons",
            "Duke",
            "Becker",
            "Londonderry",
            "Mayfield",
            "Sycamore",
            "Holmberg",
            "Bluestem",
            "Charing Cross",
            "Utah",
            "Rusk",
            "Thompson",
            "Erie",
            "Algoma",
            "Northwestern",
            "Melvin",
            "Mayer",
            "Pine View",
            "Pleasure",
            "Burrows",
            "Basil",
            "Packers",
            "Commercial",
            "Esker",
            "Helena",
            "Mallard",
            "Packers",
            "Riverside",
            "David",
            "Sloan",
            "Coleman",
            "Chinook",
            "Fieldstone",
            "Norway Maple",
            "Gina",
            "Raven",
            "Cardinal",
            "Bluejay",
            "Northview",
            "Browning",
            "Merry",
            "Bluestem",
            "Sherman",
            "Mitchell",
            "Birchwood"
        };

        private static string[] StreetSuffix = new[]
        {
            "Hill", "Drive", "Road", "Avenue", "Junction", "Place", "Lane", "Court", "Park", "Road", "Street"
        };

        private static string PostcodeLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
        
        public static string GetRandomStreetName()
        {
            var random = new Random();
            return $"{StreetNames[random.Next(StreetNames.Length)]} {StreetSuffix[random.Next(StreetSuffix.Length)]}";
        }

        public static string GetRandomPostcode()
        {
            var random = new Random();
            return
                $"N{random.Next(16)} {random.Next(10)}{PostcodeLetters[random.Next(PostcodeLetters.Length)]}{PostcodeLetters[random.Next(PostcodeLetters.Length)]}";
        }
    }
}