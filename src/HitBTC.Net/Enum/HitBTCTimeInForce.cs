namespace HitBTC.Net.Enum
{
    public enum HitBTCTimeInForce
    {
        /// <summary>
        /// 'Good-Till-Cancel' order won't close until it is filled
        /// </summary>
        GTC,

        /// <summary>
        /// 'Immediate-Or-Cancel' order must be executed immediately. Any part of an IOC order that cannot be filled immediately will be cancelled
        /// </summary>
        IOC,

        /// <summary>
        /// 'Fill-Or-Kill' is a type of 'Time in Force' designation used in securities trading that instructs a brokerage to execute a transaction immediately and completely or not execute it at all
        /// </summary>
        FOK,

        /// <summary>
        /// 'Day' keeps the order active until the end of the trading day (UTC)
        /// </summary>
        Day,

        /// <summary>
        /// 'Good-Till-Date'. The date is specified in expireTime.
        /// </summary>
        GTD
    }
}
