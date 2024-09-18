namespace SearchService.Consumers
{
    using Contracts;
    using MassTransit;
    using MongoDB.Entities;
    using SearchService.Models;

    /// <summary>
    /// Defines the <see cref="BidPlacedConsumer" />
    /// </summary>
    public class BidPlacedConsumer : IConsumer<BidPlaced>
    {
        /// <summary>
        /// The Consume
        /// </summary>
        /// <param name="context">The context<see cref="ConsumeContext{BidPlaced}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Consume(ConsumeContext<BidPlaced> context)
        {
            Console.WriteLine("--> Consuming bid placed");

            var auction = await DB.Find<Item>().OneAsync(context.Message.AuctionId);

            if (context.Message.BidStatus.Contains("Accepted")
                && context.Message.Amount > auction.CurrentHighBid)
            {
                auction.CurrentHighBid = context.Message.Amount;
                await auction.SaveAsync();
            }
        }
    }
}
