namespace SistemaAtualEmprestimo.Interfaces
{
    public interface IRepositoryModel<T> where T : class
    {
        List<T> SelecionarTodos();

        T SelecionarPk(params object[] variavel);
        T Incluir(T objecto);
        T Alterar(T objecto);
        void Excluir(T objecto);
        void Excluir(params object[] variavel);
        void SaveChanges();


    }
}
