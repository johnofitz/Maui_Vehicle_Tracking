
namespace L00177804_Project.Models
{
    public class NearBy
    {
        [JsonProperty("business_status")]
        public string BusinessStatus { get; set; }

        [JsonProperty("geometry")]
        public GoogleGeo Geometry { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("icon_background_color")]
        public string IconBackgroundColor { get; set; }

        [JsonProperty("icon_mask_base_uri")]
        public string IconMaskBaseUri { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("opening_hours")]
        public OpeningHours OpeningHours { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }

        [JsonProperty("user_ratings_total")]
        public int UserRating { get; set; }

        [JsonProperty("vicinity")]
        public string Vicinity { get; set; }

        [JsonProperty("price_level")]
        public int? PriceLevel { get; set; }

        public double Distance { get; set; }
  
    }
}
