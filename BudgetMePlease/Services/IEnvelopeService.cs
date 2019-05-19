using BudgetMePlease.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMePlease.Services
{
    public interface IEnvelopeService
    {
        Task InsertEnvelopeAsync(Envelope envelope);
        Task UpdateEnvelopeAsync(Envelope envelope);
        Task DeleteEnvelopeAsync(Envelope envelope);
        Task<IEnumerable<Envelope>> GetAllEnvelopes();
        Task<Envelope> GetEnvelope(int Id);
    }
}
