namespace BiddingService.Models
{
    using MongoDB.Entities;

    /// <summary>
    /// Defines the <see cref="Auction" />
    /// </summary>
    public class Auction : Entity
    {
        /// <summary>
        /// Gets or sets the AuctionEnd
        /// </summary>
        public DateTime AuctionEnd { get; set; }

        /// <summary>
        /// Gets or sets the Seller
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// Gets or sets the ReservePrice
        /// </summary>
        public int ReservePrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Finished
        /// </summary>
        public bool Finished { get; set; }
    }
}
