namespace SearchService.Consumers
{
    using Contracts;
    using MassTransit;
    using MongoDB.Entities;
    using SearchService.Models;

    /// <summary>
    /// Defines the <see cref="AuctionFinishedConsumer" />
    /// </summary>
    public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
    {
        /// <summary>
        /// The Consume
        /// </summary>
        /// <param name="context">The context<see cref="ConsumeContext{AuctionFinished}"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            var auction = await DB.Find<Item>().OneAsync(context.Message.AuctionId);

            if (context.Message.ItemSold)
            {
                auction.Winner = context.Message.Winner;
                auction.SoldAmount = (int)context.Message.Amount;
            }

            auction.Status = "Finished";

            await auction.SaveAsync();
        }
    }
}
