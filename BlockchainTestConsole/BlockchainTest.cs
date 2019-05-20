using BlockChainLogic;
using Newtonsoft.Json;
using System;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace BlockchainTestConsole
{
    class BlockchainTest
    {
        static void Main(string[] args)
        {
            #region Part 1 and 2
            //Blockchain phillyCoin = new Blockchain();

            //phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Henry,receiver:MaHesh,amount:10}"));
            //phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:MaHesh,receiver:Henry,amount:5}"));
            //phillyCoin.AddBlock(new Block(DateTime.Now, null, "{sender:Mahesh,receiver:Henry,amount:5}"));


            ////Tampering with Data and test IsValid
            //Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
            //Console.WriteLine($"Update amount to 1000");
            //phillyCoin.Chain[1].Data = "{sender:Henry,receiver:MaHesh,amount:1000}";
            ////Recalculate hash of current block
            //Console.WriteLine($"Update the current block");
            //phillyCoin.Chain[1].Hash = phillyCoin.Chain[1].CalculateHash();
            //Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
            ////Recalculate hash of every blocks
            //// NOTE: Blockchain is a decentralized system. Tampering with one node could be easy but tampering with all the nodes in the system is impossible.
            //Console.WriteLine($"Update the entire chain");
            //phillyCoin.Chain[2].PreviousHash = phillyCoin.Chain[1].Hash;
            //phillyCoin.Chain[2].Hash = phillyCoin.Chain[2].CalculateHash();
            //phillyCoin.Chain[3].PreviousHash = phillyCoin.Chain[2].Hash;
            //phillyCoin.Chain[3].Hash = phillyCoin.Chain[3].CalculateHash();
            //Console.WriteLine($"Is Chain Valid: {phillyCoin.IsValid()}");
            #endregion

            #region Part 3 
            var startTime = DateTime.Now;

            Blockchain phillyCoin = new Blockchain();
            phillyCoin.CreateTransaction(new Transaction("Henry", "MaHesh", 10));
            phillyCoin.ProcessPendingTransactions("Bill");

            phillyCoin.CreateTransaction(new Transaction("MaHesh", "Henry", 5));
            phillyCoin.CreateTransaction(new Transaction("MaHesh", "Henry", 5));
            phillyCoin.ProcessPendingTransactions("Bill");

            var endTime = DateTime.Now;

            Console.WriteLine($"Duration: {endTime - startTime}");

            #endregion


            string blockJSON = JsonConvert.SerializeObject(phillyCoin, Formatting.Indented);
            Console.WriteLine(blockJSON);
            return;
        }
    }
}
