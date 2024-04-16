using SchoolTripsReservationSystem.Core.Contracts;
using System.Text.RegularExpressions;

namespace SchoolTripsReservationSystem.Core.Extansions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IExcursionModel excursion)
        {
            string info = excursion.Name.Replace(" ", "-") + GetDescription(excursion.Description);
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);
            return info;
        }

        private static string GetDescription(string description)
        {
            description = string.Join("-", description.Split(" ").Take(3));

            return description;
        }
    }
}
