using Microsoft.EntityFrameworkCore;
using SistemaAtualEmprestimo.Interfaces;
using SistemaAtualEmprestimo.Models;

namespace SistemaAtualEmprestimo.Repository
{
    public class RepositoryBase<T> : IRepositoryModel<T>, IDisposable where T : class
    {
        protected EmprestimoAtualContext _Contexto;
        public bool _SaveChanges = true;

        public RepositoryBase(bool saveChanges = true)
        {
            _SaveChanges = saveChanges;

            _Contexto = new EmprestimoAtualContext();

        }
        public T Alterar(T objecto)
        {
            _Contexto.Entry(objecto).State = EntityState.Modified;
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
            return objecto;
        }

        public void Dispose()
        {
            _Contexto.Dispose();
        }

        public void Excluir(T objecto)
        {
            _Contexto.Set<T>().Remove(objecto);
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
        }

        public void Excluir(params object[] variavel)
        {
            var obj = SelecionarPk(variavel);
            Excluir(obj);
        }

        public T Incluir(T objecto)
        {
            _Contexto.Set<T>().Add(objecto);
            if (_SaveChanges)
            {
                _Contexto.SaveChanges();
            }
            return objecto;
        }

        public void SaveChanges()
        {
            _Contexto.SaveChanges();
        }

        public T SelecionarPk(params object[] variavel)
        {
            return _Contexto.Set<T>().Find(variavel);
        }

        public List<T> SelecionarTodos()
        {
            return _Contexto.Set<T>().ToList();
        }
    }
}
