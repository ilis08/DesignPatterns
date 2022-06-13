using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public abstract class Menu
    {
        public readonly ICoupon _coupon;

        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }

        public abstract int CalculatePrice();
    }

    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    public class MeatBasedMenu : Menu
    {
        public MeatBasedMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }

    public interface ICoupon
    {
        public int CouponValue { get; }
    }

    public class NoCupon : ICoupon
    {
        public int CouponValue { get => 0;}
    }

    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue { get => 1; }
    }

    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue { get => 2; }
    }
}
