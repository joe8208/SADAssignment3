using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADAssignment3.Models;

namespace SADAssignment3.DAL
{
    public class UnitOfWork : IDisposable
    {
        private SADAssignment3Context context = new SADAssignment3Context();
        private GenericRepository<LineInput> lineInputRepository;        

        public GenericRepository<LineInput> LineInputRepository
        {
            get
            {

                if (this.lineInputRepository == null)
                {
                    this.lineInputRepository = new GenericRepository<LineInput>(context);
                }
                return lineInputRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
