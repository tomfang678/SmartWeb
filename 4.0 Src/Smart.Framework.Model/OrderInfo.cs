using System;

namespace Smart.Framework.Model {

    /// <summary>
    /// Business entity used to model an order
    /// </summary>
    [Serializable]
    public class OrderInfo {

        // Internal member variables
        private int orderid;
        private DateTime date;
        private string userid;
        private CreditCardInfo creditCard;
        private AddressInfo billingAddress;
        private AddressInfo shippingAddress;
        private decimal orderTotal;
        private LineItemInfo[] lineItems;
        private Nullable<int> authorizationNumber;

        /// <summary>
        /// Default constructor
        /// This is required by web services serialization mechanism
        /// </summary>
        public OrderInfo() { }

        /// <summary>
        /// Constructor with specified initial values
        /// </summary>
        /// <param name="orderid">Unique identifier</param>
        /// <param name="date">Order date</param>
        /// <param name="userid">User placing order</param>
        /// <param name="creditCard">Credit card used for order</param>
        /// <param name="billing">Billing address for the order</param>
        /// <param name="shipping">Shipping address for the order</param>
        /// <param name="total">Order total value</param>
		/// <param name="line">Ordered items</param>
		/// <param name="authorization">Credit card authorization number</param>
		public OrderInfo(int orderid, DateTime date, string userid, CreditCardInfo creditCard, AddressInfo billing, AddressInfo shipping, decimal total, LineItemInfo[] line, Nullable<int> authorization) {
            this.orderid = orderid;
            this.date = date;
            this.userid = userid;
            this.creditCard = creditCard;
            this.billingAddress = billing;
            this.shippingAddress = shipping;
            this.orderTotal = total;
			this.lineItems = line;
			this.authorizationNumber = authorization;
        }

        // Properties
        public int Orderid {
            get { return orderid; }
            set { orderid = value; }
        }

        public DateTime Date {
            get { return date; }
            set { date = value; }
        }

        public string Userid {
            get { return userid; }
            set { userid = value; }
        }

        public CreditCardInfo CreditCard {
            get { return creditCard; }
            set { creditCard = value; }
        }

        public AddressInfo BillingAddress {
            get { return billingAddress; }
            set { billingAddress = value; }
        }

        public AddressInfo ShippingAddress {
            get { return shippingAddress; }
            set { shippingAddress = value; }
        }

        public decimal OrderTotal {
            get { return orderTotal; }
            set { orderTotal = value; }
        }

        public LineItemInfo[] LineItems {
            get { return lineItems; }
            set { lineItems = value; }
        }

        public Nullable<int> AuthorizationNumber {
			get {return authorizationNumber;}
			set {authorizationNumber = value;}
        }
    }
}