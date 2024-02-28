using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsemkaStoreAPI.Models;
using System.Collections.Immutable;
using EsemkaStoreAPI.DTOs;

namespace EsemkaStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly EsemkaStoreContext _context;

        public TransactionController(EsemkaStoreContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<Transaction> query = _context.Transactions;

            if (minDate != null)
            {
                query = query.Where(tx => tx.TransactionDate > minDate);
            }

            if (maxDate != null)
            {
                query = query.Where(tx => tx.TransactionDate < maxDate);
            }

            return query.ToList();
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransaction(int id)
        {
            var transaction = _context.Transactions.Select(tx => new
            {
                ID = tx.Id,
                tx.CustomerName,
                Date = tx.TransactionDate,
                Orders = tx.Orders.Select(ord => new {
                    ProductName = ord.Product.Name,
                    ord.Qty
                })
            }).FirstOrDefault(tx => tx.ID == id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // POST: api/Transaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTransaction(TransactionDTO transaction)
        {

            try
            {
                var dataTransaction = _context.Transactions.Update(new Transaction
                {
                    CustomerName = transaction.CustomerName,
                    TransactionDate = transaction.TransactionDate
                }).Entity;

                _context.Orders.UpdateRange(transaction.Orders.Select(ord => new Order
                {
                    ProductId = ord.ProductID,
                    Qty = ord.Qty,
                    Transaction = dataTransaction
                }));
                _context.SaveChanges();

                return RedirectPermanent($"/api/Transaction/{dataTransaction.Id}");
                // sama dengan
                //return await GetTransaction(dataTransaction.Id);
            } catch
            {
                return BadRequest("Transaksi gagal diproses");
            }


        }
    }
}
