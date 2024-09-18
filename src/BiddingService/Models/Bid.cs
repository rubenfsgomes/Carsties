namespace BiddingService.Models
{
    using MongoDB.Entities;

    /// <summary>
    /// Defines the <see cref="Bid" />
    /// </summary>
    public class Bid : Entity
    {
        /// <summary>
        /// Gets or sets the AuctionId
        /// </summary>
        public string AuctionId { get; set; }

        /// <summary>
        /// Gets or sets the Bidder
        /// </summary>
        public string Bidder { get; set; }

        /// <summary>
        /// Gets or sets the BidTime
        /// </summary>
        public DateTime BidTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the BidStatus
        /// </summary>
        public BidStatus BidStatus { get; set; }
    }
}
