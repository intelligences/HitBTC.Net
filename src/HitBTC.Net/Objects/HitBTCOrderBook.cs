using System;
using System.Collections.Generic;
using System.Text;

namespace HitBTC.Net.Objects
{
    /// <summary>
    /// Order book
    /// </summary>
    public class HitBTCOrderBook
    {
        /// <summary>
        /// Timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Symbol
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// List of bids
        /// </summary>
        public IEnumerable<HitBTCOrderBookEntry> Bid { get; set; } = new List<HitBTCOrderBookEntry>();

        /// <summary>
        /// List of asks
        /// </summary>
        public IEnumerable<HitBTCOrderBookEntry> Ask { get; set; } = new List<HitBTCOrderBookEntry>();
    }
}
