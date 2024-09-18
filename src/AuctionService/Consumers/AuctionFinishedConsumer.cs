namespace AuctionService.Consumers
{
    using AuctionService.Data;
    using AuctionService.Entities;
    using Contracts;
    using MassTransit;

    /// <summary>
    /// Defines the <see cref="AuctionFinishedConsumer" />
    /// </summary>
    public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
    {
        /// <summary>
        /// Defines the _dbContext
        /// </summary>
        private readonly AuctionDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionFinishedConsumer"/> class.
        /// </summary>
        /// <param name="dbContext">The dbContext<see cref="AuctionDbContext"/></param>
        public AuctionFinishedConsumer(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// The Consume
        /// </summary>
        /// <param name="context">The context<see cref="ConsumeContext{AuctionFinished}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            Console.WriteLine("--> Consuming auction finished");

            var auction = await _dbContext.Auctions.FindAsync(Guid.Parse(context.Message.AuctionId));

            if (context.Message.ItemSold)
            {
                auction.Winner = context.Message.Winner;
                auction.SoldAmount = context.Message.Amount;
            }

            auction.Status = auction.SoldAmount > auction.ReservePrice
                ? Status.Finished : Status.ReserveNotMet;

            await _dbContext.SaveChangesAsync();
        }
    }
}
