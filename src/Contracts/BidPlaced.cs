namespace Contracts
{
    using System;

    /// <summary>
    /// Defines the <see cref="BidPlaced" />
    /// </summary>
    public class BidPlaced
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        public string Id { get; set; }

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
        public DateTime BidTime { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets the BidStatus
        /// </summary>
        public string BidStatus { get; set; }
    }
}
