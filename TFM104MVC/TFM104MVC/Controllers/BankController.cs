using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TFM104MVC.Models;
using TFM104MVC.Models.Bank.Util;

namespace TFM104MVC.Controllers
{
    public class BankController : Controller
    {
        /// <summary>
        /// 金流基本資料(可再移到Web.config或資料庫設定)
        /// </summary>
        private BankInfoModel _bankInfoModel = new BankInfoModel
        {
            MerchantID = "MS134167575",
            HashKey = "8LImeXm6c1hyF94X7K4iexXxs0bY8ilj",
            HashIV = "CzZWZTbaRiI33oRP",
            ReturnURL = "http://yourWebsitUrl/Bank/SpgatewayReturn",
            NotifyURL = "http://yourWebsitUrl/Bank/SpgatewayNotify",
            CustomerURL = "http://yourWebsitUrl/Bank/SpgatewayCustomer",
            AuthUrl = "https://ccore.spgateway.com/MPG/mpg_gateway",
            CloseUrl = "https://core.newebpay.com/API/CreditCard/Close"
        };

        /// <summary>
        /// 付款頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult PayBill()
        {
            return View();
        }

        /// <summary>
        /// [智付通支付]金流介接
        /// </summary>
        /// <param name="ordernumber">訂單單號</param>
        /// <param name="amount">訂單金額</param>
        /// <param name="payType">請款類型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SpgatewayPayBill(string ordernumber, int amount, string payType)
        {
            string version = "1.5";

            // 目前時間轉換 +08:00, 防止傳入時間或Server時間時區不同造成錯誤
            DateTimeOffset taipeiStandardTimeOffset = DateTimeOffset.Now.ToOffset(new TimeSpan(8, 0, 0));

            TradeInfo tradeInfo = new TradeInfo()
            {
                // * 商店代號
                MerchantID = _bankInfoModel.MerchantID,
                // * 回傳格式
                RespondType = "String",
                // * TimeStamp
                TimeStamp = taipeiStandardTimeOffset.ToUnixTimeSeconds().ToString(),
                // * 串接程式版本
                Version = version,
                // * 商店訂單編號
                //MerchantOrderNo = $"T{DateTime.Now.ToString("yyyyMMddHHmm")}",
                MerchantOrderNo = ordernumber,
                // * 訂單金額
                Amt = amount,
                // * 商品資訊
                ItemDesc = "商品資訊(自行修改)",
                // 繳費有效期限(適用於非即時交易)
                ExpireDate = null,
                // 支付完成 返回商店網址
                ReturnURL = _bankInfoModel.ReturnURL,
                // 支付通知網址
                NotifyURL = _bankInfoModel.NotifyURL,
                // 商店取號網址
                CustomerURL = _bankInfoModel.CustomerURL,
                // 支付取消 返回商店網址
                ClientBackURL = null,
                // * 付款人電子信箱
                Email = string.Empty,
                // 付款人電子信箱 是否開放修改(1=可修改 0=不可修改)
                EmailModify = 0,
                // 商店備註
                OrderComment = null,
                // 信用卡 一次付清啟用(1=啟用、0或者未有此參數=不啟用)
                CREDIT = null,
                // WEBATM啟用(1=啟用、0或者未有此參數，即代表不開啟)
                WEBATM = null,
                // ATM 轉帳啟用(1=啟用、0或者未有此參數，即代表不開啟)
                VACC = null,
                // 超商代碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 30 元或超過 2 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
                CVS = null,
                // 超商條碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 20 元或超過 4 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
                BARCODE = null
            };

            if (string.Equals(payType, "CREDIT"))
            {
                tradeInfo.CREDIT = 1;
            }
            else if (string.Equals(payType, "WEBATM"))
            {
                tradeInfo.WEBATM = 1;
            }
            else if (string.Equals(payType, "VACC"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.VACC = 1;
            }
            else if (string.Equals(payType, "CVS"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.CVS = 1;
            }
            else if (string.Equals(payType, "BARCODE"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.BARCODE = 1;
            }

            Atom<string> result = new Atom<string>()
            {
                IsSuccess = true
            };

            var inputModel = new SpgatewayInputModel
            {
                MerchantID = _bankInfoModel.MerchantID,
                Version = version
            };

            // 將model 轉換為List<KeyValuePair<string, string>>, null值不轉
            List<KeyValuePair<string, string>> tradeData = LambdaUtil.ModelToKeyValuePairList<TradeInfo>(tradeInfo);
            // 將List<KeyValuePair<string, string>> 轉換為 key1=Value1&key2=Value2&key3=Value3...
            var tradeQueryPara = string.Join("&", tradeData.Select(x => $"{x.Key}={x.Value}"));
            // AES 加密
            inputModel.TradeInfo = CryptoUtil.EncryptAESHex(tradeQueryPara, _bankInfoModel.HashKey, _bankInfoModel.HashIV);
            // SHA256 加密
            inputModel.TradeSha = CryptoUtil.EncryptSHA256($"HashKey={_bankInfoModel.HashKey}&{inputModel.TradeInfo}&HashIV={_bankInfoModel.HashIV}");

            // 將model 轉換為List<KeyValuePair<string, string>>, null值不轉
            List<KeyValuePair<string, string>> postData = LambdaUtil.ModelToKeyValuePairList<SpgatewayInputModel>(inputModel);

            Response.Clear();

            StringBuilder s = new StringBuilder();
            s.Append("<html>");
            s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
            s.AppendFormat("<form name='form' action='{0}' method='post'>", _bankInfoModel.AuthUrl);
            foreach (KeyValuePair<string, string> item in postData)
            {
                s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", item.Key, item.Value);
            }

            s.Append("</form></body></html>");
            Response.WriteAsync(s.ToString());
            Response.End();

            return Content(string.Empty);

        }

        /// <summary>
        /// [智付通]金流介接(結果: 支付完成 返回商店網址)
        /// </summary>
        [HttpPost]
        public ActionResult SpgatewayReturn()
        {
            Request.LogFormData("SpgatewayReturn(支付完成)");

            // Status 回傳狀態 
            // MerchantID 回傳訊息
            // TradeInfo 交易資料AES 加密
            // TradeSha 交易資料SHA256 加密
            // Version 串接程式版本
            NameValueCollection collection = Request.Form;

            if (collection["MerchantID"] != null && string.Equals(collection["MerchantID"], _bankInfoModel.MerchantID) &&
                collection["TradeInfo"] != null && string.Equals(collection["TradeSha"], CryptoUtil.EncryptSHA256($"HashKey={_bankInfoModel.HashKey}&{collection["TradeInfo"]}&HashIV={_bankInfoModel.HashIV}")))
            {
                var decryptTradeInfo = CryptoUtil.DecryptAESHex(collection["TradeInfo"], _bankInfoModel.HashKey, _bankInfoModel.HashIV);

                // 取得回傳參數(ex:key1=value1&key2=value2),儲存為NameValueCollection
                NameValueCollection decryptTradeCollection = HttpUtility.ParseQueryString(decryptTradeInfo);
                SpgatewayOutputDataModel convertModel = LambdaUtil.DictionaryToObject<SpgatewayOutputDataModel>(decryptTradeCollection.AllKeys.ToDictionary(k => k, k => decryptTradeCollection[k]));

                LogUtil.WriteLog(JsonConvert.SerializeObject(convertModel));

                // TODO 將回傳訊息寫入資料庫

                return Content(JsonConvert.SerializeObject(convertModel));
            }
            else
            {
                LogUtil.WriteLog("MerchantID/TradeSha驗證錯誤");
            }

            return Content(string.Empty);
        }

        /// <summary>
        /// [智付通]金流介接(結果: 支付通知網址)
        /// </summary>
        [HttpPost]
        public ActionResult SpgatewayNotify()
        {
            // 取法同SpgatewayResult

            Request.LogFormData("SpgatewayNotify(支付通知)");
            return Content(string.Empty);
        }

        /// <summary>
        /// [智付通]金流介接(結果: 資料回傳)
        /// </summary>
        [HttpPost]
        public ActionResult SpgatewayCustomer()
        {
            Request.LogFormData("SpgatewayCustomer(資料回傳)");

            // Status 回傳狀態 
            // MerchantID 回傳訊息
            // TradeInfo 交易資料AES 加密
            // TradeSha 交易資料SHA256 加密
            // Version 串接程式版本
            NameValueCollection collection = Request.Form;

            if (collection["MerchantID"] != null && string.Equals(collection["MerchantID"], _bankInfoModel.MerchantID))
            {
                var decryptTradeInfo = CryptoUtil.DecryptAESHex(collection["TradeInfo"], _bankInfoModel.HashKey, _bankInfoModel.HashIV);

                // 取得回傳參數(ex:key1=value1&key2=value2),儲存為NameValueCollection
                NameValueCollection decryptTradeCollection = HttpUtility.ParseQueryString(decryptTradeInfo);
                SpgatewayTakeNumberDataModel convertModel = LambdaUtil.DictionaryToObject<SpgatewayTakeNumberDataModel>(decryptTradeCollection.AllKeys.ToDictionary(k => k, k => decryptTradeCollection[k]));

                LogUtil.WriteLog(JsonConvert.SerializeObject(convertModel));

                // TODO 將回傳訊息寫入資料庫

                return Content(JsonConvert.SerializeObject(convertModel));
            }
            else
            {
                LogUtil.WriteLog("MerchantID錯誤");
            }

            return Content(string.Empty);
        }

        /// <summary>
        /// 執行HttpClient Post
        /// </summary>
        /// <param name="url">Post網址</param>
        /// <param name="formContent">form參數</param>
        /// <returns></returns>
        private async Task<string> ExePostForm(string url, FormUrlEncodedContent formContent)
        {
            string responseBody = string.Empty;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Clear();

                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsync(url, formContent);

                    if (response.IsSuccessStatusCode)
                    {
                        responseBody = await response.Content.ReadAsStringAsync();
                        // 紀錄回傳資訊
                        LogUtil.WriteLog(responseBody);
                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.WriteLog(ex);
            }

            return responseBody;
        } // ExePostForm()

        /// <summary>
        /// 銀行API測試
        /// </summary>
        /// <returns></returns>
        public ActionResult RefundTest()
        {
            return View();
        }

        /// <summary>
        /// 處理智付通 Deposit Reversal、Refund、Refund Reversal交易
        /// </summary>
        /// <param name="model">傳入資料</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> SpgatewayClose(SpgatewayCloseViewModel model)
        {
            LogUtil.WriteLog("SpgatewayClose");
            LogUtil.WriteLog(JsonConvert.SerializeObject(model));

            Atom result = new Atom()
            {
                IsSuccess = true
            };

            try
            {
                // 驗證資料
                if (model == null)
                {
                    result.IsSuccess = false;
                    result.Message = "Model is null";
                }
                else if (string.IsNullOrWhiteSpace(model.MerchantOrderNo) || string.IsNullOrWhiteSpace(model.Amt))
                {
                    result.IsSuccess = false;
                    result.Message = "[商店訂單編號]、[請退款金額]為必填";
                }

                if (result.IsSuccess)
                {

                    // 目前時間轉換 +08:00, 防止傳入時間或Server時間時區不同造成錯誤
                    DateTimeOffset taipeiStandardTimeOffset = DateTimeOffset.Now.ToOffset(new TimeSpan(8, 0, 0));

                    string postUrl = _bankInfoModel.CloseUrl;

                    var postData = new SpgatewayClosePostDataModel()
                    {
                        RespondType = "String",
                        Version = "1.0",
                        Amt = int.Parse(model.Amt),
                        MerchantOrderNo = model.MerchantOrderNo,
                        TimeStamp = taipeiStandardTimeOffset.ToUnixTimeSeconds().ToString(),
                        IndexType = 1,
                        TradeNo = string.Empty,
                        CloseType = 1,
                        Cancel = null
                    };

                    if (string.Equals(model.ExeType, "DepositReversal"))
                    {
                        postData.CloseType = 1;
                        postData.Cancel = 1;
                    }
                    else if (string.Equals(model.ExeType, "Refund"))
                    {
                        postData.CloseType = 2;
                        postData.Cancel = null;
                    }
                    else if (string.Equals(model.ExeType, "RefundReversal"))
                    {
                        postData.CloseType = 2;
                        postData.Cancel = 1;
                    }

                    // 將model 轉換為List<KeyValuePair<string, string>>, null值不轉
                    List<KeyValuePair<string, string>> postDataList = LambdaUtil.ModelToKeyValuePairList<SpgatewayClosePostDataModel>(postData);
                    // 將List<KeyValuePair<string, string>> 轉換為 key1=Value1&key2=Value2&key3=Value3...
                    var postDataPara = string.Join("&", postDataList.Select(x => $"{x.Key}={x.Value}"));
                    var encryptData = CryptoUtil.EncryptAESHex(postDataPara, _bankInfoModel.HashKey, _bankInfoModel.HashIV);

                    var postkeyValues = new List<KeyValuePair<string, string>>();
                    postkeyValues.Add(new KeyValuePair<string, string>("MerchantID_", _bankInfoModel.MerchantID));
                    postkeyValues.Add(new KeyValuePair<string, string>("PostData_", encryptData));

                    FormUrlEncodedContent formContent = new FormUrlEncodedContent(postkeyValues);

                    string responseBody = await ExePostForm(postUrl, formContent);

                    if (!string.IsNullOrWhiteSpace(responseBody))
                    {
                        // 取得回傳參數(ex:Status=TRA10027&Message=此訂單已申請過請款，不可重覆請款&MerchantID=11250&Amt=10&MerchantOrderNo=20140519193443),儲存為NameValueCollection
                        NameValueCollection collection = HttpUtility.ParseQueryString(responseBody);

                        // TODO DB紀錄處理狀況與訂單更新處理


                        if (collection["Status"] != null && string.Equals(collection["Status"], "SUCCESS"))
                        {
                            result.IsSuccess = true;
                            result.Message = responseBody;
                        }
                        else
                        {
                            result.IsSuccess = false;
                            result.Message = responseBody;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogUtil.WriteLog(ex);
            }

            return Content(JsonConvert.SerializeObject(result));
        }
    }
}
