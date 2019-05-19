using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetMePlease.DatabaseConnection;
using BudgetMePlease.Models;
using SQLite;
using Xamarin.Forms;

namespace BudgetMePlease.Dao
{
    public class EnvelopeDaoImp : IEnvelopeDao
    {
        private SQLiteAsyncConnection _connection;
        public EnvelopeDaoImp()
        {
            _connection = DependencyService.Get<IDatabaseConnection>().GetConnection();
            _connection.CreateTableAsync<Envelope>();
        }
        public async Task DeleteEnvelopeAsync(Envelope envelope)
        {
            await _connection.DeleteAsync(envelope);
        }

        public async Task<IEnumerable<Envelope>> GetAllEnvelopes()
        {

            return await _connection.Table<Envelope>().ToListAsync();
        }

        public async Task<Envelope> GetEnvelope(int Id)
        {
            return await _connection.FindAsync<Envelope>(Id);
        }

        public async Task InsertEnvelopeAsync(Envelope envelope)
        {
            await _connection.InsertAsync(envelope);
        }

        public async Task UpdateEnvelopeAsync(Envelope envelope)
        {
            await _connection.UpdateAsync(envelope);
        }
    }
}
