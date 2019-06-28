using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColLab.Model;

namespace ColLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Responds to web API requests
    public class CartController : ControllerBase
    {
        private readonly CartContext _context;

        public CartController(CartContext context)
        { // DI to inject the database context
            _context = context;

            if (_context.CartItems.Count() == 0)
            {// Adds an item to the DB if the DB is empty
                _context.CartItems.Add(new CartItem { productID = 2125, productName = "Cheese", quantity = 5, shoppingCartID = 1 });
                _context.SaveChanges();
            }
        }

        // GET: api/Cart
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.CartItems.ToListAsync();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            return cartItem;
        }

        // POST: api/Cart
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem item)
        {//201(Created)
            _context.CartItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCartItem), new { id = item.id }, item);
        }

        // PUT: api/cart/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(int id, CartItem item)
        {//204(No Content)
            if (id != item.id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/cart/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {//204(No Content)
            try
            {
                var cartItem = await _context.CartItems.FindAsync(id);
                if (cartItem == null)
                {
                    return NotFound();
                }

                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();

            }
            catch (System.Exception ex)
            {
                string a = ex.Message;
            }
            
            return NoContent();
        }

        //Call the API with jQuery
        //    https://dba.stackexchange.com/questions/133626/which-way-is-better-to-design-shopping-cart-table-sql-server
    }
}