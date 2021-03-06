﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace LiteDB.Engine
{
    /// <summary>
    /// Return all index nodes
    /// </summary>
    internal class IndexAll : Index
    {
        public IndexAll(string name, int order)
            : base(name, order)
        {
        }

        public override uint GetCost(CollectionIndex index)
        {
            // no analyzed index
            if (index.KeyCount == 0) return uint.MaxValue;

            // always worst cost - return all documents with no index use (just for order)
            return index.KeyCount;
        }

        public override IEnumerable<IndexNode> Execute(IndexService indexer, CollectionIndex index)
        {
            return indexer.FindAll(index, this.Order);
        }

        public override string ToString()
        {
            return string.Format("FULL INDEX SCAN({0})", this.Name);
        }
    }
}