﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SchoolTripsReservationSystem.Core.Constants.MessageConstants;

namespace SchoolTripsReservationSystem.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";
        public const string LenghtMessage = "The field {0} must be between {2} and {1} long";
        public const string EikLenghtMessage = "The field {0} must be exact {1} symbol long";
        public const string EikExists = "EIK already exists.";
        public const string DurationMassage = "Duration must be between {1} and {2} days";
        public const string PriceMassage = "Price can not be a negative number";
        public const string RegionNotExists = "Region does not exists.";
    }
}
