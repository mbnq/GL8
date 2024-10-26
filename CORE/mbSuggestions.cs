
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using System.Linq;
using System.Windows.Forms;

namespace GL8.CORE
{
    public class mbSuggestions
    {
        static public AutoCompleteStringCollection suggestionsCollectionCategory = new AutoCompleteStringCollection();

        static public string[] categorySuggestions0 = new string[]
        {
            "Accounting",
            "Advertising",
            "Airlines",
            "Analytics",
            "Antivirus",
            "Apps",
            "Art",
            "Auctions",
            "Automotive",
            "Backup Services",
            "Banking",
            "Books",
            "Business",
            "Car Rental",
            "Charity",
            "Children",
            "Cloud Services",
            "Communication",
            "Construction",
            "Consulting",
            "Cryptocurrency",
            "Dating",
            "Delivery Services",
            "Design",
            "E-commerce",
            "Education",
            "Email",
            "Energy",
            "Entertainment",
            "Events",
            "Fashion",
            "Finance",
            "Fitness",
            "Food Delivery",
            "Forums",
            "Gaming",
            "Government",
            "Health",
            "Home",
            "Hospitality",
            "Hosting",
            "Insurance",
            "Internet Service Provider",
            "Investments",
            "Job Search",
            "Kids",
            "Language Learning",
            "Legal",
            "Logistics",
            "Manufacturing",
            "Marketing",
            "Media",
            "Messaging",
            "Music",
            "News",
            "Non-Profit",
            "Online Courses",
            "Online Storage",
            "Password Manager",
            "Payment Services",
            "Personal",
            "Pets",
            "Photography",
            "Printing",
            "Productivity",
            "Programming",
            "Project Management",
            "Public Services",
            "Real Estate",
            "Recruitment",
            "Research",
            "Restaurants",
            "Retail",
            "Reviews",
            "Ride Sharing",
            "Science",
            "Security",
            "Shopping",
            "Smart Home",
            "Social Media",
            "Software",
            "Sports",
            "Streaming",
            "Subscriptions",
            "Support",
            "Survey",
            "Telecommunications",
            "Tickets",
            "Time Tracking",
            "Tourism",
            "Training",
            "Transportation",
            "Travel",
            "Utilities",
            "Vehicle",
            "Video Conferencing",
            "Virtual Assistant",
            "VPN",
            "Weather",
            "Web Development",
            "Web Hosting",
            "Wellness",
            "Work",
            "Writing",
            "Miscellaneous"
        };

        static public string[] categorySuggestions1 = new string[]
        {
            "Test",
            "Temp",
            "Dev"
        };

        static public string[] categorySuggestions = categorySuggestions0.Concat(categorySuggestions1).ToArray();
        public static AutoCompleteStringCollection mbBuildSuggestionsForCategory()
        {
            var suggestionsCollectionCategory = new AutoCompleteStringCollection();

            foreach (string suggestion in categorySuggestions)
            {
                suggestionsCollectionCategory.Add(suggestion);
            }

            return suggestionsCollectionCategory;
        }
    }
}