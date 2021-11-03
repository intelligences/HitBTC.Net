using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using HitBTC.Net;
using HitBTC.Net.Enum;
using HitBTC.Net.Objects;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

const string apiKey = "";
const string apiSecret = "";

var hitBtcClient = new HitBTCClient(new HitBTCClientOptions
                                    {
                                        ApiCredentials = new ApiCredentials(apiKey, apiSecret),
                                        LogWriters = new List<ILogger> {new DebugLogger()},
                                        LogLevel = LogLevel.Trace,
                                    });

var tradingBalance = await hitBtcClient.GetTradingBalanceAsync();
var balance = tradingBalance.Data.Where(x => x.Available != 0 || x.Reserved != 0).ToList();
                
var placeOrderResult = await hitBtcClient.CreateOrderAsync("ETHBTC", HitBTCSide.Sell, 0.01m, timeInForce: HitBTCTimeInForce.FOK);

var historyOrders = await hitBtcClient.GetHistoryOrdersAsync();
var historyTrades = await hitBtcClient.GetHistoryTradesAsync();
