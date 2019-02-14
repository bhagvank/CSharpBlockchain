using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBlockchain
{
    public class BlockChain
    {
        private  IList<Block>  blockChain ;

        

        public BlockChain()
        {
            InitBlockChain();
            AddBlock();
        }

        public void InitBlockChain()
        {
            blockChain = new List<Block>();
        }

        
        public IList<Block> GetBlockChain()
        {
           
               return blockChain;
        }
        public Block GetNewBlock()
        {
            return new Block(DateTime.Now, null, "{}");
        }

        public void AddBlock()
        {
            blockChain.Add(GetNewBlock());
        }
        
        public Block GetLastBlock()
        {
            return blockChain[blockChain.Count - 1];
        }

        public void AddBlock(Block block)
        {
            Block latestBlock = GetLastBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.Hash;
            block.Hash = block.GetHash();
            blockChain.Add(block);
        }

        public bool CheckValidity()
        {
            for (int i = 1; i < blockChain.Count; i++)
            {
                Block currentBlock = blockChain[i];
                Block previousBlock = blockChain[i - 1];

                if (currentBlock.Hash != currentBlock.GetHash())
                {
                    return false;
                }

                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
