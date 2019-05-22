using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BudgetMePlease.Dao;
using BudgetMePlease.Models;

namespace BudgetMePlease.Services
{
    public class EnvelopeServiceImp : IEnvelopeService
    {
        private IEnvelopeDao _envelopeDao;
        public EnvelopeServiceImp(EnvelopeDaoImp envDao)
        {
            _envelopeDao = envDao;
        }
        public async Task DeleteEnvelopeAsync(Envelope envelope)
        {

            await _envelopeDao.DeleteEnvelopeAsync(envelope);
        }

        public async Task<IEnumerable<Envelope>> GetAllEnvelopes()
        {
            return await _envelopeDao.GetAllEnvelopes();
        }

        public async Task<Envelope> GetEnvelope(int Id)
        {
            return await _envelopeDao.GetEnvelope(Id);
        }

        public async Task InsertEnvelopeAsync(Envelope envelope)
        {
            await _envelopeDao.InsertEnvelopeAsync(envelope);
        }

        public async Task UpdateEnvelopeAsync(Envelope envelope)
        {
            await _envelopeDao.UpdateEnvelopeAsync(envelope);
        }
    }
}
