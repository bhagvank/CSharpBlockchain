using System;
using System.Collections.Generic;

namespace CSharpBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            BlockChain blockchain = new BlockChain();
            blockchain.AddBlock(new Block(DateTime.Now, null, "{sender:James,receiver:John,amount:100}"));
            blockchain.AddBlock(new Block(DateTime.Now, null, "{sender:John,receiver:James,amount:30}"));
            blockchain.AddBlock(new Block(DateTime.Now, null, "{sender:John,receiver:James,amount:40}"));

     
            Console.WriteLine($"Block  Chain Validity: {blockchain.CheckValidity()}");

            Console.WriteLine($"Update amount to 2000");
            IList<Block> blocks = blockchain.GetBlockChain();
            blocks[1].Data = "{sender:James,receiver:John,amount:2000}";

            Console.WriteLine($"Block  Chain Validity: {blockchain.CheckValidity()}");

            Console.WriteLine($"Get hash");
            //IList<Block> blocks = blockchain.GetBlocks();
            blocks[1].Hash = blocks[1].GetHash();

            Console.WriteLine($"Block  Chain Validity: {blockchain.CheckValidity()}");

            Console.WriteLine($"Get the Latest BlockChain");
            blocks[2].PreviousHash = blocks[1].Hash;
            blocks[2].Hash = blocks[2].GetHash();
            blocks[3].PreviousHash = blocks[2].Hash;
            blocks[3].Hash = blocks[3].GetHash();

            Console.WriteLine($"Block  Chain Validity: {blockchain.CheckValidity()}");
        }
    }
}
