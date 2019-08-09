using System;
using Xunit;
using Cart;

namespace Cart.Tests
{
    public class UnitTest1
    {
        Product butter = new Product("butter", 50, Category.Dairy);
        Product jeans = new Product("jeans", 1000, Category.Cloth);
        Product toy = new Product("toy", 500, Category.Entertainment);
        CategoryDiscount categoryDiscount = new CategoryDiscount();
        CartItem cartItem = new CartItem();
        IDiscount fixedCartDiscount = new FixedCartDiscount();

        [Fact]
        public void Testing_Product()
        {
            Assert.Equal("butter", butter.Name);
            Assert.Equal(50, butter.Price);
            Assert.Equal(Category.Dairy, butter.Category);
        }
        [Fact]
        public void Testing_CartItem()
        {
            cartItem.AddItem(toy, 28);
            cartItem.AddItem(jeans, 10);
            Assert.Equal(28,cartItem.GetItems()[toy]);
        }
        [Fact]
        public void Testing_Category_Discount()
        {
            categoryDiscount.AddCategoryDiscount(Category.Entertainment, 20);
            cartItem.AddItem(toy, 2);
            Cart cart = new Cart(cartItem, categoryDiscount);
            Assert.Equal(800, cart.GetTotal());
        }
        [Fact]
        public void Testing_Category_Discount_Again()
        {
            categoryDiscount.AddCategoryDiscount(Category.Entertainment, 20);
            categoryDiscount.AddCategoryDiscount(Category.Cloth, 50);
            categoryDiscount.AddCategoryDiscount(Category.Dairy, 10);
            cartItem.AddItem(toy, 2);
            cartItem.AddItem(jeans, 1);
            cartItem.AddItem(butter, 20);
            Cart cart = new Cart(cartItem, categoryDiscount);
            Assert.Equal(2200, cart.GetTotal());
        }
        [Fact]
        public void Testing_Fixed_Cart_Discount()
        {
            cartItem.AddItem(toy, 2);
            cartItem.AddItem(jeans, 1);
            cartItem.AddItem(butter, 20);
            Cart cart = new Cart(cartItem, fixedCartDiscount);
            Assert.Equal(2700, cart.GetTotal());
        }
        [Fact]
        public void Testing_Configurable_Cart_Discount()
        {
            cartItem.AddItem(toy, 10);
            cartItem.AddItem(jeans, 2);
            cartItem.AddItem(butter, 20);
            IDiscount configurableDiscount = new ConfigurableCartDiscount(50);
            Cart cart = new Cart(cartItem, configurableDiscount);
            Assert.Equal(4000, cart.GetTotal());
        }

    }
}
