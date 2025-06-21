using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Models
{
    public class PlaceDetailModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string FormattedAddress { get; set; }
        public LocationModel Location { get; set; }
        public string[] Types { get; set; }
        public string NationalPhoneNumber { get; set; }
        public string InternationalPhoneNumber { get; set; }
        
        public float Rating { get; set; }
        public string GoogleMapsUri { get; set; }
        public string WebsiteUri { get; set; }
        public int UtcOffsetMinutes { get; set; }
        public string BusinessStatus { get; set; }
        public string PriceLevel { get; set; }
        public int UserRatingCount { get; set; }
        public ReviewModel[] Reviews { get; set; }
        public PhotoModel[] Photos { get; set; }
        public bool Takeout { get; set; }
        public bool Delivery { get; set; }
        public bool DineIn { get; set; }
        public bool ServesBreakfast { get; set; }
        public bool ServesLunch { get; set; }
        public bool ServesDinner { get; set; }
        public bool ServesBeer { get; set; }
        public bool ServesWine { get; set; }
        public RegularOpeningHoursModel RegularOpeningHours { get; set; }
        public string PrimaryType { get; set; }
        public string ShortFormattedAddress { get; set; }
        public TextModel EditorialSummary { get; set; }
        public bool OutdoorSeating { get; set; }
        public bool MenuForChildren { get; set; }
        public bool ServesDessert { get; set; }
        public bool ServesCoffee { get; set; }
        public bool GoodForChildren { get; set; }
        public bool AllowsDogs { get; set; }
        public bool Restroom { get; set; }
        public bool GoodForGroups { get; set; }
        public PaymentOptionsModel PaymentOptions { get; set; }
        public ParkingOptionsModel ParkingOptions { get; set; }
        public AccessibilityOptionsModel AccessibilityOptions { get; set; }
        public PriceRangeModel PriceRange { get; set; }

        
    }

    public class RegularOpeningHoursModel
    {
        public bool OpenNow { get; set; }
        public PeriodModel[] Periods { get; set; }
        public string[] WeekdayDescriptions { get; set; }
        public DateTime NextCloseTime { get; set; }
    }

    public class PeriodModel
    {
        public DateTimeModel Open { get; set; }
        public DateTimeModel Close { get; set; }
    }

    public class DateTimeModel
    {
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }

    public class PaymentOptionsModel
    {
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptsDebitCards { get; set; }
        public bool AcceptsCashOnly { get; set; }
        public bool AcceptsNfc { get; set; }
    }

    public class ParkingOptionsModel
    {
        public bool FreeParkingLot { get; set; }
    }

    public class AccessibilityOptionsModel
    {
        public bool WheelchairAccessibleParking { get; set; }
        public bool WheelchairAccessibleEntrance { get; set; }
        public bool WheelchairAccessibleRestroom { get; set; }
    }

    public class PriceRangeModel
    {
        public PriceModel StartPrice { get; set; }
        public PriceModel EndPrice { get; set; }
    }

    public class PriceModel
    {
        public string CurrencyCode { get; set; }
        public string Units { get; set; }
    }

    public class PhotoModel
    {
        public string Name { get; set; }
        public int WidthPx { get; set; }
        public int HeightPx { get; set; }
        public string FlagContentUri { get; set; }
        public string GoogleMapsUri { get; set; }

    }

    public class ReviewModel
    {
        public string Name { get; set; }
        public string RelativePublishTimeDescription { get; set; }
        public int Rating { get; set; }
        public TextModel Text { get; set; }
        public TextModel OriginalText { get; set; }
        public AuthorAttributionModel AuthorAttribution { get; set; }
        public DateTime PublishTime { get; set; }
        public string FlagContentUri { get; set; }
        public string GoogleMapsUri { get; set; }
       
    }
    public class TextModel
    {
        public string Text { get; set; }
        public string LanguageCode { get; set; }
    }

    public class AuthorAttributionModel
    {
        public string DisplayName { get; set; }
        public string Uri { get; set; }
        public string PhotoUri { get; set; }
    }
}
