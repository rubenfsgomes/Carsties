namespace Contracts
{
    /// <summary>
    /// Defines the <see cref="AuctionFinished" />
    /// </summary>
    public class AuctionFinished
    {
        /// <summary>
        /// Gets or sets a value indicating whether ItemSold
        /// </summary>
        public bool ItemSold { get; set; }

        /// <summary>
        /// Gets or sets the AuctionId
        /// </summary>
        public string AuctionId { get; set; }

        /// <summary>
        /// Gets or sets the Winner
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// Gets or sets the Seller
        /// </summary>
        public string Seller { get; set; }

        /// <summary>
        /// Gets or sets the Amount
        /// </summary>
        public int? Amount { get; set; }
    }
}
