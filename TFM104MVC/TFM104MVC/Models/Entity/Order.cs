using Stateless;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TFM104MVC.Models
{
    public enum OrderStateEnum
    {
        Pending, //訂單已生成
        Processing, //支付處理中
        Completed, //交易成功
        Declined, //交易失敗
        Canceled, //訂單取消
        Refund //已退款
    }

    public enum OderStateTriggerEnum
    {
        PlaceOrder, //支付
        Approve, //支付成功
        Reject, //支付失敗
        Cancel, //取消
        Return //退貨
    }
    public class Order
    {
        public Order()
        {
            StateMachineInit(); //代表 每次創建訂單時 都會初始化訂單的狀態機
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<LineItem> OrderItems { get; set; }
        public OrderStateEnum State { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public string TransactionMetaData { get; set; } //第三方支付的數據

        StateMachine<OrderStateEnum, OderStateTriggerEnum> _machine;
        private void StateMachineInit()
        {
            _machine = new StateMachine<OrderStateEnum, OderStateTriggerEnum>(
                OrderStateEnum.Pending); //代表初始化狀態為Pending

            _machine.Configure(OrderStateEnum.Pending)
                .Permit(OderStateTriggerEnum.PlaceOrder, OrderStateEnum.Processing)
                .Permit(OderStateTriggerEnum.Cancel, OrderStateEnum.Canceled);

            _machine.Configure(OrderStateEnum.Processing)
                .Permit(OderStateTriggerEnum.Approve, OrderStateEnum.Completed)
                .Permit(OderStateTriggerEnum.Reject, OrderStateEnum.Declined);

            _machine.Configure(OrderStateEnum.Completed)
                .Permit(OderStateTriggerEnum.Return, OrderStateEnum.Refund);

            _machine.Configure(OrderStateEnum.Declined)
                .Permit(OderStateTriggerEnum.PlaceOrder, OrderStateEnum.Processing);
        }

    }
}