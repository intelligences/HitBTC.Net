using CryptoExchange.Net;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.Sockets;
using HitBTC.Net.Enum;
using HitBTC.Net.Interfaces;
using HitBTC.Net.Objects;
using HitBTC.Net.Requests;
using HitBTC.Net.Sockets;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HitBTC.Net
{
    public class HitBTCSocketClient : SocketClient, IHitBTCSocketClient
    {
        public event Action OnOpened;
        public event Action OnClosed;
        public event Action OnConnectionLost;
        public event Action<TimeSpan> OnConnectionRestored;

        private static HitBTCSocketClientOptions defaultOptions = new HitBTCSocketClientOptions();
        private static HitBTCSocketClientOptions DefaultOptions => defaultOptions.Copy<HitBTCSocketClientOptions>();

        #region ctor
        /// <summary>
        /// Creates a new socket client using the default options
        /// </summary>
        public HitBTCSocketClient() : this(DefaultOptions)
        {
        }

        /// <summary>
        /// Creates a new socket client using the provided options
        /// </summary>
        /// <param name="options">Options to use for this client</param>
        public HitBTCSocketClient(HitBTCSocketClientOptions options) : base(options, options.ApiCredentials == null ? null : new HitBTCAuthenticationProvider(options.ApiCredentials))
        {
            SocketCombineTarget = 10;
        }
        #endregion

        /// <summary>
        /// Gets the currencies
        /// </summary>
        /// <returns>Symbol summaries</returns>
        public CallResult<IEnumerable<HitBTCCurrency>> GetCurrencies() => GetCurrenciesAsync().Result;

        /// <summary>
        /// Gets the currencies async
        /// </summary>
        /// <returns>Symbol summaries</returns>
        public async Task<CallResult<IEnumerable<HitBTCCurrency>>> GetCurrenciesAsync()
        {
            var req = new GetCurrenciesRequest(NextId());
            var result = await Query<HitBTCSocketResponse<IEnumerable<HitBTCCurrency>>>(req, false).ConfigureAwait(false);

            return new CallResult<IEnumerable<HitBTCCurrency>>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Get the currency
        /// </summary>
        /// <returns>Symbol</returns>
        public CallResult<HitBTCCurrency> GetCurrency(string id) => GetCurrencyAsync(id).Result;

        /// <summary>
        /// Get the currency async
        /// </summary>
        /// <returns>Symbol</returns>
        public async Task<CallResult<HitBTCCurrency>> GetCurrencyAsync(string id)
        {
            var req = new GetCurrencyRequest(NextId(), id);
            var result = await Query<HitBTCSocketResponse<HitBTCCurrency>>(req, false).ConfigureAwait(false);

            return new CallResult<HitBTCCurrency>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Gets the symbols
        /// </summary>
        /// <returns>Symbol summaries</returns>
        public CallResult<IEnumerable<HitBTCSymbol>> GetSymbols() => GetSymbolsAsync().Result;

        /// <summary>
        /// Gets the symbols async
        /// </summary>
        /// <returns>Symbol summaries</returns>
        public async Task<CallResult<IEnumerable<HitBTCSymbol>>> GetSymbolsAsync()
        {
            var req = new GetSymbolsRequest(NextId());
            var result = await Query<HitBTCSocketResponse<IEnumerable<HitBTCSymbol>>>(req, false).ConfigureAwait(false);

            return new CallResult<IEnumerable<HitBTCSymbol>>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Get the symbol
        /// </summary>
        /// <returns>Symbol</returns>
        public CallResult<HitBTCSymbol> GetSymbol(string id) => GetSymbolAsync(id).Result;

        /// <summary>
        /// Get the symbol
        /// </summary>
        /// <returns>Symbol</returns>
        public async Task<CallResult<HitBTCSymbol>> GetSymbolAsync(string id)
        {
            var req = new GetSymbolRequest(NextId(), id);
            var result = await Query<HitBTCSocketResponse<HitBTCSymbol>>(req, false).ConfigureAwait(false);

            return new CallResult<HitBTCSymbol>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Place new order
        /// </summary>
        /// <returns>Order</returns>
        public CallResult<HitBTCOrder> PlaceOrder(
            string clientOrderId,
            string symbol,
            HitBTCSide side,
            HitBTCOrderType type,
            decimal price,
            decimal quantity,
            decimal stopPrice,
            HitBTCTimeInForce timeInForce = HitBTCTimeInForce.GTC
        ) => PlaceOrderAsync(
            clientOrderId,
            symbol,
            side,
            type,
            price,
            quantity,
            stopPrice,
            timeInForce
        ).Result;

        /// <summary>
        /// Place new order async
        /// </summary>
        /// <returns>Order</returns>
        public async Task<CallResult<HitBTCOrder>> PlaceOrderAsync(
            string clientOrderId, 
            string symbol, 
            HitBTCSide side, 
            HitBTCOrderType type, 
            decimal price, 
            decimal quantity, 
            decimal stopPrice, 
            HitBTCTimeInForce timeInForce = HitBTCTimeInForce.GTC
        ) {
            var request = new PlaceOrderRequest(
                NextId(),
                clientOrderId,
                symbol,
                side,
                type,
                price,
                quantity,
                stopPrice
            );

            var result = await Query<HitBTCSocketResponse<HitBTCOrder>>(request, true).ConfigureAwait(false);

            return new CallResult<HitBTCOrder>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Replace order
        /// </summary>
        /// <returns>Symbol</returns>
        public CallResult<HitBTCOrder> RePlaceOrder(
            string clientOrderId, 
            string requestClientOrderId, 
            decimal price, 
            decimal quantity
            ) => RePlaceOrderAsync(
                clientOrderId,
                requestClientOrderId,
                price,
                quantity
            ).Result;

        /// <summary>
        /// Replace order async
        /// </summary>
        /// <returns>order</returns>
        public async Task<CallResult<HitBTCOrder>> RePlaceOrderAsync(string clientOrderId, string requestClientOrderId, decimal price, decimal quantity)
        {
            var request = new RePlaceOrderRequest(
               NextId(),
               clientOrderId,
               requestClientOrderId,
               price,
               quantity
            );

            var result = await Query<HitBTCSocketResponse<HitBTCOrder>>(request, true).ConfigureAwait(false);

            return new CallResult<HitBTCOrder>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <returns>Order</returns>
        public CallResult<HitBTCOrder> CancelOrder(string clientOrderId) => CancelOrderAsync(clientOrderId).Result;

        /// <summary>
        /// Cancel order
        /// </summary>
        /// <returns>Order</returns>
        public async Task<CallResult<HitBTCOrder>> CancelOrderAsync(string clientOrderId)
        {
            var request = new CancelOrderRequest(NextId(), clientOrderId);
            var result = await Query<HitBTCSocketResponse<HitBTCOrder>>(request, true).ConfigureAwait(false);

            return new CallResult<HitBTCOrder>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Gets the active orders
        /// </summary>
        /// <returns>Active orders</returns>
        public CallResult<IEnumerable<HitBTCOrder>> GetActiveOrders() => GetActiveOrdersAsync().Result;

        /// <summary>
        /// Gets the active orders async
        /// </summary>
        /// <returns>Active orders</returns>
        public async Task<CallResult<IEnumerable<HitBTCOrder>>> GetActiveOrdersAsync()
        {
            var request = new GetActiveOrders(NextId());
            var result = await Query<HitBTCSocketResponse<IEnumerable<HitBTCOrder>>>(request, true).ConfigureAwait(false);

            return new CallResult<IEnumerable<HitBTCOrder>>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Gets the active orders
        /// </summary>
        /// <returns>Active orders</returns>
        public CallResult<IEnumerable<HitBTCBalance>> GetTradingBalances() => GetTradingBalancesAsync().Result;

        /// <summary>
        /// Gets the active orders async
        /// </summary>
        /// <returns>Active orders</returns>
        public async Task<CallResult<IEnumerable<HitBTCBalance>>> GetTradingBalancesAsync()
        {
            var request = new GetTradingBalanceRequest(NextId());
            var result = await Query<HitBTCSocketResponse<IEnumerable<HitBTCBalance>>>(request, true).ConfigureAwait(false);

            return new CallResult<IEnumerable<HitBTCBalance>>(result.Data?.Result, result.Error);
        }

        /// <summary>
        /// Subscribe to orders
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Subscription</returns>
        public CallResult<UpdateSubscription> SubscribeOrders(Action<HitBTCOrder> action) => SubscribeOrdersAsync(action).Result;

        /// <summary>
        /// Subscribe to orders async
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Subscription</returns>
        public async Task<CallResult<UpdateSubscription>> SubscribeOrdersAsync(Action<HitBTCOrder> action)
        {
            var request = new SubscribeOrdersRequest(NextId());

            var internalHandler = new Action<HitBTCSocketSubscriptionResponse<JToken>>(response =>
            {
                var error = response.Error;
                var method = response.Method;
                JToken data = response.Data;

                switch(method)
                {
                    case "activeOrders":
                        var orders = data.ToObject<IEnumerable<HitBTCOrder>>();

                        foreach (var order in orders)
                        {
                            action(order);
                        }
                        break;
                    case "report":
                        var report = data.ToObject<HitBTCReport>();

                        action(report);
                        break;
                }

                Debug.WriteLine(response);

            });

            return await Subscribe<HitBTCSocketSubscriptionResponse<JToken>>(request, null, true, internalHandler).ConfigureAwait(false);
        }

        /// <summary>
        /// Subscribe to order book
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public CallResult<UpdateSubscription> SubscribeOrderBook(string symbol, Action<HitBTCOrderBook> action) => SubscribeOrderBookAsync(symbol, action).Result;

        /// <summary>
        /// Subscribe to order book async
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="action"></param>
        /// <returns>Subscription</returns>
        public async Task<CallResult<UpdateSubscription>> SubscribeOrderBookAsync(string symbol, Action<HitBTCOrderBook> action)
        {
            var request = new SubscribeOrderBookRequest(NextId(), symbol);

            var internalHandler = new Action<HitBTCSocketSubscriptionResponse<HitBTCOrderBook>>(response =>
            {
                action(response.Data);
            });

            return await Subscribe<HitBTCSocketSubscriptionResponse<HitBTCOrderBook>>(request, null, false, internalHandler).ConfigureAwait(false);
        }

        /// <summary>
        /// Subscribe to candles
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public CallResult<UpdateSubscription> SubscribeCandles(string symbol, HitBTCPeriod period, int limit, Action<HitBTCCandleData> action) => SubscribeCandlesAsync(symbol, period, limit, action).Result;

        /// <summary>
        /// Subscribe to candles async
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="action"></param>
        /// <returns>Subscription</returns>
        public async Task<CallResult<UpdateSubscription>> SubscribeCandlesAsync(string symbol, HitBTCPeriod period, int limit, Action<HitBTCCandleData> action)
        {
            var request = new SubscribeCandlesRequest(NextId(), symbol, period, limit);

            var internalHandler = new Action<HitBTCSocketSubscriptionResponse<HitBTCCandleData>>(response =>
            {
                action(response.Data);
            });

            return await Subscribe<HitBTCSocketSubscriptionResponse<HitBTCCandleData>>(request, null, true, internalHandler).ConfigureAwait(false);
        }

        /// <summary>
        /// Subscribe to trades
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public CallResult<UpdateSubscription> SubscribeTrades(string symbol, int limit, Action<HitBTCTradesData> action) => SubscribeTradesAsync(symbol, limit, action).Result;

        /// <summary>
        /// Subscribe to trades async
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="action"></param>
        /// <returns>Subscription</returns>
        public async Task<CallResult<UpdateSubscription>> SubscribeTradesAsync(string symbol, int limit, Action<HitBTCTradesData> action)
        {
            var request = new SubscribeTradesRequest(NextId(), symbol, limit);

            var internalHandler = new Action<HitBTCSocketSubscriptionResponse<HitBTCTradesData>>(response =>
            {
                action(response.Data);
            });

            return await Subscribe<HitBTCSocketSubscriptionResponse<HitBTCTradesData>>(request, null, true, internalHandler).ConfigureAwait(false);
        }

        /// <summary>
        /// Set the default options for new clients
        /// </summary>
        /// <param name="options">Options to use for new clients</param>
        public static void SetDefaultOptions(HitBTCSocketClientOptions options)
        {
            defaultOptions = options;
        }


        protected override bool HandleQueryResponse<T>(SocketConnection s, object request, JToken data, out CallResult<T> callResult)
        {
            callResult = new CallResult<T>(data.ToObject<T>(), null);

            return callResult;
        }

        protected override bool HandleSubscriptionResponse(SocketConnection s, SocketSubscription subscription, object request, JToken message, out CallResult<object> callResult)
        {
            callResult = null;

            var idField = message["id"];
            var typed = request as HitBTCSocketRequest;

            if (idField == null || idField.Type == JTokenType.Null)
                return false;

            if (typed.Id != (int)idField)
                return false;

            var subResponse = Deserialize<HitBTCSocketResponse<bool>>(message, false);

            if (!subResponse)
            {
                log.Write(LogVerbosity.Warning, "Subscription failed: " + subResponse.Error);
                callResult = new CallResult<object>(null, subResponse.Error);
                return true;
            }

            if (subResponse.Data.Error != null)
            {
                log.Write(LogVerbosity.Debug, $"Failed to subscribe: {subResponse.Data.Error.Code} {subResponse.Data.Error.Message}");
                callResult = new CallResult<object>(null, new ServerError(subResponse.Data.Error.Code, subResponse.Data.Error.Message));
                return true;
            }

            log.Write(LogVerbosity.Debug, "Subscription completed");
            callResult = new CallResult<object>(subResponse, null);

            return true;
        }

        protected override bool MessageMatchesHandler(JToken message, object request)
        {
            string method = (string)message["method"];

            if (method != null)
            {
                if (request is SubscribeOrdersRequest)
                {
                    if (method == "activeOrders")
                    {
                        return true;
                    }
                    else if (method == "report")
                    {
                        return true;
                    }
                }
                if (request is SubscribeOrderBookRequest)
                {
                    string symbol = (string)message["params"]["symbol"];

                    return (request as SubscribeOrderBookRequest).GetSymbol() == symbol;
                }
                if (request is SubscribeCandlesRequest)
                {
                    string symbol = (string)message["params"]["symbol"];
                    string period = (string)message["params"]["period"];

                    var typed = (request as SubscribeCandlesRequest);

                    return typed.GetSymbol() == symbol && typed.GetPeriod() == period;
                }
                if (request is SubscribeTradesRequest)
                {
                    string symbol = (string)message["params"]["symbol"];

                    return (request as SubscribeTradesRequest).GetSymbol() == symbol;
                }
            }

            return false;
        }

        protected override bool MessageMatchesHandler(JToken message, string identifier)
        {
            throw new System.NotImplementedException();
        }

        protected override Task<bool> Unsubscribe(SocketConnection connection, SocketSubscription s)
        {
            throw new System.NotImplementedException();
        }


        protected override async Task<CallResult<bool>> AuthenticateSocket(SocketConnection s)
        {
            if (authProvider == null)
                return new CallResult<bool>(false, new NoApiCredentialsError());

            var request = new LoginRequest(NextId(), this.authProvider.Credentials.Key.GetString(), this.authProvider.Credentials.Secret.GetString());
            var result = new CallResult<bool>(false, new ServerError("No response from server"));

            await s.SendAndWait(request, ResponseTimeout, data =>
            {
                var authResponse = Deserialize<HitBTCSocketResponse<bool>>(data, false);
                if (!authResponse)
                {
                    log.Write(LogVerbosity.Warning, "Authorization failed: " + authResponse.Error);
                    result = new CallResult<bool>(false, authResponse.Error);
                    return true;
                }

                if (authResponse.Data.Error != null)
                {
                    var error = new ServerError(authResponse.Data.Error.Code, authResponse.Data.Error.Message);
                    log.Write(LogVerbosity.Debug, "Failed to authenticate: " + error);
                    result = new CallResult<bool>(false, error);
                    return true;
                }

                if (authResponse.Data.Result != true)
                {
                    log.Write(LogVerbosity.Debug, "Failed to authenticate: " + authResponse.Data.Result);
                    result = new CallResult<bool>(false, new ServerError(authResponse.Data.Result.ToString()));

                    return true;
                }

                log.Write(LogVerbosity.Debug, "Authorization completed");

                result = new CallResult<bool>(true, null);

                return true;
            });

            return result;
        }


        protected override SocketConnection GetWebsocket(string address, bool authenticated)
        {
            var socketResult = sockets.Where(s => s.Value.Socket.Url == address && (s.Value.Authenticated == authenticated || !authenticated) && s.Value.Connected).OrderBy(s => s.Value.HandlerCount).FirstOrDefault();
            var result = socketResult.Equals(default(KeyValuePair<int, SocketConnection>)) ? null : socketResult.Value;

            if (result != null)
            {
                if (result.HandlerCount < SocketCombineTarget || (sockets.Count >= MaxSocketConnections && sockets.All(s => s.Value.HandlerCount >= SocketCombineTarget)))
                {
                    // Use existing socket if it has less than target connections OR it has the least connections and we can't make new
                    return result;
                }
            }

            var socket = CreateSocket(address);
            var socketWrapper = new SocketConnection(this, socket);
            foreach (var kvp in genericHandlers)
            {
                var handler = SocketSubscription.CreateForIdentifier(kvp.Key, false, kvp.Value);
                socketWrapper.AddHandler(handler);
            }

            socket.OnOpen += () =>
            {
                this.OnOpened?.Invoke();
            };

            socket.OnClose += () =>
            {
                this.OnClosed?.Invoke();
            };

            socketWrapper.ConnectionLost += () => {
                this.OnConnectionLost?.Invoke();
            };

            socketWrapper.ConnectionRestored += (TimeSpan ts) => {
                this.OnConnectionRestored?.Invoke(ts);
            };

            return socketWrapper;
        }
    }
}
