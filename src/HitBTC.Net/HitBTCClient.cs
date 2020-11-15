using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using HitBTC.Net.Enum;
using HitBTC.Net.Interfaces;
using HitBTC.Net.Objects;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HitBTC.Net
{
    public class HitBTCClient : RestClient, IHitBTCClient
    {
        private static HitBTCClientOptions defaultOptions = new HitBTCClientOptions();
        private static HitBTCClientOptions DefaultOptions => defaultOptions.Copy<HitBTCClientOptions>();

        #region constructor
        /// <summary>
        /// Creates a new socket client using the default options
        /// </summary>
        public HitBTCClient() : this(DefaultOptions)
        {
        }

        /// <summary>
        /// Create a new instance of the HitBTCClient with the provided options
        /// </summary>
        public HitBTCClient(HitBTCClientOptions options) : base(options, options.ApiCredentials == null ? null : new HitBTCRestAuthenticationProvider(options.ApiCredentials))
        {
        }
        #endregion constructor

        public static void SetDefaultOptions(HitBTCClientOptions options)
        {
            defaultOptions = options;
        }

        /// <summary>
        /// Set the API key and secret. Api keys can be managed at https://hitbtc.com/settings/api-keys
        /// </summary>
        /// <param name="apiKey">The api key</param>
        /// <param name="apiSecret">The api secret</param>
        public void SetApiCredentials(string apiKey, string apiSecret)
        {
            SetAuthenticationProvider(new HitBTCRestAuthenticationProvider(new ApiCredentials(apiKey, apiSecret)));
        }

        /// <summary>
        /// Get a list of all currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of currencies</returns>
        public WebCallResult<IEnumerable<HitBTCCurrency>> GetCurrencies(CancellationToken ct = default) => GetCurrenciesAsync(ct).Result;

        /// <summary>
        /// Get a list of all currencies
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of currencies</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCCurrency>>> GetCurrenciesAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCCurrency>>(GetUrl("public/currency"), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about specified currency
        /// </summary>
        /// <param name="symbol">The currency to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Currency info</returns>
        public WebCallResult<HitBTCCurrency> GetCurrency(string currency, CancellationToken ct = default) => GetCurrencyAsync(currency, ct).Result;

        /// <summary>
        /// Get information about specified currency
        /// </summary>
        /// <param name="symbol">The currency to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Currency info</returns>
        public async Task<WebCallResult<HitBTCCurrency>> GetCurrencyAsync(string currency, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCCurrency>(GetUrl("public/currency/" + currency), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a list of all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of symbols</returns>
        public WebCallResult<IEnumerable<HitBTCSymbol>> GetSymbols(CancellationToken ct = default) => GetSymbolsAsync(ct).Result;

        /// <summary>
        /// Get a list of all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of symbols</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCSymbol>>> GetSymbolsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCSymbol>>(GetUrl("public/symbol"), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get information about specified symbol
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Symbol info</returns>
        public WebCallResult<HitBTCSymbol> GetSymbol(string symbol, CancellationToken ct = default) => GetSymbolAsync(symbol, ct).Result;

        /// <summary>
        /// Get information about specified symbol
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Symbol info</returns>
        public async Task<WebCallResult<HitBTCSymbol>> GetSymbolAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCSymbol>(GetUrl("public/symbol/" + symbol), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get tickers for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of tickers</returns>
        public WebCallResult<IEnumerable<HitBTCTicker>> GetTickers(CancellationToken ct = default) => GetTickersAsync(ct).Result;

        /// <summary>
        /// Get tickers for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of tickers</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCTicker>>> GetTickersAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCTicker>>(GetUrl("public/ticker"), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get ticker for a certain symbol
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Ticker info</returns>
        public WebCallResult<HitBTCTicker> GetTicker(string symbol, CancellationToken ct = default) => GetTickerAsync(symbol, ct).Result;

        /// <summary>
        /// Get ticker for a certain symbol
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Ticker info</returns>
        public async Task<WebCallResult<HitBTCTicker>> GetTickerAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCTicker>(GetUrl("public/ticker/" + symbol), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get trades for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of trades</returns>
        public WebCallResult<IDictionary<string, IEnumerable<HitBTCTrade>>> GetTrades(CancellationToken ct = default) => GetTradesAsync(ct).Result;

        /// <summary>
        /// Get trades for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of trades</returns>
        public async Task<WebCallResult<IDictionary<string, IEnumerable<HitBTCTrade>>>> GetTradesAsync(CancellationToken ct = default)
        {
            return await SendRequest<IDictionary<string, IEnumerable<HitBTCTrade>>>(GetUrl("public/trades"), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get trades for specified symbols
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of trades</returns>
        public WebCallResult<IEnumerable<HitBTCTrade>> GetTrades(string symbol, CancellationToken ct = default) => GetTradesAsync(symbol, ct).Result;

        /// <summary>
        /// Get trades for specified symbols
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of trades</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCTrade>>> GetTradesAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCTrade>>(GetUrl("public/trades/" + symbol), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Order Books for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of Order Books</returns>
        public WebCallResult<IDictionary<string, HitBTCOrderBook>> GetOrderBooks(CancellationToken ct = default) => GetOrderBooksAsync(ct).Result;

        /// <summary>
        /// Get Order Books for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of Order Books</returns>
        public async Task<WebCallResult<IDictionary<string, HitBTCOrderBook>>> GetOrderBooksAsync(CancellationToken ct = default)
        {
            return await SendRequest<IDictionary<string, HitBTCOrderBook>>(GetUrl("public/orderbook"), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Order Book for specified symbols
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Order Book</returns>
        public WebCallResult<HitBTCOrderBook> GetOrderBook(string symbol, CancellationToken ct = default) => GetOrderBookAsync(symbol, ct).Result;

        /// <summary>
        /// Get Order Book for specified symbols
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Order Book</returns>
        public async Task<WebCallResult<HitBTCOrderBook>> GetOrderBookAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCOrderBook>(GetUrl("public/orderbook/" + symbol), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get candles for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of candles</returns>
        public WebCallResult<IDictionary<string, IEnumerable<HitBTCCandle>>> GetCandles(CancellationToken ct = default) => GetCandlesAsync(ct).Result;

        /// <summary>
        /// Get candles for all symbols
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of candles</returns>
        public async Task<WebCallResult<IDictionary<string, IEnumerable<HitBTCCandle>>>> GetCandlesAsync(CancellationToken ct = default)
        {
            return await SendRequest<IDictionary<string, IEnumerable<HitBTCCandle>>>(GetUrl("public/candles"), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get candles for specified symbols
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of candles</returns>
        public WebCallResult<IEnumerable<HitBTCCandle>> GetCandles(string symbol, CancellationToken ct = default) => GetCandlesAsync(symbol, ct).Result;

        /// <summary>
        /// Get candles for specified symbols
        /// </summary>
        /// <param name="symbol">The symbol to get info for</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>List of candles</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCCandle>>> GetCandlesAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCCandle>>(GetUrl("public/candles/" + symbol), HttpMethod.Get, ct).ConfigureAwait(false);
        }

        /// <summary>
        /// Get trading balance
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns the user's trading balance.</returns>
        public WebCallResult<IEnumerable<HitBTCBalance>> GetTradingBalance(CancellationToken ct = default) => GetTradingBalanceAsync(ct).Result;

        /// <summary>
        /// Get trading balance
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns the user's trading balance.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCBalance>>> GetTradingBalanceAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCBalance>>(GetUrl("trading/balance"), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return array of active orders.</returns>
        public WebCallResult<IEnumerable<HitBTCOrder>> GetOrders(CancellationToken ct = default) => GetOrdersAsync(ct).Result;

        /// <summary>
        /// Get orders
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return array of active orders.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCOrder>>> GetOrdersAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCOrder>>(GetUrl("order"), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get order by client order id
        /// </summary>
        /// <param name="clientOrderid">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return active order.</returns>
        public WebCallResult<HitBTCOrder> GetOrder(string clientOrderid, CancellationToken ct = default) => GetOrderAsync(clientOrderid, ct).Result;

        /// <summary>
        /// Get order by client order id
        /// </summary>
        /// <param name="clientOrderid">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return active order.</returns>
        public async Task<WebCallResult<HitBTCOrder>> GetOrderAsync(string clientOrderid, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCOrder>(GetUrl("order/" + clientOrderid), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="side">Trade side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price. Required for limit order types</param>
        /// <param name="stopPrice">Required for stop-limit and stop-market orders</param>
        /// <param name="timeInForce">Accepted values: GTC, IOC, FOK, Day, GTD <see cref="HitBTCTimeInForce"/></param>
        /// <param name="expireTime">Required for orders with timeInForce = GTD</param>
        /// <param name="clientOrderId">Optional parameter. If it is skipped, it will be generated by the Server.Uniqueness must be guaranteed within a single trading day, including all active orders.</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.. See the symbol's tickSize and quantityIncrement.</param>
        /// <param name="postOnly">If your post-only order causes a match with a pre-existing order as a taker, then the order will be cancelled.</param>
        /// <param name="ct"></param>
        /// <returns>Return new order</returns>
        public WebCallResult<HitBTCOrder> CreateOrder(
            string symbol,
            HitBTCSide side,
            decimal quantity,
            decimal price = -1,
            decimal stopPrice = -1,
            HitBTCTimeInForce timeInForce = HitBTCTimeInForce.Day,
            DateTime expireTime = default,
            string clientOrderId = null,
            bool strictValidate = true,
            bool postOnly = false,
            CancellationToken ct = default
        ) => CreateOrderAsync(
            symbol,
            side,
            quantity,
            price,
            stopPrice,
            timeInForce,
            expireTime,
            clientOrderId,
            strictValidate ,
            postOnly,
            ct
        ).Result;

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="side">Trade side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price. Required for limit order types</param>
        /// <param name="stopPrice">Required for stop-limit and stop-market orders</param>
        /// <param name="timeInForce">Accepted values: GTC, IOC, FOK, Day, GTD <see cref="HitBTCTimeInForce"/></param>
        /// <param name="expireTime">Required for orders with timeInForce = GTD</param>
        /// <param name="clientOrderId">Optional parameter. If it is skipped, it will be generated by the Server.Uniqueness must be guaranteed within a single trading day, including all active orders.</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.. See the symbol's tickSize and quantityIncrement.</param>
        /// <param name="postOnly">If your post-only order causes a match with a pre-existing order as a taker, then the order will be cancelled.</param>
        /// <param name="ct"></param>
        /// <returns>Return new order</returns>
        public async Task<WebCallResult<HitBTCOrder>> CreateOrderAsync(
            string symbol, 
            HitBTCSide side, 
            decimal quantity, 
            decimal price = -1, 
            decimal stopPrice = -1,
            HitBTCTimeInForce timeInForce = HitBTCTimeInForce.Day, 
            DateTime expireTime = default, 
            string clientOrderId = null, 
            bool strictValidate = true,
            bool postOnly = false,
            CancellationToken ct = default
        ) {
            HitBTCOrderType orderType = HitBTCOrderType.Market;

            if (price != -1 && stopPrice == -1)
                orderType = HitBTCOrderType.Limit;
            else if (price == -1 && stopPrice != -1)
                orderType = HitBTCOrderType.StopMarket;
            else if (price != -1 && stopPrice != -1)
                orderType = HitBTCOrderType.StopLimit;

            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("clientOrderid", clientOrderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("side", side.ToString().ToLower());
            parameters.AddOptionalParameter("type", orderType.ToString().ToLower());
            parameters.AddOptionalParameter("quantity", quantity);
            parameters.AddOptionalParameter("timeInForce", timeInForce.ToString());
            parameters.AddOptionalParameter("price", price);
            parameters.AddOptionalParameter("stopPrice", stopPrice);
            if (timeInForce == HitBTCTimeInForce.GTD)
            {
                parameters.AddOptionalParameter("expireTime", expireTime);
            }
            parameters.AddOptionalParameter("strictValidate", strictValidate);
            parameters.AddOptionalParameter("postOnly", postOnly);

            return await SendRequest<HitBTCOrder>(GetUrl("order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel orders
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return active order.</returns>
        public WebCallResult<IEnumerable<HitBTCOrder>> CancelOrders(CancellationToken ct = default) => CancelOrdersAsync(ct).Result;

        /// <summary>
        /// Cancel orders
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return active order.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCOrder>>> CancelOrdersAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCOrder>>(GetUrl("order"), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel orders
        /// </summary>
        /// <param name="clientOrderId">Client order ID</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return active order.</returns>
        public WebCallResult<HitBTCOrder> CancelOrder(string clientOrderId, CancellationToken ct = default) => CancelOrderAsync(clientOrderId, ct).Result;

        /// <summary>
        /// Cancel orders
        /// </summary>
        /// <param name="clientOrderId">Client order ID</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Return active order.</returns>
        public async Task<WebCallResult<HitBTCOrder>> CancelOrderAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCOrder>(GetUrl("order/" + clientOrderId), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }


        /// <summary>
        /// Get trading comission
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trading comission.</returns>
        public WebCallResult<HitBTCComission> GetTradingComission(string symbol, CancellationToken ct = default) => GetTradingComissionAsync(symbol, ct).Result;

        /// <summary>
        /// Get trading comission
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Trading comission.</returns>
        public async Task<WebCallResult<HitBTCComission>> GetTradingComissionAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCComission>(GetUrl("trading/fee/" + symbol), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Isolated Margin Accounts
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Margin Accounts</returns>
        public WebCallResult<IEnumerable<HitBTCMarginAccount>> GetIsolatedMarginAccounts(CancellationToken ct = default) => GetIsolatedMarginAccountsAsync(ct).Result;

        /// <summary>
        /// Get Isolated Margin Accounts
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Margin Accounts</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCMarginAccount>>> GetIsolatedMarginAccountsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCMarginAccount>>(GetUrl("margin/account"), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieve All Margin
        /// </summary>
        /// <remarks>Closes all positions and then closes all Isolated Margin Accounts. This will completely free up any balance reserved for margin purposes.</remarks>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns list of the closed Isolated Margin Accounts.</returns>
        public WebCallResult<IEnumerable<HitBTCMarginAccount>> RetrieveAllMargin(CancellationToken ct = default) => RetrieveAllMarginAsync(ct).Result;

        /// <summary>
        /// Retrieve All Margin
        /// </summary>
        /// <remarks>Closes all positions and then closes all Isolated Margin Accounts. This will completely free up any balance reserved for margin purposes.</remarks>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns list of the closed Isolated Margin Accounts.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCMarginAccount>>> RetrieveAllMarginAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCMarginAccount>>(GetUrl("margin/account"), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Isolated Margin Account
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns Isolated Margin Account details by symbol.</returns>
        public WebCallResult<HitBTCMarginAccount> GetIsolatedMarginAccount(string symbol, CancellationToken ct = default) => GetIsolatedMarginAccountAsync(symbol, ct).Result;

        /// <summary>
        /// Get Isolated Margin Account
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns Isolated Margin Account details by symbol.</returns>
        public async Task<WebCallResult<HitBTCMarginAccount>> GetIsolatedMarginAccountAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCMarginAccount>(GetUrl("margin/account/" + symbol), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Create/Update Isolated Margin Account
        /// </summary>
        /// <remarks>Creates or updates margin account. Setting margin balance to zero will lead to closing margin account and retrieval all formerly reserved funds to the trading account.</remarks>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginBalance">Amount of currency reserved.</param>
        /// <param name="strictValidate">The value indicating whether the marginBalance going to be checked for correct non exponential format and currency precision.</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns margin account details.</returns>
        public WebCallResult<HitBTCMarginAccount> CreateOrUpdateIsolatedMarginAccount(string symbol, decimal marginBalance, bool strictValidate = true, CancellationToken ct = default) => CreateOrUpdateIsolatedMarginAccountAsync(symbol, marginBalance, strictValidate, ct).Result;

        /// <summary>
        /// Create/Update Isolated Margin Account
        /// </summary>
        /// <remarks>Creates or updates margin account. Setting margin balance to zero will lead to closing margin account and retrieval all formerly reserved funds to the trading account.</remarks>
        /// <param name="symbol">Symbol</param>
        /// <param name="marginBalance">Amount of currency reserved.</param>
        /// <param name="strictValidate">The value indicating whether the marginBalance going to be checked for correct non exponential format and currency precision.</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns margin account details.</returns>
        public async Task<WebCallResult<HitBTCMarginAccount>> CreateOrUpdateIsolatedMarginAccountAsync(string symbol, decimal marginBalance, bool strictValidate = true, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCMarginAccount>(GetUrl("margin/account/" + symbol + "?marginBalance=" + marginBalance), HttpMethod.Put, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Close Isolated Margin Account
        /// </summary>
        /// <remarks>Closes Isolated Margin Account by symbol. This will completely free up any balance reserved for margin purposes, and all open positions will be closed at market price.</remarks>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns closed Isolated Margin Account details.</returns>
        public WebCallResult<HitBTCMarginAccount> CloseIsolatedMarginAccount(string symbol, CancellationToken ct = default) => CloseIsolatedMarginAccountAsync(symbol, ct).Result;

        /// <summary>
        /// Close Isolated Margin Account
        /// </summary>
        /// <remarks>Closes Isolated Margin Account by symbol. This will completely free up any balance reserved for margin purposes, and all open positions will be closed at market price.</remarks>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns closed Isolated Margin Account details.</returns>
        public async Task<WebCallResult<HitBTCMarginAccount>> CloseIsolatedMarginAccountAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCMarginAccount>(GetUrl("margin/account/" + symbol), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Margin Positions
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of open positions.</returns>
        public WebCallResult<IEnumerable<HitBTCPosition>> GetMarginPositions(CancellationToken ct = default) => GetMarginPositionsAsync(ct).Result;

        /// <summary>
        /// Get Margin Positions
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of open positions.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCPosition>>> GetMarginPositionsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCPosition>>(GetUrl("margin/position"), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Close Margin Positions
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of the successfully closed margin positions.</returns>
        public WebCallResult<IEnumerable<HitBTCPosition>> CloseMarginPositions(CancellationToken ct = default) => CloseMarginPositionsAsync(ct).Result;

        /// <summary>
        /// Close Margin Positions
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of the successfully closed margin positions.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCPosition>>> CloseMarginPositionsAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCPosition>>(GetUrl("margin/position"), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Margin Position
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns opened position for the requested symbol.</returns>
        public WebCallResult<HitBTCPosition> GetMarginPosition(string symbol, CancellationToken ct = default) => GetMarginPositionAsync(symbol, ct).Result;

        /// <summary>
        /// Get Margin Position
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns opened position for the requested symbol.</returns>
        public async Task<WebCallResult<HitBTCPosition>> GetMarginPositionAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCPosition>(GetUrl("margin/position/" + symbol), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Close Margin Position
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of the successfully closed margin positions.</returns>
        public WebCallResult<HitBTCPosition> CloseMarginPosition(string symbol, CancellationToken ct = default) => CloseMarginPositionAsync(symbol, ct).Result;

        /// <summary>
        /// Close Margin Position
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of the successfully closed margin positions.</returns>
        public async Task<WebCallResult<HitBTCPosition>> CloseMarginPositionAsync(string symbol, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCPosition>(GetUrl("margin/position/" + symbol), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Active Margin Orders
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns an array of the active margin orders.</returns>
        public WebCallResult<IEnumerable<HitBTCOrder>> GetActiveMarginOrders(CancellationToken ct = default) => GetActiveMarginOrdersAsync(ct).Result;

        /// <summary>
        /// Close Margin Position
        /// </summary>
        /// <param name="symbol">Symbol</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of the successfully closed margin positions.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCOrder>>> GetActiveMarginOrdersAsync(CancellationToken ct = default)
        {
            return await SendRequest<IEnumerable<HitBTCOrder>>(GetUrl("margin/order"), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Active Margin Order
        /// </summary>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns an active order by clientOrderId.</returns>
        public WebCallResult<HitBTCOrder> GetActiveMarginOrder(string clientOrderId, CancellationToken ct = default) => GetActiveMarginOrderAsync(clientOrderId, ct).Result;

        /// <summary>
        /// Get Active Margin Order
        /// </summary>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns an active order by clientOrderId.</returns>
        public async Task<WebCallResult<HitBTCOrder>> GetActiveMarginOrderAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCOrder>(GetUrl("margin/order/" + clientOrderId), HttpMethod.Get, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Create margin order
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="side">Trade side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price. Required for limit order types</param>
        /// <param name="stopPrice">Required for stop-limit and stop-market orders</param>
        /// <param name="timeInForce">Accepted values: GTC, IOC, FOK, Day, GTD <see cref="HitBTCTimeInForce"/></param>
        /// <param name="expireTime">Required for orders with timeInForce = GTD</param>
        /// <param name="clientOrderId">Optional parameter. If it is skipped, it will be generated by the Server.Uniqueness must be guaranteed within a single trading day, including all active orders.</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.. See the symbol's tickSize and quantityIncrement.</param>
        /// <param name="postOnly">If your post-only order causes a match with a pre-existing order as a taker, then the order will be cancelled.</param>
        /// <param name="ct"></param>
        /// <returns>Return new margin order</returns>
        public WebCallResult<HitBTCOrder> CreateMarginOrder(
            string symbol,
            HitBTCSide side,
            decimal quantity,
            decimal price = -1,
            decimal stopPrice = -1,
            HitBTCTimeInForce timeInForce = HitBTCTimeInForce.Day,
            DateTime expireTime = default,
            string clientOrderId = null,
            bool strictValidate = true,
            bool postOnly = false,
            CancellationToken ct = default
        ) => CreateMarginOrderAsync(
            symbol,
            side,
            quantity,
            price,
            stopPrice,
            timeInForce,
            expireTime,
            clientOrderId,
            strictValidate,
            postOnly,
            ct
        ).Result;

        /// <summary>
        /// Create order
        /// </summary>
        /// <param name="symbol">Trading symbol</param>
        /// <param name="side">Trade side</param>
        /// <param name="quantity">Order quantity</param>
        /// <param name="price">Order price. Required for limit order types</param>
        /// <param name="stopPrice">Required for stop-limit and stop-market orders</param>
        /// <param name="timeInForce">Accepted values: GTC, IOC, FOK, Day, GTD <see cref="HitBTCTimeInForce"/></param>
        /// <param name="expireTime">Required for orders with timeInForce = GTD</param>
        /// <param name="clientOrderId">Optional parameter. If it is skipped, it will be generated by the Server.Uniqueness must be guaranteed within a single trading day, including all active orders.</param>
        /// <param name="strictValidate">Price and quantity will be checked for incrementation within the symbol’s tick size and quantity step.. See the symbol's tickSize and quantityIncrement.</param>
        /// <param name="postOnly">If your post-only order causes a match with a pre-existing order as a taker, then the order will be cancelled.</param>
        /// <param name="ct"></param>
        /// <returns>Return new order</returns>
        public async Task<WebCallResult<HitBTCOrder>> CreateMarginOrderAsync(
            string symbol,
            HitBTCSide side,
            decimal quantity,
            decimal price = -1,
            decimal stopPrice = -1,
            HitBTCTimeInForce timeInForce = HitBTCTimeInForce.Day,
            DateTime expireTime = default,
            string clientOrderId = null,
            bool strictValidate = true,
            bool postOnly = false,
            CancellationToken ct = default
        )
        {
            HitBTCOrderType orderType = HitBTCOrderType.Market;

            if (price != -1 && stopPrice == -1)
                orderType = HitBTCOrderType.Limit;
            else if (price == -1 && stopPrice != -1)
                orderType = HitBTCOrderType.StopMarket;
            else if (price != -1 && stopPrice != -1)
                orderType = HitBTCOrderType.StopLimit;

            var parameters = new Dictionary<string, object>();

            parameters.AddOptionalParameter("clientOrderid", clientOrderId);
            parameters.AddOptionalParameter("symbol", symbol);
            parameters.AddOptionalParameter("side", side.ToString().ToLower());
            parameters.AddOptionalParameter("type", orderType.ToString().ToLower());
            parameters.AddOptionalParameter("quantity", quantity);
            parameters.AddOptionalParameter("timeInForce", timeInForce.ToString());
            parameters.AddOptionalParameter("price", price);
            parameters.AddOptionalParameter("stopPrice", stopPrice);
            if (timeInForce == HitBTCTimeInForce.GTD)
            {
                parameters.AddOptionalParameter("expireTime", expireTime);
            }
            parameters.AddOptionalParameter("strictValidate", strictValidate);
            parameters.AddOptionalParameter("postOnly", postOnly);

            return await SendRequest<HitBTCOrder>(GetUrl("margin/order"), HttpMethod.Post, ct, parameters, true).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel Margin Orders
        /// </summary>
        /// <remarks>Cancels all active margin orders, or all active margin orders for the specified symbol.</remarks>
        /// <param name="symbol">Optional parameter. Parameter to filter active margin orders by symbol.</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of cancelled margin orders.</returns>
        public WebCallResult<IEnumerable<HitBTCOrder>> CancelMarginOrders(string symbol = "", CancellationToken ct = default) => CancelMarginOrdersAsync(symbol, ct).Result;

        /// <summary>
        /// Cancel Margin Orders
        /// </summary>
        /// <remarks>Cancels all active margin orders, or all active margin orders for the specified symbol.</remarks>
        /// <param name="symbol">Optional parameter. Parameter to filter active margin orders by symbol.</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of cancelled margin orders.</returns>
        public async Task<WebCallResult<IEnumerable<HitBTCOrder>>> CancelMarginOrdersAsync(string symbol = "", CancellationToken ct = default)
        {
            string securityFilter = "";

            if (!String.IsNullOrEmpty(symbol))
            {
                securityFilter = "?symbol=" + symbol;
            }

            return await SendRequest<IEnumerable<HitBTCOrder>>(GetUrl("margin/order" + securityFilter), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancel Margin Order
        /// </summary>
        /// <param name="clientOrderId">Client order id</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns the successfully cancelled margin order.</returns>
        public WebCallResult<HitBTCOrder> CancelMarginOrder(string clientOrderId, CancellationToken ct = default) => CancelMarginOrderAsync(clientOrderId, ct).Result;

        /// <summary>
        /// Cancel Margin Order
        /// </summary>
        /// <remarks>Cancels all active margin orders, or all active margin orders for the specified symbol.</remarks>
        /// <param name="symbol">Optional parameter. Parameter to filter active margin orders by symbol.</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns a list of cancelled margin orders.</returns>
        public async Task<WebCallResult<HitBTCOrder>> CancelMarginOrderAsync(string clientOrderId, CancellationToken ct = default)
        {
            return await SendRequest<HitBTCOrder>(GetUrl("margin/order/" + clientOrderId), HttpMethod.Delete, ct, signed: true).ConfigureAwait(false);
        }

        /// <summary>
        /// Get url for an endpoint
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        protected Uri GetUrl(string endpoint)
        {
            return new Uri($"{BaseAddress}{endpoint}");
        }

        /// <inheritdoc />
        protected override Error ParseErrorResponse(JToken data)
        {
            if (data["error"] == null)
                return new UnknownError("Unknown response from server: " + data);

            var info = data["error"];
            var message = (string)info["message"];
           
            return new ServerError((int)data["status"], message);
        }

    }
}
